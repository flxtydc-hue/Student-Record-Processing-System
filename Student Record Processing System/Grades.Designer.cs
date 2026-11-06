namespace Student_Record_Processing_System
{
    partial class Grades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_program = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_schoolyear = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_semester = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_subject = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.cmb_section = new ReaLTaiizor.Controls.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_compute = new ReaLTaiizor.Controls.Button();
            this.btn_save = new ReaLTaiizor.Controls.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_status = new ReaLTaiizor.Controls.ForeverLabel();
            this.progress_bar = new ReaLTaiizor.Controls.MoonProgressBar();
            this.dgv_grades = new System.Windows.Forms.DataGridView();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midterm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.final_exam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_standing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.final_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dropped = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grades)).BeginInit();
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
            this.cmb_program.Location = new System.Drawing.Point(12, 12);
            this.cmb_program.Name = "cmb_program";
            this.cmb_program.Size = new System.Drawing.Size(123, 26);
            this.cmb_program.StartIndex = 0;
            this.cmb_program.TabIndex = 22;
            // 
            // cmb_schoolyear
            // 
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
            this.cmb_schoolyear.Location = new System.Drawing.Point(443, 12);
            this.cmb_schoolyear.Name = "cmb_schoolyear";
            this.cmb_schoolyear.Size = new System.Drawing.Size(124, 26);
            this.cmb_schoolyear.StartIndex = 0;
            this.cmb_schoolyear.TabIndex = 23;
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
            this.cmb_semester.Location = new System.Drawing.Point(283, 12);
            this.cmb_semester.Name = "cmb_semester";
            this.cmb_semester.Size = new System.Drawing.Size(138, 26);
            this.cmb_semester.StartIndex = 0;
            this.cmb_semester.TabIndex = 24;
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
            this.cmb_subject.Location = new System.Drawing.Point(585, 12);
            this.cmb_subject.Name = "cmb_subject";
            this.cmb_subject.Size = new System.Drawing.Size(327, 26);
            this.cmb_subject.StartIndex = 0;
            this.cmb_subject.TabIndex = 25;
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
            this.cmb_section.Location = new System.Drawing.Point(160, 12);
            this.cmb_section.Name = "cmb_section";
            this.cmb_section.Size = new System.Drawing.Size(99, 26);
            this.cmb_section.StartIndex = 0;
            this.cmb_section.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_schoolyear);
            this.panel1.Controls.Add(this.cmb_semester);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 54);
            this.panel1.TabIndex = 28;
            // 
            // btn_compute
            // 
            this.btn_compute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_compute.BackColor = System.Drawing.Color.Transparent;
            this.btn_compute.BorderColor = System.Drawing.Color.Maroon;
            this.btn_compute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_compute.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_compute.EnteredColor = System.Drawing.Color.Maroon;
            this.btn_compute.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_compute.Image = null;
            this.btn_compute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_compute.InactiveColor = System.Drawing.Color.Maroon;
            this.btn_compute.Location = new System.Drawing.Point(12, 470);
            this.btn_compute.Name = "btn_compute";
            this.btn_compute.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_compute.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_compute.Size = new System.Drawing.Size(123, 33);
            this.btn_compute.TabIndex = 29;
            this.btn_compute.Text = "Compute All";
            this.btn_compute.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.btn_save.Location = new System.Drawing.Point(150, 470);
            this.btn_save.Name = "btn_save";
            this.btn_save.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_save.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_save.Size = new System.Drawing.Size(118, 33);
            this.btn_save.TabIndex = 36;
            this.btn_save.Text = "Save Grades";
            this.btn_save.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_status);
            this.panel2.Controls.Add(this.progress_bar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 465);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 47);
            this.panel2.TabIndex = 37;
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_status.AutoSize = true;
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.ForeColor = System.Drawing.Color.Black;
            this.lbl_status.Location = new System.Drawing.Point(735, 8);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(164, 28);
            this.lbl_status.TabIndex = 49;
            this.lbl_status.Text = "6 of 6 rows - 00:00.1";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progress_bar
            // 
            this.progress_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progress_bar.Animated = true;
            this.progress_bar.Customization = "/////w==";
            this.progress_bar.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_bar.HatchType = System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal;
            this.progress_bar.Image = null;
            this.progress_bar.LineColor = System.Drawing.Color.DarkGray;
            this.progress_bar.LineEndColor = System.Drawing.Color.DimGray;
            this.progress_bar.LinerColor = System.Drawing.Color.DimGray;
            this.progress_bar.LinesColor = System.Drawing.Color.DimGray;
            this.progress_bar.LineUpColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.progress_bar.Location = new System.Drawing.Point(422, 16);
            this.progress_bar.Maximum = 100;
            this.progress_bar.Minimum = 0;
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.NoRounding = false;
            this.progress_bar.Size = new System.Drawing.Size(301, 10);
            this.progress_bar.TabIndex = 48;
            this.progress_bar.Text = "moonProgressBar1";
            this.progress_bar.Transparent = false;
            this.progress_bar.Value = 0;
            // 
            // dgv_grades
            // 
            this.dgv_grades.AllowUserToAddRows = false;
            this.dgv_grades.AllowUserToDeleteRows = false;
            this.dgv_grades.AllowUserToResizeColumns = false;
            this.dgv_grades.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_grades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_grades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_grades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_grades.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_grades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_grades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_grades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_grades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.student_name,
            this.midterm,
            this.final_exam,
            this.attendance,
            this.class_standing,
            this.final_percent,
            this.grade,
            this.remark,
            this.dropped});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_grades.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_grades.EnableHeadersVisualStyles = false;
            this.dgv_grades.Location = new System.Drawing.Point(12, 72);
            this.dgv_grades.Name = "dgv_grades";
            this.dgv_grades.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_grades.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_grades.RowHeadersVisible = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_grades.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_grades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_grades.Size = new System.Drawing.Size(888, 389);
            this.dgv_grades.TabIndex = 27;
            this.dgv_grades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_grades_CellContentClick);
            this.dgv_grades.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_grades_CellFormatting);
            this.dgv_grades.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_grades_CellValueChanged);
            this.dgv_grades.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_grades_EditingControlShowing);
            // 
            // student_id
            // 
            this.student_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.student_id.DataPropertyName = "student_id";
            this.student_id.HeaderText = "Student ID";
            this.student_id.Name = "student_id";
            this.student_id.ReadOnly = true;
            // 
            // student_name
            // 
            this.student_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.student_name.DataPropertyName = "student_name";
            this.student_name.HeaderText = "Name";
            this.student_name.Name = "student_name";
            this.student_name.ReadOnly = true;
            // 
            // midterm
            // 
            this.midterm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.midterm.DataPropertyName = "midterm";
            this.midterm.HeaderText = "Midterm";
            this.midterm.Name = "midterm";
            this.midterm.ReadOnly = true;
            this.midterm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.midterm.Width = 88;
            // 
            // final_exam
            // 
            this.final_exam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.final_exam.DataPropertyName = "final_exam";
            this.final_exam.HeaderText = "Final";
            this.final_exam.Name = "final_exam";
            this.final_exam.ReadOnly = true;
            this.final_exam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.final_exam.Width = 64;
            // 
            // attendance
            // 
            this.attendance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.attendance.DataPropertyName = "attendance";
            this.attendance.HeaderText = "Attendance";
            this.attendance.Name = "attendance";
            this.attendance.ReadOnly = true;
            this.attendance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.attendance.Width = 111;
            // 
            // class_standing
            // 
            this.class_standing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.class_standing.DataPropertyName = "class_standing";
            this.class_standing.HeaderText = "Class";
            this.class_standing.Name = "class_standing";
            this.class_standing.ReadOnly = true;
            this.class_standing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.class_standing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.class_standing.Width = 51;
            // 
            // final_percent
            // 
            this.final_percent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.final_percent.HeaderText = "Final %";
            this.final_percent.Name = "final_percent";
            this.final_percent.ReadOnly = true;
            this.final_percent.Width = 77;
            // 
            // grade
            // 
            this.grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grade.HeaderText = "Grade";
            this.grade.Name = "grade";
            this.grade.ReadOnly = true;
            this.grade.Width = 75;
            // 
            // remark
            // 
            this.remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.remark.HeaderText = "Remark";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 84;
            // 
            // dropped
            // 
            this.dropped.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dropped.HeaderText = "DRP";
            this.dropped.Name = "dropped";
            this.dropped.ReadOnly = true;
            // 
            // Grades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 512);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_compute);
            this.Controls.Add(this.dgv_grades);
            this.Controls.Add(this.cmb_section);
            this.Controls.Add(this.cmb_subject);
            this.Controls.Add(this.cmb_program);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Grades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Grades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Grades_FormClosing);
            this.Load += new System.EventHandler(this.Grades_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ComboBoxEdit cmb_program;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_schoolyear;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_semester;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_subject;
        private ReaLTaiizor.Controls.ComboBoxEdit cmb_section;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.Button btn_compute;
        private ReaLTaiizor.Controls.Button btn_save;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.MoonProgressBar progress_bar;
        private System.Windows.Forms.DataGridView dgv_grades;
        private ReaLTaiizor.Controls.ForeverLabel lbl_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn midterm;
        private System.Windows.Forms.DataGridViewTextBoxColumn final_exam;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_standing;
        private System.Windows.Forms.DataGridViewTextBoxColumn final_percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dropped;
    }
}