using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar.Forms
{
    public partial class LoginForm : Form
    {

        User user;
        UserController usercontroller;

        public LoginForm()
        {

            InitializeComponent();
            this.usercontroller = new UserController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void tbxLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
                tbxLoginPassword.PasswordChar = '\0';
            else tbxLoginPassword.PasswordChar = '*';
        }

        private void LogIn()
        {
            btnLogin.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string username = tbxLoginUsername.Text;
            string password = tbxLoginPassword.Text;

            try
            {
                if (tbxLoginPassword != null & (tbxLoginUsername != null))
                {

                    user = UserController.Login(username, password);

                    if (user != null)
                    {
                        Form1 form1 = new Form1(user);
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        btnLogin.Enabled = true;
                        MessageBox.Show("The username or password you entered is wrong. Please try again.");
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                btnLogin.Enabled = true;
                MessageBox.Show("The username or password you entered is wrong. Please try again.");
            }
        }
    }
}
