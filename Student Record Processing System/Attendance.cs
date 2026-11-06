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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            btn_present.ForeColor = Color.Black;
            btn_noclass.ForeColor = Color.Black;
            btn_save.ForeColor = Color.Black;   

        }

        private void Attendance_Load(object sender, EventArgs e)
        {

        }
    }
}
