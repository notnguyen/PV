using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace _20231215
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n   _______    __   _________ ______    ___   ____ ___  _____\r\n  / ____/ |  / /  <  / ____/<  /__ \\  |__ \\ / __ \\__ \\|__  /\r\n / /    | | / /   / /___ \\  / /__/ /  __/ // / / /_/ / /_ < \r\n/ /___  | |/ /   / /___/ / / // __/_ / __// /_/ / __/___/ / \r\n\\____/  |___/   /_/_____(_)_//____(_)____/\\____/____/____/  \r\n                                                            \r\n");
            Console.WriteLine("__________________________________________");


            var path = @"C:\Users\nguyen4\source\repos\20231215\text.txt";
            string readContents;

            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }

            Console.WriteLine("Hexa Viewer of " + readContents + ":");

            if (File.Exists(path))
            {

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    int c;
                    int i = 0;

                    while ((c = fs.ReadByte()) != -1)
                    {
                        Console.Write("{0:X2} ", c);
                        i++;

                        if (i % 10 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("__________________________________________");

            Uzivatel u1 = new Uzivatel("nkey", "nkey123", "nkey@gmail.com", "111222333"); 
            Uzivatel u2 = new Uzivatel("jamal", "jamal123", "jamal@gmail.com", "444555666"); 
            Uzivatel u3 = new Uzivatel("sir", "sir123", "sir@gmail.com", "777888999"); 
            Uzivatel u4 = new Uzivatel("man", "man123", "man@gmail.com", "888555222");
            Uzivatel u5 = new Uzivatel("more", "more123", "more@gmail.com", "777444111");

            XmlSerializer serializer = new XmlSerializer(typeof(Uzivatel));

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                serializer.Serialize(streamWriter, u1);
            }

            Console.WriteLine("__________________________________________");


        }
    }
}