
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectCsharp.Controller;
using ProjectCsharp.Model;
using ProjectCsharp.Animation;
namespace ProjectCsharp
{
    public partial class LoginForm : Form
    {
        private Boolean flag;
        private int x;
        private int y;
        private string id;
        private string pass;
        private int roles;
        private UserController userController;
        private Login sessionLoginUser;
        public LoginForm(string id, string pass, int roles)
        {
            this.id = id;
            this.pass = pass;
            this.roles = roles;
        }
        private void showError(string show)
        {
            lblShowError.Text = show;
        }
        public LoginForm()
        {
            InitializeComponent();
            this.Opacity = 0;
            userController = new UserController();
            panelShowError.Visible = false;
            cmbRole.DisplayMember = "Text";
            cmbRole.ValueMember = "Value";
            cmbRole.Items.Add(new { Text = "Administrator", Value = 1 });
            cmbRole.Items.Add(new { Text = "Managers", Value = 2 });
            cmbRole.Items.Add(new { Text = "Staff/Officer", Value = 3 });
            cmbRole.SelectedIndex = 0;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("Username"))
            {
                txtUsername.Text = "";
            }
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("Password"))
            {
                txtPassword.Text = "";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag) {
                this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string roles = cmbRole.SelectedIndex.ToString();
            if (userController.isLogin(txtUsername.Text, txtPassword.Text, (int.Parse(roles) + 1)) != null)
            {
                sessionLoginUser = new Login(txtUsername.Text, txtPassword.Text, (int.Parse(roles) + 1));
                this.Hide();
                if ((int.Parse(roles) + 1) == 3)
                {
                    new StaffForm(sessionLoginUser).Show();
                }
                else
                {
                   
                    new IndexForm(sessionLoginUser).Show();
                }
               

            }
            else
            {
                panelShowError.Visible = true;
                lblShowError.Text = "Invalid loginID or Login Password";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Animation.Animation.FadeIn(this);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}

