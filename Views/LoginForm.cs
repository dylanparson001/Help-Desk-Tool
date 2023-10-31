using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt;

namespace iGPS_Help_Desk.Views
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ClickLoginButton(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            string pwHash = BC.EnhancedHashPassword(password, 13);
            
/*            // If there is no password set, should only be ran if passsword gets deleted
            if (settings["admin"].Value == "")
            {
                settings["admin"].Value = pwHash;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
*/
            try
            {
                string pwFromConfig = settings["admin"].Value;
                if (BC.EnhancedVerify(password, pwFromConfig))
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
                MessageBox.Show($"Message: {ex.Message}\n Check Config");
                
            }

        }
        private static string generateSalt() {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create()) {
                keyGenerator.GetBytes(bytes);
 
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        private static string hashPassword(string password, string salt)
        {
            var hmac = new SHA256Managed();

            // hash password from user
            byte[] passwordHash = Encoding.UTF8.GetBytes(password + salt);
            passwordHash = hmac.ComputeHash(passwordHash);
            return Encoding.UTF8.GetString(passwordHash);

        }
    }
}