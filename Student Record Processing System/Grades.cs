using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Record_Processing_System
{
    public partial class Grades : Form
    {



        private class SubjectItem
        {
            public int Id;
            public string Code;
            public string Name;
            public int Units;
            public int YearLevel;
            public GradeWeights Weights;

            public string Text
            {
                get { return Code + " - " + Name + " (" + Ordinal(YearLevel) + " yr)"; }
            }
        }

        private static string Ordinal(int n)
        {
            switch (n)
            {
                case 1: return "1st";
                case 2: return "2nd";
                case 3: return "3rd";
                default: return n + "th";
            }
        }

        private readonly List<SubjectItem> subjects = new List<SubjectItem>();

        // Ang subject, school year, at semester na NAKA-LOAD sa grid ngayon.
        // Dito ise-save, kahit nagbago na ang mga dropdown.
        private SubjectItem currentSubject;
        private string currentSchoolYear;
        private int currentSemester;

        private bool busy;      // habang nire-refresh ang mga dropdown
        private bool loading;   // habang nilalagay ang data sa grid
        private bool dirty;     // may hindi pa na-save na pagbabago

        private static readonly Color EditTint = Color.FromArgb(253, 246, 224);

        public Grades()
        {
            InitializeComponent();
            Load -= Grades_Load;     // para hindi madoble kung nakakabit na rin sa designer
            Load += Grades_Load;
            btn_save.ForeColor = Color.Black;
        }

        private void dgv_grades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grades_Load(object sender, EventArgs e)
        {
            dgv_grades.ReadOnly = false;
            foreach (DataGridViewColumn c in new DataGridViewColumn[]
                     { student_id, student_name, final_percent, grade, remark })
                c.ReadOnly = true;
            foreach (DataGridViewColumn c in new DataGridViewColumn[]
                     { midterm, final_exam, attendance, class_standing, dropped })
                c.ReadOnly = false;

            // Itsura
            dgv_grades.RowTemplate.Height = 34;
            Color selBack = Color.FromArgb(235, 210, 210);
            dgv_grades.DefaultCellStyle.SelectionBackColor = selBack;
            dgv_grades.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_grades.RowsDefaultCellStyle.SelectionBackColor = selBack;
            dgv_grades.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgv_grades.AlternatingRowsDefaultCellStyle.SelectionBackColor = selBack;
            dgv_grades.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // Mga event ng grid
            dgv_grades.CellValidating += dgv_grades_CellValidating;
            dgv_grades.CellEndEdit += (s, ev) =>
            {
                if (IsScoreColumn(ev.ColumnIndex))
                    dgv_grades.Rows[ev.RowIndex].Cells[ev.ColumnIndex].ErrorText = "";
            };
            dgv_grades.CellValueChanged += dgv_grades_CellValueChanged;
            dgv_grades.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                // Para agad na magbago ang DRP checkbox
                if (dgv_grades.IsCurrentCellDirty && dgv_grades.CurrentCell is DataGridViewCheckBoxCell)
                    dgv_grades.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgv_grades.EditingControlShowing += dgv_grades_EditingControlShowing;
            dgv_grades.CellFormatting += dgv_grades_CellFormatting;
            dgv_grades.DataError += (s, ev) => { ev.ThrowException = false; };

            btn_compute.Click += btn_compute_Click;
            btn_save.Click += (s, ev) => SaveGrades();
            FormClosing += Grades_FormClosing;

            // Mga dropdown
            busy = true;
            cmb_schoolyear.Items.Clear();
            foreach (string sy in GradeRules.SchoolYears())
                cmb_schoolyear.Items.Add(sy);
            cmb_schoolyear.SelectedIndex = 0;
            cmb_semester.SelectedIndex = 0;
            cmb_program.SelectedIndex = 0;
            busy = false;

            cmb_program.SelectedIndexChanged += (s, ev) => { if (!busy && ConfirmLeave()) LoadSubjects(); };
            cmb_semester.SelectedIndexChanged += (s, ev) => { if (!busy && ConfirmLeave()) LoadSubjects(); };
            cmb_subject.SelectedIndexChanged += (s, ev) => { if (!busy && ConfirmLeave()) OnSubjectChanged(); };
            cmb_section.SelectedIndexChanged += (s, ev) => { if (!busy && ConfirmLeave()) LoadGrid(); };
            cmb_schoolyear.SelectedIndexChanged += (s, ev) => { if (!busy && ConfirmLeave()) LoadGrid(); };

            LoadSubjects();
        }

        private string SelectedProgram
        {
            get { return cmb_program.SelectedItem == null ? "" : cmb_program.SelectedItem.ToString(); }
        }

        private SubjectItem SelectedSubject
        {
            get
            {
                int i = cmb_subject.SelectedIndex;
                return (i >= 0 && i < subjects.Count) ? subjects[i] : null;
            }
        }

        private void LoadSubjects()
        {
            busy = true;
            subjects.Clear();
            cmb_subject.Items.Clear();
            cmb_section.Items.Clear();

            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT s.subject_id, s.subject_code, s.subject_name, s.units, s.year_level,
                                          s.w_midterm, s.w_final, s.w_attendance, s.w_class
                                   FROM subjects s
                                   JOIN programs p ON p.program_id = s.program_id
                                   WHERE p.program_code = @prog AND s.semester = @sem
                                   ORDER BY s.year_level, s.subject_code";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@prog", SelectedProgram);
                        cmd.Parameters.AddWithValue("@sem", cmb_semester.SelectedIndex + 1);

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                var it = new SubjectItem
                                {
                                    Id = Convert.ToInt32(r["subject_id"]),
                                    Code = r["subject_code"].ToString(),
                                    Name = r["subject_name"].ToString(),
                                    Units = Convert.ToInt32(r["units"]),
                                    YearLevel = Convert.ToInt32(r["year_level"]),
                                    Weights = new GradeWeights
                                    {
                                        Midterm = Convert.ToDecimal(r["w_midterm"]),
                                        Final = Convert.ToDecimal(r["w_final"]),
                                        Attendance = Convert.ToDecimal(r["w_attendance"]),
                                        ClassStanding = Convert.ToDecimal(r["w_class"])
                                    }
                                };
                                subjects.Add(it);
                                cmb_subject.Items.Add(it.Text);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not load the subjects.\n" + ex.Message);
            }

            if (cmb_subject.Items.Count > 0) cmb_subject.SelectedIndex = 0;
            busy = false;

            OnSubjectChanged();
        }

        private void OnSubjectChanged()
        {
            busy = true;
            cmb_section.Items.Clear();

            SubjectItem s = SelectedSubject;
            if (s != null)
            {
                cmb_section.Items.AddRange(AcademicRules.Sections(SelectedProgram, s.YearLevel));
                if (cmb_section.Items.Count > 0)
                {
                    int i = FirstSectionWithStudents(s.YearLevel);
                    cmb_section.SelectedIndex = i >= 0 ? i : 0;
                }
            }
            busy = false;

            LoadGrid();
        }

        // ---------- PAGLOAD NG GRID ----------

        private static string Fmt(object v)
        {
            if (v == null || v == DBNull.Value) return "";
            return Convert.ToDecimal(v).ToString("0.##", CultureInfo.InvariantCulture);
        }

        private void SetHeaders(GradeWeights w)
        {
            midterm.HeaderText = w == null ? "Midterm" : "Midterm (" + w.Midterm + "%)";
            final_exam.HeaderText = w == null ? "Final" : "Final (" + w.Final + "%)";
            attendance.HeaderText = w == null ? "Attendance" : "Attendance (" + w.Attendance + "%)";
            class_standing.HeaderText = w == null ? "Class" : "Class (" + w.ClassStanding + "%)";
        }

        private void SetStatus(string text)
        {
            lbl_status.Text = text;    // panatilihing maikli, makitid ang label
        }

        private void LoadGrid()
        {
            loading = true;
            dgv_grades.Rows.Clear();
            dirty = false;
            progress_bar.Value = 0;

            SubjectItem subj = SelectedSubject;
            string section = cmb_section.SelectedItem == null ? null : cmb_section.SelectedItem.ToString();
            string sy = cmb_schoolyear.SelectedItem == null ? null : cmb_schoolyear.SelectedItem.ToString();
            int sem = cmb_semester.SelectedIndex + 1;

            currentSubject = null;

            if (subj == null || section == null || sy == null)
            {
                SetHeaders(null);
                SetStatus("No subjects yet");
                loading = false;
                return;
            }

            if (subj.Weights.Total != 100)
                MessageBox.Show("The weights of " + subj.Code + " do not add up to 100%. Check the subjects table.");

            SetHeaders(subj.Weights);

            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT s.student_id,
                                          CONCAT(s.last_name, ', ', s.first_name,
                                                 IF(IFNULL(s.middle_name, '') = '', '',
                                                    CONCAT(' ', UPPER(LEFT(s.middle_name, 1)), '.')),
                                                 IF(IFNULL(s.suffix, '') = '', '',
                                                    CONCAT(' ', s.suffix))) AS student_name,
                                          g.midterm, g.final_exam, g.attendance, g.class_standing, g.is_dropped
                                   FROM students s
                                   JOIN programs p ON p.program_id = s.program_id
                                   LEFT JOIN grades g ON g.student_id = s.student_id
                                                     AND g.subject_id = @subj
                                                     AND g.school_year = @sy
                                                     AND g.semester = @sem
                                   WHERE s.is_deleted = 0
                                     AND p.program_code = @prog
                                     AND s.year_level = @yr
                                     AND s.section = @sec
                                   ORDER BY s.last_name, s.first_name";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@subj", subj.Id);
                        cmd.Parameters.AddWithValue("@sy", sy);
                        cmd.Parameters.AddWithValue("@sem", sem);
                        cmd.Parameters.AddWithValue("@prog", SelectedProgram);
                        cmd.Parameters.AddWithValue("@yr", subj.YearLevel);
                        cmd.Parameters.AddWithValue("@sec", section);

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int idx = dgv_grades.Rows.Add();
                                DataGridViewRow row = dgv_grades.Rows[idx];

                                row.Cells[student_id.Index].Value = r["student_id"].ToString();
                                row.Cells[student_name.Index].Value = r["student_name"].ToString();
                                row.Cells[midterm.Index].Value = Fmt(r["midterm"]);
                                row.Cells[final_exam.Index].Value = Fmt(r["final_exam"]);
                                row.Cells[attendance.Index].Value = Fmt(r["attendance"]);
                                row.Cells[class_standing.Index].Value = Fmt(r["class_standing"]);
                                row.Cells[dropped.Index].Value =
                                    r["is_dropped"] != DBNull.Value && Convert.ToInt32(r["is_dropped"]) == 1;

                                // Kulay ng mga cell na pwedeng i-type
                                row.Cells[midterm.Index].Style.BackColor = EditTint;
                                row.Cells[final_exam.Index].Style.BackColor = EditTint;
                                row.Cells[attendance.Index].Style.BackColor = EditTint;
                                row.Cells[class_standing.Index].Style.BackColor = EditTint;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not load the students.\n" + ex.Message);
                loading = false;
                return;
            }

         

            currentSubject = subj;
            currentSchoolYear = sy;
            currentSemester = sem;

            foreach (DataGridViewRow row in dgv_grades.Rows)
                RecomputeRow(row);

            loading = false;
            dirty = false;
            lastElapsed = "00:00.0";
            UpdateStatus();

            if (dgv_grades.Rows.Count == 0)
                lbl_status.Text = "No students here";
        }

        // ---------- PAG-COMPUTE ----------

        private static bool IsTrue(object v)
        {
            return v is bool && (bool)v;
        }

        private void ReadRow(DataGridViewRow row, out decimal? mid, out decimal? fin,
                             out decimal? att, out decimal? cls, out bool drp)
        {
            GradeRules.TryParseScore(row.Cells[midterm.Index].Value, out mid);
            GradeRules.TryParseScore(row.Cells[final_exam.Index].Value, out fin);
            GradeRules.TryParseScore(row.Cells[attendance.Index].Value, out att);
            GradeRules.TryParseScore(row.Cells[class_standing.Index].Value, out cls);
            drp = IsTrue(row.Cells[dropped.Index].Value);
        }

        private void ApplyResult(DataGridViewRow row, GradeResult r, bool isDropped)
        {
            row.Cells[final_percent.Index].Value = r.Percent.HasValue
                ? r.Percent.Value.ToString("0.00", CultureInfo.InvariantCulture) : "";
            row.Cells[grade.Index].Value = r.GradeText;
            row.Cells[remark.Index].Value = r.Remark;

            int[] inputs = { midterm.Index, final_exam.Index, attendance.Index, class_standing.Index };
            foreach (int i in inputs)
            {
                row.Cells[i].ReadOnly = isDropped;
                row.Cells[i].Style.ForeColor = isDropped ? Color.Gray : Color.Empty;
            }
        }

        private void RecomputeRow(DataGridViewRow row)
        {
            if (currentSubject == null) return;

            decimal? m, f, a, c;
            bool d;
            ReadRow(row, out m, out f, out a, out c, out d);
            ApplyResult(row, GradeRules.Compute(m, f, a, c, d, currentSubject.Weights), d);
        }

        // Compute All: kinukuha muna ang lahat ng laman, tapos Parallel.For ang pagkuwenta.
        // Hindi hinahawakan ang UI sa loob ng Parallel.For, kaya ligtas.
        private async void btn_compute_Click(object sender, EventArgs e)
        {
            if (currentSubject == null || dgv_grades.Rows.Count == 0) return;
            if (!dgv_grades.EndEdit()) return;

            int n = dgv_grades.Rows.Count;
            var mid = new decimal?[n];
            var fin = new decimal?[n];
            var att = new decimal?[n];
            var cls = new decimal?[n];
            var drp = new bool[n];
            var results = new GradeResult[n];

            for (int i = 0; i < n; i++)
                ReadRow(dgv_grades.Rows[i], out mid[i], out fin[i], out att[i], out cls[i], out drp[i]);

            GradeWeights w = currentSubject.Weights;
            int step = Math.Max(1, n / 100);
            int done = 0;
            var progress = new Progress<int>(v => progress_bar.Value = v);
            IProgress<int> report = progress;

            btn_compute.Enabled = false;
            btn_save.Enabled = false;
            progress_bar.Value = 0;
            var sw = Stopwatch.StartNew();

            try
            {
                await Task.Run(() =>
                {
                    Parallel.For(0, n, i =>
                    {
                        results[i] = GradeRules.Compute(mid[i], fin[i], att[i], cls[i], drp[i], w);
                        int d = Interlocked.Increment(ref done);
                        if (d % step == 0 || d == n) report.Report(d * 100 / n);
                    });
                });

                sw.Stop();
                for (int i = 0; i < n; i++)
                    ApplyResult(dgv_grades.Rows[i], results[i], drp[i]);

                lastElapsed = sw.Elapsed.ToString("mm\\:ss\\.f");
                UpdateStatus();
            }
            finally
            {
                btn_compute.Enabled = true;
                btn_save.Enabled = true;
            }
        }

        // ---------- PAG-EDIT NG MGA CELL ----------

        private bool IsScoreColumn(int col)
        {
            return col == midterm.Index || col == final_exam.Index ||
                   col == attendance.Index || col == class_standing.Index;
        }

        private void dgv_grades_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || !IsScoreColumn(e.ColumnIndex)) return;

            var cell = dgv_grades.Rows[e.RowIndex].Cells[e.ColumnIndex];
            decimal? v;
            if (GradeRules.TryParseScore(e.FormattedValue, out v))
            {
                cell.ErrorText = "";
                return;
            }

            cell.ErrorText = "Enter a number from 0 to 100.";
            SetStatus("Invalid score");
            e.Cancel = true;     // hindi makakaalis sa cell hanggang tama (o pindutin ang Esc)
        }

        private void dgv_grades_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading || e.RowIndex < 0) return;
            if (!IsScoreColumn(e.ColumnIndex) && e.ColumnIndex != dropped.Index) return;

            dirty = true;
            RecomputeRow(dgv_grades.Rows[e.RowIndex]);
            dirty = true;
            RecomputeRow(dgv_grades.Rows[e.RowIndex]);
            UpdateStatus();
        }

        private void dgv_grades_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var tb = e.Control as TextBox;
            if (tb == null) return;

            tb.KeyPress -= ScoreKeyPress;
            if (dgv_grades.CurrentCell != null && IsScoreColumn(dgv_grades.CurrentCell.ColumnIndex))
            {
                tb.MaxLength = 6;
                tb.KeyPress += ScoreKeyPress;
            }
        }

        private void ScoreKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            var tb = (TextBox)sender;
            if (e.KeyChar == '.' && !tb.Text.Contains(".")) return;

            e.Handled = true;
        }

        private void dgv_grades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != remark.Index || e.Value == null) return;

            switch (e.Value.ToString())
            {
                case "Passed":
                    e.CellStyle.BackColor = Color.FromArgb(234, 243, 222);
                    e.CellStyle.ForeColor = Color.FromArgb(39, 80, 10);
                    break;
                case "Failed":
                    e.CellStyle.BackColor = Color.FromArgb(252, 235, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(163, 45, 45);
                    break;
                case "Dropped":
                    e.CellStyle.BackColor = Color.FromArgb(225, 225, 225);
                    e.CellStyle.ForeColor = Color.FromArgb(90, 90, 90);
                    break;
                case "Pending":
                    e.CellStyle.BackColor = Color.FromArgb(250, 238, 218);
                    e.CellStyle.ForeColor = Color.FromArgb(99, 56, 6);
                    break;
            }
        }

        private static object Db(decimal? v)
        {
            return v.HasValue ? (object)v.Value : DBNull.Value;
        }

        private bool SaveGrades()
        {
            if (currentSubject == null || dgv_grades.Rows.Count == 0) return true;
            if (!dgv_grades.EndEdit()) return false;

            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        string sql = @"INSERT INTO grades
                                         (student_id, subject_id, school_year, semester,
                                          midterm, final_exam, attendance, class_standing,
                                          final_percent, grade_point, is_dropped, remark)
                                       VALUES
                                         (@sid, @subj, @sy, @sem,
                                          @mid, @fin, @att, @cls,
                                          @pct, @gp, @drp, @rem)
                                       ON DUPLICATE KEY UPDATE
                                          midterm = VALUES(midterm),
                                          final_exam = VALUES(final_exam),
                                          attendance = VALUES(attendance),
                                          class_standing = VALUES(class_standing),
                                          final_percent = VALUES(final_percent),
                                          grade_point = VALUES(grade_point),
                                          is_dropped = VALUES(is_dropped),
                                          remark = VALUES(remark)";

                        using (var cmd = new MySqlCommand(sql, conn, tx))
                        {
                            foreach (DataGridViewRow row in dgv_grades.Rows)
                            {
                                decimal? m, f, a, c;
                                bool d;
                                ReadRow(row, out m, out f, out a, out c, out d);
                                GradeResult r = GradeRules.Compute(m, f, a, c, d, currentSubject.Weights);

                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@sid", row.Cells[student_id.Index].Value.ToString());
                                cmd.Parameters.AddWithValue("@subj", currentSubject.Id);
                                cmd.Parameters.AddWithValue("@sy", currentSchoolYear);
                                cmd.Parameters.AddWithValue("@sem", currentSemester);
                                cmd.Parameters.AddWithValue("@mid", Db(m));
                                cmd.Parameters.AddWithValue("@fin", Db(f));
                                cmd.Parameters.AddWithValue("@att", Db(a));
                                cmd.Parameters.AddWithValue("@cls", Db(c));
                                cmd.Parameters.AddWithValue("@pct", Db(r.Percent));
                                cmd.Parameters.AddWithValue("@gp", Db(r.GradePoint));
                                cmd.Parameters.AddWithValue("@drp", d ? 1 : 0);
                                cmd.Parameters.AddWithValue("@rem", r.Remark);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                }

                dirty = false;
                SetStatus("Saved - " + dgv_grades.Rows.Count + " rows");
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not save the grades.\n" + ex.Message);
                return false;
            }
        }

        // Kapag may hindi pa na-save at magpapalit ng dropdown
        private bool ConfirmLeave()
        {
            if (!dirty) return true;

            var r = MessageBox.Show("You have unsaved grades. Save them first?",
                "Unsaved grades", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes) return SaveGrades();

            dirty = false;     // No = itapon ang pagbabago
            return true;
        }

        private void Grades_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!dirty) return;

            var r = MessageBox.Show("Save your grade changes before leaving?",
                "Unsaved grades", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) SaveGrades();
        }

        private string lastElapsed = "00:00.0";

        private void UpdateStatus()
        {
            int n = dgv_grades.Rows.Count;
            int graded = 0;
            foreach (DataGridViewRow row in dgv_grades.Rows)
            {
                object rm = row.Cells[remark.Index].Value;
                if (rm != null && rm.ToString() != "" && rm.ToString() != "Pending") graded++;
            }

            lbl_status.Text = graded + " of " + n + " rows - " + lastElapsed;
            progress_bar.Value = n == 0 ? 0 : graded * 100 / n;
        }

        // Pipiliin ang unang section na may estudyante, para hindi blangko ang grid sa simula
        private int FirstSectionWithStudents(int year)
        {
            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT s.section
                           FROM students s
                           JOIN programs p ON p.program_id = s.program_id
                           WHERE s.is_deleted = 0
                             AND p.program_code = @prog
                             AND s.year_level = @yr
                           ORDER BY s.section LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@prog", SelectedProgram);
                        cmd.Parameters.AddWithValue("@yr", year);
                        object o = cmd.ExecuteScalar();
                        if (o != null) return cmb_section.Items.IndexOf(o.ToString());
                    }
                }
            }
            catch (MySqlException) { }
            return 0;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }
    }
}


