using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Record_Processing_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void foreverLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void foreverLabel4_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string user = txt_username.Text.Trim();
            string pass = txt_password.Text;

            if (user == "" || pass == "")
            {
                ShowError("Enter your username and password.");
                return;
            }

            try
            {
                if (ValidateUser(user, pass, out string fullName, out string role))
                {
                    Session.FullName = fullName;
                    Session.Role = role;

                    this.Hide();
                    var main = new frmMain();
                    main.FormClosed += (s, args) => this.Close();
                    main.Show();
                }
                else
                {
                    ShowError("Incorrect username or password. Try again.");
                    txt_password.Text = "";
                    txt_password.Focus();
                }
            }
            catch (MySqlException ex)
            {
                ShowError("Cannot connect to the database. Is MySQL running?");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private bool ValidateUser(string user, string pass, out string fullName, out string role)
        {
            fullName = null;
            role = null;

            using (var conn = DbConn.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT full_name, role
                               FROM users
                               WHERE username = @u
                                 AND password_hash = @p
                                 AND is_active = 1
                               LIMIT 1";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", user);
                    cmd.Parameters.AddWithValue("@p", DbConn.HashPassword(pass));

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fullName = reader["full_name"].ToString();
                            role = reader["role"].ToString();
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void rememberme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txt_password.UseSystemPasswordChar = true;
            iconPictureBox3.IconChar = IconChar.EyeSlash;   // simula: nakatago

            txt_password.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ev.SuppressKeyPress = true;
                    login_button_Click(login_button, EventArgs.Empty);
                }
            };
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {

            bool hidden = txt_password.UseSystemPasswordChar;
            txt_password.UseSystemPasswordChar = !hidden;
            iconPictureBox3.IconChar = hidden ? IconChar.Eye : IconChar.EyeSlash;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
