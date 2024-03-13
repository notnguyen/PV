namespace PVDatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ProductDao productDao = new ProductDao();

            Menu menu = new Menu();
            menu.ShowMenu();


            /*
            foreach (var product in productDao.GetAll())
            {
                Console.WriteLine(product);
            }*/







        }
    }
}
