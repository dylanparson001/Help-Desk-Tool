using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BC = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
using iGPS_Help_Desk.Controllers;

namespace iGPS_Help_Desk.Managers
{
    public class LoginController : BaseController
    {
        public string PasswordPath { get; set; } = "./AdminHash.txt";

        public string GetFilePath()
        {
            if (!File.Exists(PasswordPath))
            {
                throw new Exception("Admin password not found");
            }
            return File.ReadAllText(PasswordPath);
        }

        public bool Login(string password)
        {

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cannot be empty");
            }

            string savedPassword = GetFilePath();

            if (BC.EnhancedVerify(password, savedPassword))
            {
                return true;
            }

            return false;
        }
    }
}
