using System.Net;

namespace _20240105
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\nguyen4\\source\\repos\\20240105\\timetable.csv";

            try
            {
                
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}