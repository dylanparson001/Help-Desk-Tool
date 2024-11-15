using Serilog;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt;

namespace iGPS_Help_Desk.Views
{
    public partial class LoginForm : BaseForm
    {

        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            txtPassword.Select();

        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            string password = txtPassword.Text;

            string filePath = "./adminHash.txt";
            string valueFromFile = File.ReadAllText(filePath);

            valueFromFile.Trim();

            try
            {
                if (BC.EnhancedVerify(password, valueFromFile))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    txtPassword.Text = "";
                    lblInvalidPassword.Text = "Invalid Password";
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Message: {ex.Message} Check Config");
            }
        }

        private void showPasswordText(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar != '\0')
            {
                txtPassword.PasswordChar = '\0';
            } 
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}