using System.Diagnostics.Metrics;

namespace _20231222
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\nguyen4\\source\\repos\\20231222\\text.txt";

            using (StreamWriter sw = new StreamWriter(file))
            {
                Console.WriteLine("Sign in");
                string username = Console.ReadLine();
                string password = Console.ReadLine();

                sw.WriteLine(username + ":" + password);
            }

            using (StreamReader sr = new StreamReader(file))
            {
                Console.WriteLine("Log in");
                string user = Console.ReadLine();
                string pass = Console.ReadLine();


                string line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split(':');
                    string First = split[0];
                    string Second = split[1];

                    Console.WriteLine(First + ":" + Second);

                }

                

            }

            


            































        }
    }
}