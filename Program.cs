using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Szerviz
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string username;
            string password;

            Console.Clear();
            Console.Write("Username:");
            username = Console.ReadLine();
            Console.Write("Password:");
            password = Console.ReadLine();

            Login login = new Login(username, password);
            do
            {
                if (login.GetLoggedin())
                {
                    User user = login.GetUser();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("incorrect id and pw");
                    Console.Write("Username:");
                    username = Console.ReadLine();
                    Console.Write("Password:");
                    password = Console.ReadLine();
                    login.login(username, password);
                }
            }
            while (!login.GetLoggedin());
            Console.ReadLine();

        }

    }

}
