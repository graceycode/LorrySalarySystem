using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LorrySalarySystem_dev
{
    public partial class Login : MasterForm
    {
        
        bool check = false;
        Library lib = new Library();
        public Login()
        {
            InitializeComponent();
        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                lblMessage.Text = "Password cannot be blank!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                check = false;
            }
            else
            {
                check = true;
            }
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text))
            {
                lblMessage.Text = "User name cannot be blank!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                check = false;
            }
            else
            {
                check = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginValidation();
        }

        private void LoginValidation()
        {
            if (String.IsNullOrEmpty(txtUser.Text) || String.IsNullOrEmpty(txtPassword.Text))
            { MessageBox.Show("Username or Password cannot be blank!", "Failed"); }
            else if (!check)
            {
                MessageBox.Show("Username or Password incorrect!", "Failed");
            }
            else
            {
                try
                {
                    if (lib.logincheck(txtUser.Text, txtPassword.Text))
                    {

                        DialogResult d = MessageBox.Show("Successful Login!", "Success", MessageBoxButtons.OK);
                        if (d == DialogResult.OK)
                        {
                            username = txtUser.Text.ToString().Trim();
                            this.Hide();
                            Form1 fm = new Form1();
                            fm.Closed += (s, args) => this.Close();
                            fm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password incorrect!", "Failed");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblresetpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword frm = new ResetPassword();
            frm.Show();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginValidation();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginValidation();
        }
    }
}
