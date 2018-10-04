
using System;
using System.IO;
using System.Linq;

namespace Szerviz
{
    abstract class User
    {
        public string Name { get; set; }


        public bool succesrefresh = false;

        public abstract void parancsok();
        public abstract void parancs(int num);
        public string List(string which)
        {
            string lista = "";
            StreamReader sr = new StreamReader(@"C:\Users\József\Desktop\Data\worksheets"+which+".txt");
            while (!sr.EndOfStream)
            {
            
               lista += sr.ReadLine()+Environment.NewLine ;
            }
            sr.Close();
            return lista;

        }
        
        public void CreateNewWorkSheet()
        {

            Console.Write("Munkalaphoz tartozó rendszám:");
            string rendszam = Console.ReadLine();
            string name = "Worksheet-" + rendszam;

            string kiterjesztes = ".txt";
            string path = "C:/Users/József/Desktop/Data/Worksheets/Worksheet_undone/";
            string date = DateTime.Now.ToString("yyyy/MM/dd"); // includes leading zeros
            string text = "renszam: " + rendszam +Environment.NewLine+"||" +Environment.NewLine+"munkalap létrehozva: " + date;
            text = text.Replace("\n", Environment.NewLine);
            TextWriter tw = new StreamWriter(path + name + kiterjesztes);
            tw.WriteLine(text);
            tw.Close();



            Console.WriteLine("Worksheet created with the path of:" + path + name + kiterjesztes);
            AddtoList(name,null);
            AddtoList(name,"_undone");
            parancsok();

        }
        public void AddtoList(string wsName,string toList)
        {
            string lista = List(toList) + wsName+" ";
            lista = lista.Replace(" ", Environment.NewLine);
            refreshlist(lista,toList);
        }
        public bool refreshlist(string lista,string toList)
        {
            TextWriter tw = new StreamWriter("C:/Users/József/Desktop/Data/worksheets"+toList+".txt");
            lista=lista.Replace(Environment.NewLine+ Environment.NewLine, Environment.NewLine);
            tw.Write(lista);
            tw.Close();
            succesrefresh = true;
            return succesrefresh;

        }
        public void DeleteWsfile(string name,string from)
        {
            string path0 = "C:/Users/József/Desktop/Data/Worksheets/Worksheet"+from+"/" + name + ".txt";
            if (File.Exists(path0))
            {
                System.IO.File.Delete(path0);
            }
        }
        public void DeleteWs(string name,string toList,string from)
        {
            string lista =List(toList).Replace(name,String.Empty).Replace(Environment.NewLine+Environment.NewLine,Environment.NewLine);

            if (refreshlist(lista,toList))
            {
                Console.Clear();
                Console.WriteLine("{0} Removed from the list of Ws", name);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong...");
            }
            DeleteWsfile(name,from);
     
        }
        public void Statistics()
        {
            Console.WriteLine("{1}Number of current Works");
            Console.WriteLine("Statisztika 2");
            Console.WriteLine("Statisztika 3");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:Console.Clear();Console.WriteLine("{1}Number of Undone Works");Console.WriteLine("{2}Number of Done Works");switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:Console.Clear(); Console.WriteLine("{0} Undone Worksheets found",CountWorks("_Undone"));Console.WriteLine(List("_undone"));Console.ReadLine();Console.Clear();parancsok(); break;
                        case 2:Console.Clear(); Console.WriteLine("{0} Done Worksheets found", CountWorks("_Done")); Console.WriteLine(List("_done")); Console.ReadLine();Console.Clear();parancsok(); break;
    } break;
            }
            
        }
        public int CountWorks(string list)
        {
            int counter = 0;
            string path ="C:/Users/József/Desktop/Data/Worksheets/Worksheet"+list+"/";
            counter = (from file in Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories) select file).Count();
            return counter;

        }
        public void ChangeStatus(string name,string toList)
        {
            AddtoList(name, toList);
            string text = "";
            TextWriter tw = new StreamWriter("C:/Users/József/Desktop/Data/Worksheets/Worksheet_Done/" + name +".txt");
            StreamReader sr = new StreamReader("C:/Users/József/Desktop/Data/Worksheets/Worksheet_Undone/"+name +".txt");
            while (!sr.EndOfStream)
            {
               text += sr.ReadLine();
            }
            tw.WriteLine(text);
            tw.Close();
            sr.Close();
            DeleteWs(name, "_undone","_Undone");
        }

    }
}