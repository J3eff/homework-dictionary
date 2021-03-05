using System;
using System.IO;
using System.Collections.Generic;

namespace HomeWorkDictionary
{
    class Program
    {
        
        static void Main(string[] args)
        {
           Dictionary<string, int> list = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string candidate = line[0];
                        int votes = int.Parse(line[1]);

                        if (list.ContainsKey(candidate))
                        {
                            list[candidate] += votes;
                        }
                        else
                        {
                            list[candidate] = votes;
                        }
                    }                    

                    foreach(var item in list)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }

                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                
            }



        }
    }
}
