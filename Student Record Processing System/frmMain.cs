using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;



namespace Student_Record_Processing_System
{
    public partial class frmMain : Form
    {

        private Form activeForm = null;
        private readonly Color normalColor = Color.FromArgb(128, 0, 0);
        private readonly Color selectedColor = Color.FromArgb(92, 0, 0);
        private readonly Color gold = Color.FromArgb(212, 175, 55);
        public frmMain()
        {
            InitializeComponent();
        }

        private Button activeButton = null;

        private void OpenChildForm(Form child)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = child;

            child.TopLevel = false;                        // para pwedeng ilagay sa loob ng panel
            child.FormBorderStyle = FormBorderStyle.None;  // tanggalin ang title bar at border
            child.Dock = DockStyle.Fill;                   // sumunod sa laki ng panel

            panel_form.Controls.Clear();
            panel_form.Controls.Add(child);
            child.Show();
        }


        private void SelectButton(Button btn, string title)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = normalColor;
                activeButton.ForeColor = Color.White;
            }
            activeButton = btn;
            btn.BackColor = selectedColor;
            btn.ForeColor = gold;
            lblTitle.Text = title;

            lbl_username.Visible = (title == "Dashboard");
        }
        private void panel_form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbl_username.Text = $"Welcome, {Session.FullName} ({Session.Role})";
            SelectButton(btn_dashboard, "Dashboard");
            OpenChildForm(new Dashboard());
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            SelectButton(btn_dashboard, "Dashboard");
            OpenChildForm(new Dashboard());
        }

        private void btn_students_Click(object sender, EventArgs e)
        {
            SelectButton(btn_students, "Students");
            OpenChildForm(new Student());
        }
    }
}
