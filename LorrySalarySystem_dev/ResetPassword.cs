using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LorrySalarySystem_dev
{
    public partial class ResetPassword : Form
    {
        Library lib = new Library();
        bool check = false;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnSubmitPW_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtcurrpassword.Text) || string.IsNullOrEmpty(txtnewpassword.Text) || string.IsNullOrEmpty(txtnewpassword2.Text))
            {
                MessageBox.Show("Cannot accept empty info, please check your info and submit again.", "Error");
                check = false;
            }

            else if ( txtnewpassword.Text != txtnewpassword2.Text )
            {
                MessageBox.Show("New password and re-type password must identical!", "Error");
                check = false;
            }

            else if (!lib.logincheck(txtusername.Text.ToString(), txtcurrpassword.Text.ToString()))
            {
                MessageBox.Show("Please make sure current password is correct", "Error");
                check = false;
            }
            else
            {
                check = true;
            }

            if (check)
            {
                try
                {
                    lib.updateUserPassword(txtusername.Text.ToString(), txtnewpassword.Text.ToString());
                    MessageBox.Show("Password updated successfully!", "Successful");
                    
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
                finally
                {
                    txtusername.Text = string.Empty;
                    txtcurrpassword.Text = string.Empty;
                    txtnewpassword.Text = string.Empty;
                    txtnewpassword2.Text = string.Empty;
                    this.Close();
                }
            }
        }
    }
}
