using System;
using System.IO;
using System.Collections.Generic;

namespace Szerviz
{
    class Admin : User
    {
  

        public Admin(Login log)
        {
            Console.Clear();
            Console.WriteLine("Welcome Admin");
            parancsok();
        }
        public override void parancsok()
        {
            Console.WriteLine("{1}Create Worksheet");
            Console.WriteLine("{2}List All WorkSheets");
            Console.WriteLine("{3}List UnDone Worksheets");
            Console.WriteLine("{4}List Done Worksheets");
            Console.WriteLine("{5}Mark WorkSheet as Done");
            Console.WriteLine("{6}Delete worksheet.");
            Console.WriteLine("{7}Statistics");
            Console.WriteLine("{8}Exit.");
            parancs(Convert.ToInt16(Console.ReadLine()));
        }


        public override void parancs(int num)
        {
            switch(num)
            {
                case 1: {
                        Console.Clear();
                        CreateNewWorkSheet();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Existing Worksheets:");
                        
                        foreach (string item in List(null))
                        {
                            Console.WriteLine(item);
                        }
                            parancsok();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine(List("_undone"));
                        parancsok();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Done Worksheets:");
                        Console.WriteLine(List("_done"));
                        parancsok();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        Console.WriteLine("Undone WorkSheets:");
                        Console.WriteLine(List("_undone"));
                        Console.Write("Type the name of the Worksheet you want to mark as done:");
                        ChangeStatus(Console.ReadLine(), "_done");
                        parancsok();
                        break;
                    }
                case 6:
                    {
                        Console.Clear();
                        Console.WriteLine("Existing WorkSheets:");
                        Console.WriteLine(List(null));
                        Console.Write("Type the name of the Worksheet your want to delete: ");
                        string name = Console.ReadLine();DeleteWs(name, null,"");
                        DeleteWs(name, "_done","_Done");
                        DeleteWs(name, "_undone","_Undone");
                        parancsok();
                        break;
                    }
                case 7:
                    {
                        Console.Clear();
                        Statistics();
                        break;
                    }
                case 8:
                    {
                        Environment.Exit(0);
                        break; }
            }
            
        }
    }
}

