using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCsharp.Model
{
    public class Login
    {
        private string loginId;
        private string loginPassword;
        private int roles;

        public Login(string loginId,string loginPassword, int roles)
        {
            LoginId = loginId;
            LoginPassword = loginPassword;
            Roles = roles;
        }


        public string LoginId
        {
            get
            {
                return loginId;
            }

            set
            {
                loginId = value;
            }
        }

        public string LoginPassword
        {
            get
            {
                return loginPassword;
            }

            set
            {
                loginPassword = value;
            }
        }

        public int Roles
        {
            get
            {
                return roles;
            }

            set
            {
                roles = value;
            }
        }
    }
}
