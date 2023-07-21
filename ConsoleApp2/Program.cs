using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Npgsql;
using System.Collections;
using System.Diagnostics.Metrics;
using Microsoft.VisualBasic.FileIO;
using System.Reflection;

namespace HelloWorld
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=postgres";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            List<string> list = new List<string>();

            using var cmd = new NpgsqlCommand();
            
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM members_member";
            NpgsqlDataReader reader = cmd.ExecuteReader();

            var schema = reader.GetName;

            Console.WriteLine(schema.ToString()); 
            while (reader.Read())
            {
                list.Add(reader.GetString(1).ToString());
            }

            //cmd.ExecuteNonQuery();
            con.Close();

            int listcounter = 0;
            foreach (var i in list) {
                Console.WriteLine(list[listcounter]);
                listcounter++;
            }

            string path = @"F:\C_Sharpe\Files\table.csv";
            string line;
            int counter = 0;
            string[] header;

            if (File.Exists(path))
            {
                //FileStream fileStream = File.OpenRead(path); // or
                //TextReader textReader = File.OpenText(path); // or
                StreamReader sreamReader = new StreamReader(path);

                while ((line = sreamReader.ReadLine()) != null)
                {
                    if (counter == 0)
                    {
                        string[] fields = line.Split(",");
                        int fields_Count = fields.Length;
                        Console.WriteLine(fields_Count);
                        header = fields;
                    }

                    Console.WriteLine(line);
                    counter++;
                }

                sreamReader.Close();

            }


            /*
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Example.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            FileStream fs = File.Open(path, FileMode.Append);
            byte[] information = new UTF8Encoding(true).GetBytes("Hello World!");
            fs.Write(information, 0, information.Length);
            fs.Close();

            StreamReader sr = new StreamReader(path);
            string fileText = sr.ReadToEnd();
            Console.WriteLine(fileText);  
            */

            Action<string> debugTest = (a) => { Console.WriteLine("Hello Lambda World: " + a); };
            Func<int, int, int> multiply = (x, y) => { return x * y; };
            debugTest("here is the test");
            Console.WriteLine(multiply(2, 3));
            


        }

    }
}


