using System;

namespace Szerviz
{
    class Fonok : User
    {

        public Fonok(Login log)
        {
            Console.Clear();
            Console.WriteLine("Welcome fonok");
            parancsok();
        }



        public override void parancs(int num)
        {
            if (num == 4)
            {
                Environment.Exit(0);
            }
            if (num == 3)
            {
                Console.Clear();
                parancsok();
            }
        }

        public override void parancsok()
        {
            Console.WriteLine("{1}");
            Console.WriteLine("{2}");
            Console.WriteLine("{3}Back to menu.");
            Console.WriteLine("{4}Exit.");
        }

        // You can replace the method using override

    }
}
