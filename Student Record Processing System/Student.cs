using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Student_Record_Processing_System
{
    public partial class Student : Form
    {

        private const int IconSize = 18;
        private const int IconGap = 14;

        private string selectedProgram = "";   // "" = lahat
        public Student()
        {
            InitializeComponent();
        }

        private void btn_all_Click(object sender, EventArgs e)
        {

        }

        private void dgv_students_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_students_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != Actions.Index) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            int totalWidth = IconSize * 2 + IconGap;
            int x = e.CellBounds.Left + (e.CellBounds.Width - totalWidth) / 2;
            int y = e.CellBounds.Top + (e.CellBounds.Height - IconSize) / 2;

            e.Graphics.DrawImage(Properties.Resources.edit, x, y, IconSize, IconSize);
            e.Graphics.DrawImage(Properties.Resources.delete, x + IconSize + IconGap, y, IconSize, IconSize);

            e.Handled = true;
        }

        private void dgv_students_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != Actions.Index) return;

            int startX = (Actions.Width - (IconSize * 2 + IconGap)) / 2;
            var row = dgv_students.Rows[e.RowIndex];
            string studentId = row.Cells[student_id.Index].Value.ToString();
            string name = row.Cells[student_name.Index].Value.ToString();

            if (e.X >= startX && e.X <= startX + IconSize)
                EditStudent(studentId);
            else if (e.X >= startX + IconSize + IconGap && e.X <= startX + IconSize * 2 + IconGap)
                DeleteStudent(studentId, name);
        }

        private void dgv_students_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool overIcon = false;
            if (e.RowIndex >= 0 && e.ColumnIndex == Actions.Index)
            {
                int startX = (Actions.Width - (IconSize * 2 + IconGap)) / 2;
                overIcon = (e.X >= startX && e.X <= startX + IconSize) ||
                           (e.X >= startX + IconSize + IconGap && e.X <= startX + IconSize * 2 + IconGap);
            }
            dgv_students.Cursor = overIcon ? Cursors.Hand : Cursors.Default;
        }

        private void DeleteStudent(string studentId, string name)
        {
            var confirm = MessageBox.Show(
       "Delete " + name + " (" + studentId + ")?\nThe record will be hidden from the list.",
       "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE students
                           SET is_deleted = 1, deleted_at = NOW()
                           WHERE student_id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadStudents();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not delete the record.\n" + ex.Message);
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            dgv_students.AutoGenerateColumns = false;
            student_id.DataPropertyName = "student_id";
            student_name.DataPropertyName = "full_name";
            program.DataPropertyName = "program_code";
            year.DataPropertyName = "year_text";
            section.DataPropertyName = "section";
            Actions.DataPropertyName = "";

            dgv_students.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex < 0 || ev.ColumnIndex == Actions.Index) return;
                EditStudent(dgv_students.Rows[ev.RowIndex].Cells[student_id.Index].Value.ToString());
            };
            comboBoxEdit1.SelectedIndex = 0;                     // Year: All
            button1.Click += (s, ev) => FilterProgram("");      // All
            btn_bscs.Click += (s, ev) => FilterProgram("BSCS");
            btn_act.Click += (s, ev) => FilterProgram("ACT");
            comboBoxEdit1.SelectedIndexChanged += (s, ev) => LoadStudents();
            txt_search.TextChanged += (s, ev) => LoadStudents();
            dgv_students.CellMouseLeave += (s, ev) => dgv_students.Cursor = Cursors.Default;
            btn_add.Click += (s, ev) => AddStudent();

            LoadStudents();
        }

        private void FilterProgram(string code)
        {
            selectedProgram = code;
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT s.student_id,
                                  CONCAT(s.last_name, ', ', s.first_name,
                                         IF(IFNULL(s.middle_name, '') = '', '',
                                            CONCAT(' ', LEFT(s.middle_name, 1), '.')),
                                         IF(IFNULL(s.suffix, '') = '', '',
                                            CONCAT(' ', s.suffix))) AS full_name,
                                  p.program_code,
                                  CONCAT(s.year_level,
                                         CASE s.year_level WHEN 1 THEN 'st'
                                                           WHEN 2 THEN 'nd'
                                                           WHEN 3 THEN 'rd'
                                                           ELSE 'th' END) AS year_text,
                                  s.section
                           FROM students s
                           JOIN programs p ON p.program_id = s.program_id
                           WHERE s.is_deleted = 0
                             AND (@prog = '' OR p.program_code = @prog)
                             AND (@yr = 0 OR s.year_level = @yr)
                             AND (s.student_id LIKE @q
                                  OR s.last_name LIKE @q
                                  OR s.first_name LIKE @q)
                           ORDER BY s.last_name, s.first_name";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@prog", selectedProgram);
                        cmd.Parameters.AddWithValue("@yr", Math.Max(0, comboBoxEdit1.SelectedIndex));
                        cmd.Parameters.AddWithValue("@q", "%" + txt_search.Text.Trim() + "%");

                        var table = new DataTable();
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(table);
                        }
                        dgv_students.DataSource = table;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not load students.\n" + ex.Message);
            }
        }

        private void AddStudent()
        {
            using (var dlg = new Register())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadStudents();
            }
        }


        private void EditStudent(string studentId)
        {
            using (var dlg = new Register(studentId))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadStudents();
            }
        }
        // Para bumalik sa normal ang cursor kapag umalis ang mouse sa cell
        private void dgv_students_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgv_students.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_students_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
