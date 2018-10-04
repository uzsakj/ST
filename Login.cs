using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szerviz
{
    class Login
    {
        private User user;
        private bool loggedin = false;
        public Login(string id, string password)
        {
            login(id, password);
        }
        public void login(string id, string password)
        {
            StreamReader sr = new StreamReader("C:/Users/József/Desktop/Data/authentication.txt");
            while (!sr.EndOfStream)
            {
                string[] logdat = sr.ReadLine().Split(' ');
                if (logdat[0] == id && logdat[1] == password)
                {
                    loggedin = true;
                    loguser(Convert.ToInt32(logdat[2]));
                    break;
                }
            }
        }
        private void loguser(int jog)
        {
            switch (jog)
            {
                case 1: user = new Admin(this); break;
                case 2: user = new Fonok(this); break;
            }
        }
        public bool GetLoggedin()
        {
            return loggedin;
        }
        public User GetUser()
        {
            return user;
        }
    }
}
