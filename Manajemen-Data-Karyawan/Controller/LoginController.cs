using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manajemen_Data_Karyawan.Model;

namespace Manajemen_Data_Karyawan.Controller
{
    public class LoginController
    {
        private UserModel userModel;

        public LoginController()
        {
            userModel = new UserModel();
        }

        public bool Login(string username, string password)
        {
            return userModel.CekLogin(username, password);
        }
    }
}
