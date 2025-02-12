using iGPS_Help_Desk.Managers;
using System;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class LoginForm : BaseForm
    {
        private readonly LoginController _loginController;

        public int ClickCount { get; set; } = 1;
        public LoginForm(LoginController loginController)
        {
            InitializeComponent();

            _loginController = loginController;

            AcceptButton = btnLogin;
            txtPassword.Select();
            txtPassword.PasswordChar = '\u2022';
        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                return;
            }
            string password = txtPassword.Text;

            try
            {
                if (_loginController.Login(password))
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
                MessageBox.Show($"Message: {ex.Message}");
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

                txtPassword.PasswordChar = '\u2022';
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