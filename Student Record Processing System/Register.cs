using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Record_Processing_System
{
    public partial class Register : Form
    {

        private readonly Color tabOn = Color.FromArgb(128, 0, 0);
        private readonly Color tabOff = Color.FromArgb(238, 238, 238);
        private readonly string editId;      // null = Add, may laman = Edit
        private bool busy;                   // para hindi magpaulit-ulit ang dropdown refresh

        private const int MinAge = 15;
        private const int MaxAge = 70;

        private static readonly Regex IdPattern =
            new Regex("^" + AcademicRules.SchoolCode + @"-(\d{2})-(\d{4})$");
        private static readonly Regex NamePattern =
            new Regex(@"^\p{L}[\p{L} .'\-]*$");
        private static readonly Regex EmailPattern =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private static readonly Regex MobilePattern =
            new Regex(@"^09\d{9}$");
        private static readonly HashSet<string> EmptyWords =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "n/a", "na", "none", "-", "." };

        public Register() : this(null) { }

        public Register(string studentId)
        {
            InitializeComponent();
            editId = studentId;

            btn_personal.ForeColor = Color.Black;
            btn_contact.ForeColor = Color.Black;
            btn_academic.ForeColor = Color.Black;
            btn_cancel.ForeColor = Color.Black;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dungeonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ShowTab(Panel target, ReaLTaiizor.Controls.Button active)
        {
            panel_info.Visible = panel_contact.Visible = panel_academic.Visible = false;
            target.Visible = true;

            foreach (var b in new[] { btn_personal, btn_contact, btn_academic })   // Personal, Contact, Academic
            {
                b.InactiveColor = tabOff;
                b.BorderColor = Color.Gray;
                b.ForeColor = Color.Black;
            }

            active.InactiveColor = tabOn;
            active.BorderColor = tabOn;
            active.ForeColor = Color.White;
        }

        // Nilalagay ang mga radio button sa sarili nilang Panel para hindi sila magkahalo
        private void GroupRadios(Control parent, params Control[] items)
        {
            int left = items.Min(c => c.Left);
            int top = items.Min(c => c.Top);
            int right = items.Max(c => c.Right);
            int bottom = items.Max(c => c.Bottom);

            var box = new Panel
            {
                Location = new Point(left, top),
                Size = new Size(right - left, bottom - top),
                BackColor = Color.WhiteSmoke
            };
            parent.Controls.Add(box);

            foreach (var c in items)
            {
                parent.Controls.Remove(c);
                c.Location = new Point(c.Left - left, c.Top - top);
                box.Controls.Add(c);
            }
        }



        private void Register_Load(object sender, EventArgs e)
        {

            GroupRadios(panel_academic, rb_act, rb_bscs);
            GroupRadios(panel_academic, rb_regular, rb_irregular);
            btn_personal.Click += (s, ev) => ShowTab(panel_info, btn_personal);
            btn_contact.Click += (s, ev) => ShowTab(panel_contact, btn_contact);
            btn_academic.Click += (s, ev) => ShowTab(panel_academic, btn_academic);
            btn_cancel.Click += (s, ev) => DialogResult = DialogResult.Cancel;

            txt_studentno.MaxLength = 13;                       // 04141-23-0111
            cmb_year.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_section.DropDownStyle = ComboBoxStyle.DropDownList;

            dtp_birthdate.MaxDate = DateTime.Today.AddYears(-MinAge);
            dtp_birthdate.MinDate = DateTime.Today.AddYears(-MaxAge);
            dtp_birthdate.ShowCheckBox = true;                  // walang tsek = hindi pa napili
            dtp_birthdate.Checked = false;
            dtp_enroll.Value = DateTime.Today;
            rb_regular.Checked = true;

            // Ang Year at Section ay sumusunod sa Program
            rb_act.CheckedChanged += (s, ev) => RefreshYears();
            rb_bscs.CheckedChanged += (s, ev) => RefreshYears();
            cmb_year.SelectedIndexChanged += (s, ev) => RefreshSections();
            RefreshYears();


            ShowTab(panel_info, btn_personal);

            if (editId != null)
            {
                lbl_register.Text = "Edit student";
                txt_studentno.ReadOnly = true;      // primary key, hindi pwedeng palitan
                LoadStudent(editId);
            }
        }

        private string SelectedProgram
        {
            get { return rb_act.Checked ? "ACT" : rb_bscs.Checked ? "BSCS" : null; }
        }

        private void RefreshYears()
        {
            if (busy) return;
            busy = true;
            try
            {
                string prog = SelectedProgram;
                int keep = cmb_year.SelectedIndex;

                cmb_year.Items.Clear();
                for (int i = 0; i < AcademicRules.MaxYear(prog); i++)
                    cmb_year.Items.Add(AcademicRules.YearNames[i]);

                cmb_year.SelectedIndex = (keep >= 0 && keep < cmb_year.Items.Count) ? keep : -1;
            }
            finally { busy = false; }

            RefreshSections();
        }

        private void RefreshSections()
        {
            if (busy) return;
            busy = true;
            try
            {
                string prog = SelectedProgram;
                int year = cmb_year.SelectedIndex + 1;
                string keep = cmb_section.SelectedItem == null ? null : cmb_section.SelectedItem.ToString();

                cmb_section.Items.Clear();
                if (prog != null && year > 0)
                    cmb_section.Items.AddRange(AcademicRules.Sections(prog, year));

                cmb_section.SelectedIndex = keep == null ? -1 : cmb_section.Items.IndexOf(keep);
            }
            finally { busy = false; }
        }

        // ---------- PAGPUNO NG FIELDS (EDIT) ----------

        private static string Str(MySqlDataReader r, string col)
        {
            return r[col] == DBNull.Value ? "" : r[col].ToString();
        }

        private void LoadStudent(string id)
        {
            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT s.*, p.program_code
                                   FROM students s
                                   JOIN programs p ON p.program_id = s.program_id
                                   WHERE s.student_id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                MessageBox.Show("Student not found.");
                                DialogResult = DialogResult.Cancel;
                                return;
                            }

                            txt_studentno.Text = Str(r, "student_id");
                            txt_lname.Text = Str(r, "last_name");
                            txt_fname.Text = Str(r, "first_name");
                            txt_mname.Text = Str(r, "middle_name");
                            txt_suffix.Text = Str(r, "suffix");

                            string sex = Str(r, "sex");
                            rb_male.Checked = sex == "Male";
                            rb_female.Checked = sex == "Female";

                            if (r["birthdate"] != DBNull.Value)
                            {
                                DateTime bd = (DateTime)r["birthdate"];
                                if (bd < dtp_birthdate.MinDate) bd = dtp_birthdate.MinDate;
                                if (bd > dtp_birthdate.MaxDate) bd = dtp_birthdate.MaxDate;
                                dtp_birthdate.Value = bd;
                                dtp_birthdate.Checked = true;
                            }

                            txt_contactno.Text = Str(r, "contact_no");
                            txt_email.Text = Str(r, "email");
                            txt_address.Text = Str(r, "address");
                            txt_guardian.Text = Str(r, "guardian_name");
                            txt_gcontact.Text = Str(r, "guardian_contact");

                            // Sunud-sunod: Program, tapos Year, tapos Section
                            string prog = Str(r, "program_code");
                            rb_act.Checked = prog == "ACT";
                            rb_bscs.Checked = prog == "BSCS";
                            RefreshYears();

                            int yr = Convert.ToInt32(r["year_level"]);
                            if (yr >= 1 && yr <= cmb_year.Items.Count)
                                cmb_year.SelectedIndex = yr - 1;
                            RefreshSections();

                            cmb_section.SelectedIndex = cmb_section.Items.IndexOf(Str(r, "section"));

                            bool irregular = Str(r, "status") == "Irregular";
                            rb_irregular.Checked = irregular;
                            rb_regular.Checked = !irregular;

                            if (r["date_enrolled"] != DBNull.Value)
                                dtp_enroll.Value = (DateTime)r["date_enrolled"];
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not load the record.\n" + ex.Message);
            }
        }

        // ---------- VALIDATION ----------

        private bool Fail(Panel tab, ReaLTaiizor.Controls.Button tabBtn, Control focus, string message)
        {
            MessageBox.Show(message, "Check the form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ShowTab(tab, tabBtn);
            if (focus != null) focus.Focus();
            return false;
        }

        // Ang "N/A", "none", "-" ay ituturing na blangko
        private static string CleanOptional(string s)
        {
            s = s.Trim();
            return EmptyWords.Contains(s) ? "" : s;
        }

        private static string NormalizeSuffix(string s)
        {
            switch (s.Trim().TrimEnd('.').ToUpperInvariant())
            {
                case "JR": return "Jr.";
                case "SR": return "Sr.";
                case "II": return "II";
                case "III": return "III";
                case "IV": return "IV";
                case "V": return "V";
                default: return null;
            }
        }

        // Ginagawang 09XXXXXXXXX. Nagre-return ng null kung mali.
        private static string NormalizeMobile(string s)
        {
            s = Regex.Replace(s, @"[\s\-()]", "");
            if (s.StartsWith("+63")) s = "0" + s.Substring(3);
            return MobilePattern.IsMatch(s) ? s : null;
        }

        private bool ValidateInputs()
        {
            // ---- PERSONAL ----
            Match idMatch = IdPattern.Match(txt_studentno.Text.Trim());
            if (editId == null)
            {
                if (!idMatch.Success)
                    return Fail(panel_info, btn_personal, txt_studentno,
                        "Student ID must follow the format " + AcademicRules.SchoolCode +
                        "-YY-NNNN, for example " + AcademicRules.SchoolCode + "-23-0111.");
                if (idMatch.Groups[2].Value == "0000")
                    return Fail(panel_info, btn_personal, txt_studentno,
                        "The last 4 digits of the student ID cannot be 0000.");

                // BAGO: hindi pwedeng mas bago kaysa sa kasalukuyang taon
                int idYear = int.Parse(idMatch.Groups[1].Value);
                int maxIdYear = DateTime.Today.Year % 100;     // 26 ngayong 2026
                if (idYear > maxIdYear)
                    return Fail(panel_info, btn_personal, txt_studentno,
                        "The year in the student ID cannot be later than " + maxIdYear.ToString("00") + ".");
            }

            string last = txt_lname.Text.Trim();
            if (last == "")
                return Fail(panel_info, btn_personal, txt_lname, "Enter the last name.");
            if (!NamePattern.IsMatch(last))
                return Fail(panel_info, btn_personal, txt_lname,
                    "The last name can only contain letters, spaces, hyphens, apostrophes, and periods.");

            string first = txt_fname.Text.Trim();
            if (first == "")
                return Fail(panel_info, btn_personal, txt_fname, "Enter the first name.");
            if (!NamePattern.IsMatch(first))
                return Fail(panel_info, btn_personal, txt_fname,
                    "The first name can only contain letters, spaces, hyphens, apostrophes, and periods.");

            // Middle name: pwedeng blangko
            string mid = CleanOptional(txt_mname.Text);
            if (mid != "" && !NamePattern.IsMatch(mid))
                return Fail(panel_info, btn_personal, txt_mname,
                    "The middle name can only contain letters. Leave it blank if the student has none.");
            txt_mname.Text = mid;

            // Suffix: pwedeng blangko
            string sfx = CleanOptional(txt_suffix.Text);
            if (sfx != "")
            {
                string fixedSfx = NormalizeSuffix(sfx);
                if (fixedSfx == null)
                    return Fail(panel_info, btn_personal, txt_suffix,
                        "The suffix must be Jr., Sr., II, III, IV, or V. Leave it blank if none.");
                sfx = fixedSfx;
            }
            txt_suffix.Text = sfx;

            if (!rb_male.Checked && !rb_female.Checked)
                return Fail(panel_info, btn_personal, null, "Select the student's sex.");

            if (!dtp_birthdate.Checked)
                return Fail(panel_info, btn_personal, null,
                    "Set the birthdate: tick the box beside the date, then pick the date.");

            DateTime bd = dtp_birthdate.Value.Date;
            DateTime today = DateTime.Today;
            int age = today.Year - bd.Year;
            if (bd > today.AddYears(-age)) age--;
            if (bd > today)
                return Fail(panel_info, btn_personal, null, "The birthdate cannot be in the future.");
            if (age < MinAge || age > MaxAge)
                if (editId == null)
                {
                    int entryYear = 2000 + int.Parse(idMatch.Groups[1].Value);
                    if (entryYear - bd.Year < MinAge)
                        return Fail(panel_info, btn_personal, txt_studentno,
                            "The ID year " + (entryYear % 100).ToString("00") + " does not match the birthdate. " +
                            "The student would have been younger than " + MinAge + " when enrolled.");
                }


            // ---- CONTACT (optional, but if filled must be valid) ----
            string email = txt_email.Text.Trim();
            if (email != "" && !EmailPattern.IsMatch(email))
                return Fail(panel_contact, btn_contact, txt_email, "Enter a valid email address.");

            string mobile = txt_contactno.Text.Trim();
            if (mobile != "")
            {
                string n = NormalizeMobile(mobile);
                if (n == null)
                    return Fail(panel_contact, btn_contact, txt_contactno,
                        "The contact number must be 11 digits and start with 09 (example: 09171234567).");
                txt_contactno.Text = n;
            }

            string gmobile = txt_gcontact.Text.Trim();
            if (gmobile != "")
            {
                string n = NormalizeMobile(gmobile);
                if (n == null)
                    return Fail(panel_contact, btn_contact, txt_gcontact,
                        "The guardian's contact number must be 11 digits and start with 09.");
                txt_gcontact.Text = n;
            }

            // ---- ACADEMIC ----
            string prog = SelectedProgram;
            if (prog == null)
                return Fail(panel_academic, btn_academic, null, "Select a program.");
            if (cmb_year.SelectedIndex < 0)
                return Fail(panel_academic, btn_academic, cmb_year, "Select the year level.");
            if (cmb_section.SelectedIndex < 0)
                return Fail(panel_academic, btn_academic, cmb_section, "Select the section.");

            int year = cmb_year.SelectedIndex + 1;
            string section = cmb_section.SelectedItem.ToString();

            string err;
            if (!AcademicRules.IsValid(prog, year, section, out err))
                return Fail(panel_academic, btn_academic, null, err);


            return true;
        }

        // ---------- SAVE ----------

        private static object NullIfEmpty(string s)
        {
            s = s.Trim();
            return s == "" ? (object)DBNull.Value : s;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string id = txt_studentno.Text.Trim();

            try
            {
                using (var conn = DbConn.GetConnection())
                {
                    conn.Open();

                    if (editId == null)
                    {
                        using (var chk = new MySqlCommand(
                            "SELECT COUNT(*) FROM students WHERE student_id = @id", conn))
                        {
                            chk.Parameters.AddWithValue("@id", id);
                            if (Convert.ToInt32(chk.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show("That student ID already exists (the record may have been deleted).",
                                    "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                ShowTab(panel_info, btn_personal);
                                txt_studentno.Focus();
                                return;
                            }
                        }
                    }

                    string sql;
                    if (editId == null)
                    {
                        sql = @"INSERT INTO students
                                (student_id, last_name, first_name, middle_name, suffix, sex, birthdate,
                                 contact_no, email, address, guardian_name, guardian_contact,
                                 program_id, year_level, section, status, date_enrolled)
                                VALUES
                                (@id, @ln, @fn, @mn, @sfx, @sex, @bd,
                                 @contact, @email, @addr, @gname, @gcontact,
                                 (SELECT program_id FROM programs WHERE program_code = @prog),
                                 @yr, @sec, @status, @enrolled)";
                    }
                    else
                    {
                        sql = @"UPDATE students SET
                                    last_name = @ln, first_name = @fn, middle_name = @mn, suffix = @sfx,
                                    sex = @sex, birthdate = @bd,
                                    contact_no = @contact, email = @email, address = @addr,
                                    guardian_name = @gname, guardian_contact = @gcontact,
                                    program_id = (SELECT program_id FROM programs WHERE program_code = @prog),
                                    year_level = @yr, section = @sec,
                                    status = @status, date_enrolled = @enrolled
                                WHERE student_id = @id";
                    }

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@ln", txt_lname.Text.Trim());
                        cmd.Parameters.AddWithValue("@fn", txt_fname.Text.Trim());
                        cmd.Parameters.AddWithValue("@mn", NullIfEmpty(txt_mname.Text));
                        cmd.Parameters.AddWithValue("@sfx", NullIfEmpty(txt_suffix.Text));
                        cmd.Parameters.AddWithValue("@sex", rb_male.Checked ? "Male" : "Female");
                        cmd.Parameters.AddWithValue("@bd", dtp_birthdate.Value.Date);
                        cmd.Parameters.AddWithValue("@contact", NullIfEmpty(txt_contactno.Text));
                        cmd.Parameters.AddWithValue("@email", NullIfEmpty(txt_email.Text));
                        cmd.Parameters.AddWithValue("@addr", NullIfEmpty(txt_address.Text));
                        cmd.Parameters.AddWithValue("@gname", NullIfEmpty(txt_guardian.Text));
                        cmd.Parameters.AddWithValue("@gcontact", NullIfEmpty(txt_gcontact.Text));
                        cmd.Parameters.AddWithValue("@prog", SelectedProgram);
                        cmd.Parameters.AddWithValue("@yr", cmb_year.SelectedIndex + 1);
                        cmd.Parameters.AddWithValue("@sec", cmb_section.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@status", rb_irregular.Checked ? "Irregular" : "Regular");
                        cmd.Parameters.AddWithValue("@enrolled", dtp_enroll.Value.Date);
                        cmd.ExecuteNonQuery();
                    }
                }

                DialogResult = DialogResult.OK;   // isasara ang dialog at magre-refresh ang grid
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("That student ID already exists.");
            }
            catch (MySqlException ex) when (ex.Number == 1048)
            {
                MessageBox.Show("The selected program was not found in the database.\n" +
                                "Check the programs table (ACT and BSCS).");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not save the record.\n" + ex.Message);
            }
        }
    }


}
