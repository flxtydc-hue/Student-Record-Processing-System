namespace Student_Record_Processing_System
{
    partial class Attendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_program = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_section = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_schoolyear = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_semester = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_subject = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_students = new System.Windows.Forms.DataGridView();
            this.btn_present = new ReaLTaiizor.Controls.Button();
            this.btn_noclass = new ReaLTaiizor.Controls.Button();
            this.btn_calculate = new ReaLTaiizor.Controls.Button();
            this.btn_save = new ReaLTaiizor.Controls.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_school = new ReaLTaiizor.Controls.ForeverLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_schooldays = new ReaLTaiizor.Controls.ForeverLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_aveattendance = new ReaLTaiizor.Controls.ForeverLabel();
            this.lbl_att = new ReaLTaiizor.Controls.ForeverLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_below = new ReaLTaiizor.Controls.ForeverLabel();
            this.lbl_bel = new ReaLTaiizor.Controls.ForeverLabel();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.today = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days_present = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtp_attendance = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_students)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_program
            // 
            this.cmb_program.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_program.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_program.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_program.DropDownHeight = 100;
            this.cmb_program.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_program.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_program.ForeColor = System.Drawing.Color.Gray;
            this.cmb_program.FormattingEnabled = true;
            this.cmb_program.HoverSelectionColor = System.Drawing.Color.LightGray;
            this.cmb_program.IntegralHeight = false;
            this.cmb_program.ItemHeight = 20;
            this.cmb_program.Items.AddRange(new object[] {
            "BSCS",
            "ACT"});
            this.cmb_program.Location = new System.Drawing.Point(137, 12);
            this.cmb_program.Name = "cmb_program";
            this.cmb_program.Size = new System.Drawing.Size(123, 26);
            this.cmb_program.StartIndex = 0;
            this.cmb_program.TabIndex = 23;
            // 
            // cmb_section
            // 
            this.cmb_section.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_section.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_section.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_section.DropDownHeight = 100;
            this.cmb_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_section.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_section.ForeColor = System.Drawing.Color.Gray;
            this.cmb_section.FormattingEnabled = true;
            this.cmb_section.HoverSelectionColor = System.Drawing.Color.LightGray;
            this.cmb_section.IntegralHeight = false;
            this.cmb_section.ItemHeight = 20;
            this.cmb_section.Location = new System.Drawing.Point(266, 12);
            this.cmb_section.Name = "cmb_section";
            this.cmb_section.Size = new System.Drawing.Size(99, 26);
            this.cmb_section.StartIndex = 0;
            this.cmb_section.TabIndex = 27;
            // 
            // cmb_schoolyear
            // 
            this.cmb_schoolyear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_schoolyear.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_schoolyear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_schoolyear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_schoolyear.DropDownHeight = 100;
            this.cmb_schoolyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_schoolyear.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_schoolyear.ForeColor = System.Drawing.Color.Gray;
            this.cmb_schoolyear.FormattingEnabled = true;
            this.cmb_schoolyear.HoverSelectionColor = System.Drawing.Color.LightGray;
            this.cmb_schoolyear.IntegralHeight = false;
            this.cmb_schoolyear.ItemHeight = 20;
            this.cmb_schoolyear.Items.AddRange(new object[] {
            "2026-2027"});
            this.cmb_schoolyear.Location = new System.Drawing.Point(515, 12);
            this.cmb_schoolyear.Name = "cmb_schoolyear";
            this.cmb_schoolyear.Size = new System.Drawing.Size(124, 26);
            this.cmb_schoolyear.StartIndex = 0;
            this.cmb_schoolyear.TabIndex = 28;
            // 
            // cmb_semester
            // 
            this.cmb_semester.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_semester.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_semester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_semester.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_semester.DropDownHeight = 100;
            this.cmb_semester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_semester.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_semester.ForeColor = System.Drawing.Color.Gray;
            this.cmb_semester.FormattingEnabled = true;
            this.cmb_semester.HoverSelectionColor = System.Drawing.Color.LightGray;
            this.cmb_semester.IntegralHeight = false;
            this.cmb_semester.ItemHeight = 20;
            this.cmb_semester.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester"});
            this.cmb_semester.Location = new System.Drawing.Point(371, 12);
            this.cmb_semester.Name = "cmb_semester";
            this.cmb_semester.Size = new System.Drawing.Size(138, 26);
            this.cmb_semester.StartIndex = 0;
            this.cmb_semester.TabIndex = 29;
            // 
            // cmb_subject
            // 
            this.cmb_subject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_subject.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_subject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_subject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_subject.DropDownHeight = 100;
            this.cmb_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_subject.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_subject.ForeColor = System.Drawing.Color.Gray;
            this.cmb_subject.FormattingEnabled = true;
            this.cmb_subject.HoverSelectionColor = System.Drawing.Color.LightGray;
            this.cmb_subject.IntegralHeight = false;
            this.cmb_subject.ItemHeight = 20;
            this.cmb_subject.Location = new System.Drawing.Point(645, 12);
            this.cmb_subject.Name = "cmb_subject";
            this.cmb_subject.Size = new System.Drawing.Size(250, 26);
            this.cmb_subject.StartIndex = 0;
            this.cmb_subject.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtp_attendance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 54);
            this.panel1.TabIndex = 31;
            // 
            // dgv_students
            // 
            this.dgv_students.AllowUserToAddRows = false;
            this.dgv_students.AllowUserToDeleteRows = false;
            this.dgv_students.AllowUserToResizeColumns = false;
            this.dgv_students.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_students.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_students.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_students.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_students.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_students.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_students.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_students.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.student_name,
            this.today,
            this.days_present,
            this.rate});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_students.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_students.EnableHeadersVisualStyles = false;
            this.dgv_students.Location = new System.Drawing.Point(24, 64);
            this.dgv_students.Name = "dgv_students";
            this.dgv_students.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_students.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_students.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_students.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_students.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_students.Size = new System.Drawing.Size(858, 242);
            this.dgv_students.TabIndex = 32;
            // 
            // btn_present
            // 
            this.btn_present.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_present.BackColor = System.Drawing.Color.Transparent;
            this.btn_present.BorderColor = System.Drawing.Color.Gray;
            this.btn_present.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_present.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_present.EnteredColor = System.Drawing.Color.Maroon;
            this.btn_present.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_present.Image = null;
            this.btn_present.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_present.InactiveColor = System.Drawing.Color.Transparent;
            this.btn_present.Location = new System.Drawing.Point(24, 312);
            this.btn_present.Name = "btn_present";
            this.btn_present.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_present.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_present.Size = new System.Drawing.Size(160, 33);
            this.btn_present.TabIndex = 37;
            this.btn_present.Text = "Mark all present";
            this.btn_present.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btn_noclass
            // 
            this.btn_noclass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_noclass.BackColor = System.Drawing.Color.Transparent;
            this.btn_noclass.BorderColor = System.Drawing.Color.Gray;
            this.btn_noclass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_noclass.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_noclass.EnteredColor = System.Drawing.Color.Maroon;
            this.btn_noclass.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_noclass.Image = null;
            this.btn_noclass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_noclass.InactiveColor = System.Drawing.Color.Transparent;
            this.btn_noclass.Location = new System.Drawing.Point(211, 312);
            this.btn_noclass.Name = "btn_noclass";
            this.btn_noclass.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_noclass.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_noclass.Size = new System.Drawing.Size(148, 33);
            this.btn_noclass.TabIndex = 38;
            this.btn_noclass.Text = "Mark no class";
            this.btn_noclass.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btn_calculate
            // 
            this.btn_calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_calculate.BackColor = System.Drawing.Color.Transparent;
            this.btn_calculate.BorderColor = System.Drawing.Color.Maroon;
            this.btn_calculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_calculate.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_calculate.EnteredColor = System.Drawing.Color.Maroon;
            this.btn_calculate.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calculate.Image = null;
            this.btn_calculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_calculate.InactiveColor = System.Drawing.Color.Maroon;
            this.btn_calculate.Location = new System.Drawing.Point(394, 312);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_calculate.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_calculate.Size = new System.Drawing.Size(209, 33);
            this.btn_calculate.TabIndex = 39;
            this.btn_calculate.Text = "Calculate attendance";
            this.btn_calculate.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BorderColor = System.Drawing.Color.Gray;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_save.EnteredColor = System.Drawing.Color.Maroon;
            this.btn_save.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Image = null;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.InactiveColor = System.Drawing.Color.Transparent;
            this.btn_save.Location = new System.Drawing.Point(635, 312);
            this.btn_save.Name = "btn_save";
            this.btn_save.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_save.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_save.Size = new System.Drawing.Size(91, 33);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Save";
            this.btn_save.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 351);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(907, 166);
            this.panel2.TabIndex = 41;
            // 
            // lbl_school
            // 
            this.lbl_school.AutoSize = true;
            this.lbl_school.BackColor = System.Drawing.Color.Transparent;
            this.lbl_school.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_school.ForeColor = System.Drawing.Color.Black;
            this.lbl_school.Location = new System.Drawing.Point(3, 5);
            this.lbl_school.Name = "lbl_school";
            this.lbl_school.Size = new System.Drawing.Size(214, 56);
            this.lbl_school.TabIndex = 21;
            this.lbl_school.Text = "School days (no holidays \r\nor suspension) ";
            this.lbl_school.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_schooldays);
            this.panel3.Controls.Add(this.lbl_school);
            this.panel3.Location = new System.Drawing.Point(24, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 125);
            this.panel3.TabIndex = 22;
            // 
            // lbl_schooldays
            // 
            this.lbl_schooldays.AutoSize = true;
            this.lbl_schooldays.BackColor = System.Drawing.Color.Transparent;
            this.lbl_schooldays.Font = new System.Drawing.Font("Poppins SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_schooldays.ForeColor = System.Drawing.Color.Black;
            this.lbl_schooldays.Location = new System.Drawing.Point(6, 65);
            this.lbl_schooldays.Name = "lbl_schooldays";
            this.lbl_schooldays.Size = new System.Drawing.Size(41, 51);
            this.lbl_schooldays.TabIndex = 22;
            this.lbl_schooldays.Text = "0";
            this.lbl_schooldays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbl_aveattendance);
            this.panel4.Controls.Add(this.lbl_att);
            this.panel4.Location = new System.Drawing.Point(266, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 125);
            this.panel4.TabIndex = 23;
            // 
            // lbl_aveattendance
            // 
            this.lbl_aveattendance.AutoSize = true;
            this.lbl_aveattendance.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aveattendance.Font = new System.Drawing.Font("Poppins SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aveattendance.ForeColor = System.Drawing.Color.Black;
            this.lbl_aveattendance.Location = new System.Drawing.Point(6, 65);
            this.lbl_aveattendance.Name = "lbl_aveattendance";
            this.lbl_aveattendance.Size = new System.Drawing.Size(41, 51);
            this.lbl_aveattendance.TabIndex = 22;
            this.lbl_aveattendance.Text = "0";
            this.lbl_aveattendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_att
            // 
            this.lbl_att.AutoSize = true;
            this.lbl_att.BackColor = System.Drawing.Color.Transparent;
            this.lbl_att.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_att.ForeColor = System.Drawing.Color.Black;
            this.lbl_att.Location = new System.Drawing.Point(3, 5);
            this.lbl_att.Name = "lbl_att";
            this.lbl_att.Size = new System.Drawing.Size(179, 28);
            this.lbl_att.TabIndex = 21;
            this.lbl_att.Text = "Average Attendance";
            this.lbl_att.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl_below);
            this.panel5.Controls.Add(this.lbl_bel);
            this.panel5.Location = new System.Drawing.Point(506, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(220, 125);
            this.panel5.TabIndex = 24;
            // 
            // lbl_below
            // 
            this.lbl_below.AutoSize = true;
            this.lbl_below.BackColor = System.Drawing.Color.Transparent;
            this.lbl_below.Font = new System.Drawing.Font("Poppins SemiBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_below.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_below.Location = new System.Drawing.Point(6, 65);
            this.lbl_below.Name = "lbl_below";
            this.lbl_below.Size = new System.Drawing.Size(41, 51);
            this.lbl_below.TabIndex = 22;
            this.lbl_below.Text = "0";
            this.lbl_below.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_bel
            // 
            this.lbl_bel.AutoSize = true;
            this.lbl_bel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_bel.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bel.ForeColor = System.Drawing.Color.Black;
            this.lbl_bel.Location = new System.Drawing.Point(3, 5);
            this.lbl_bel.Name = "lbl_bel";
            this.lbl_bel.Size = new System.Drawing.Size(94, 28);
            this.lbl_bel.TabIndex = 21;
            this.lbl_bel.Text = "Below 75%";
            this.lbl_bel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 25;
            this.iconPictureBox4.Location = new System.Drawing.Point(32, 316);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(25, 25);
            this.iconPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox4.TabIndex = 42;
            this.iconPictureBox4.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 25;
            this.iconPictureBox1.Location = new System.Drawing.Point(221, 316);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(25, 25);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox1.TabIndex = 43;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Maroon;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 25;
            this.iconPictureBox2.Location = new System.Drawing.Point(407, 316);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(25, 25);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox2.TabIndex = 44;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.CameraRetro;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 25;
            this.iconPictureBox3.Location = new System.Drawing.Point(645, 316);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(25, 25);
            this.iconPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox3.TabIndex = 45;
            this.iconPictureBox3.TabStop = false;
            // 
            // student_id
            // 
            this.student_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.student_id.DataPropertyName = "student_id";
            this.student_id.HeaderText = "Student ID";
            this.student_id.Name = "student_id";
            this.student_id.ReadOnly = true;
            this.student_id.Width = 117;
            // 
            // student_name
            // 
            this.student_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.student_name.DataPropertyName = "student_name";
            this.student_name.HeaderText = "Name";
            this.student_name.Name = "student_name";
            this.student_name.ReadOnly = true;
            // 
            // today
            // 
            this.today.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.today.DataPropertyName = "today";
            this.today.HeaderText = "Today";
            this.today.Name = "today";
            this.today.ReadOnly = true;
            this.today.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.today.Width = 86;
            // 
            // days_present
            // 
            this.days_present.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.days_present.DataPropertyName = "days_present";
            this.days_present.HeaderText = "Days Present";
            this.days_present.Name = "days_present";
            this.days_present.ReadOnly = true;
            this.days_present.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.days_present.Width = 138;
            // 
            // rate
            // 
            this.rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rate.DataPropertyName = "rate";
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rate.Width = 73;
            // 
            // dtp_attendance
            // 
            this.dtp_attendance.CalendarFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_attendance.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_attendance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_attendance.Location = new System.Drawing.Point(12, 12);
            this.dtp_attendance.Name = "dtp_attendance";
            this.dtp_attendance.Size = new System.Drawing.Size(104, 27);
            this.dtp_attendance.TabIndex = 46;
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 517);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.btn_noclass);
            this.Controls.Add(this.btn_present);
            this.Controls.Add(this.dgv_students);
            this.Controls.Add(this.cmb_subject);
            this.Controls.Add(this.cmb_semester);
            this.Controls.Add(this.cmb_schoolyear);
            this.Controls.Add(this.cmb_section);
            this.Controls.Add(this.cmb_program);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Attendance";
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_students)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.ComboBoxEdit cmb_program;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_section;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_schoolyear;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_semester;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_subject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_students;
        private ReaLTaiizor.Controls.Button btn_present;
        private ReaLTaiizor.Controls.Button btn_noclass;
        private ReaLTaiizor.Controls.Button btn_calculate;
        private ReaLTaiizor.Controls.Button btn_save;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private ReaLTaiizor.Controls.ForeverLabel lbl_aveattendance;
        private ReaLTaiizor.Controls.ForeverLabel lbl_att;
        private System.Windows.Forms.Panel panel3;
        private ReaLTaiizor.Controls.ForeverLabel lbl_schooldays;
        private ReaLTaiizor.Controls.ForeverLabel lbl_school;
        private System.Windows.Forms.Panel panel5;
        private ReaLTaiizor.Controls.ForeverLabel lbl_below;
        private ReaLTaiizor.Controls.ForeverLabel lbl_bel;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.DateTimePicker dtp_attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn today;
        private System.Windows.Forms.DataGridViewTextBoxColumn days_present;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
    }
}