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
        public int ClickCount { get; set; } = 1;
        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            txtPassword.Select();

        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                return;
            }
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
                button1.Text = "Hide";
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                button1.Text = "Show";

                txtPassword.PasswordChar = '*';
            }
        }

        private void clickPopupSecretMessage(object sender, EventArgs e)
        {
            ClickCount++;
            switch (ClickCount)
            {
                case 5:
                    MessageBox.Show($"You should probably do some work!", "(╯°□°）╯︵ ┻━┻", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    ClickCount = 1;
                    break;

            }
        }
    }
}