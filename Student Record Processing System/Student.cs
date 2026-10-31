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

            int startX = (Actions.Width - (IconSize * 2 + IconGap)) / 2;   // e.X ay relatibo sa cell
            string studentId = dgv_students.Rows[e.RowIndex].Cells[student_id.Index].Value.ToString();

            if (e.X >= startX && e.X <= startX + IconSize)
            {
                EditStudent(studentId);
            }
            else if (e.X >= startX + IconSize + IconGap && e.X <= startX + IconSize * 2 + IconGap)
            {
                DeleteStudent(studentId);
            }
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

        private void DeleteStudent(string studentId)
        {
            var confirm = MessageBox.Show(
               $"Delete student {studentId}?\nThe record will be hidden from the list.",
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
            year.DataPropertyName = "year_level";
            section.DataPropertyName = "section";
            Actions.DataPropertyName = "";
            
            comboBoxEdit1.SelectedIndex = 0;                     // Year: All
            button1.Click += (s, ev) => FilterProgram("");      // All
            btn_bscs.Click += (s, ev) => FilterProgram("BSCS");
            btn_act.Click += (s, ev) => FilterProgram("ACT");
            comboBoxEdit1.SelectedIndexChanged += (s, ev) => LoadStudents();
            txt_search.TextChanged += (s, ev) => LoadStudents();
            dgv_students.CellMouseLeave += (s, ev) => dgv_students.Cursor = Cursors.Default;
            button2.Click += (s, ev) => AddStudent();

            LoadStudents();
        }

        private void AddStudent()
        {
            MessageBox.Show("Add student dialog goes here.");
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
                                          CONCAT(s.last_name, ', ', s.first_name) AS full_name,
                                          p.program_code,
                                          s.year_level,
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

        // Pansamantala. Papalitan ng dlgStudent kapag nagawa na ito.
        private void EditStudent(string studentId)
        {
            MessageBox.Show("Edit student " + studentId);
        }

        // Para bumalik sa normal ang cursor kapag umalis ang mouse sa cell
        private void dgv_students_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgv_students.Cursor = Cursors.Default;
        }
    }
}
