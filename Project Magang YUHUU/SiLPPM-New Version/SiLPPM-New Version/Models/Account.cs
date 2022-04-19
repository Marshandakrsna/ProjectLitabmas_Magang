using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiLPPM_New_Version.Models
{
    public class Account
    {
        private string username, npp, nama;
        private string password;
        private string role;
        public Account()
        {
            npp = "";
            nama = "";
            username = "";
            password = "";
            role = "";
        }

        public Account(string _npp, string _nama, string _user, string _pass, string _roles)
        {
            npp = _npp;
            nama = _nama;
            username = _user;
            password = _pass;
            role = _roles;
        }
        public string NPP
        {
            get
            {
                return npp;
            }

            set
            {
                npp = value;
            }
        }

        public string NAMA
        {
            get
            {
                return nama;
            }

            set
            {
                nama = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }
    }
}
