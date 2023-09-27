using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using iGPS_Help_Desk.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void clickLoginButton(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string siteId = ConfigurationManager.AppSettings.Get("siteId");
            
            // Check for connection to sql
            try
            {
                SqlConnection connection = new SqlConnection
                    ($"Server={siteId}\\SQLEXPRESS;Database=epcdocmandb_igps; " +
                     $"User ID={username}; password={password};");
                connection.Open();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}