using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_2._0
{
    public class Menu
    {
        private Dictionary<string, List<string>> menu = new Dictionary<string, List<string>>();
        private HashSet<string> filledMenus = new HashSet<string>();

        /// <summary>
        /// Initializes the UIMenu with predefined options.
        /// </summary>
        public Menu()
        {
            menu["Role"] = new List<string> {
                "1) Customer",
                "2) Admin",
                "3) UKONČIT"
            };

            menu["Enter"] = new List<string> {
                "1) Sign Up",
                "2) Log In",
                "3) UKONČIT"
            };

            menu["Main"] = new List<string> {
                "1) PŘIDAT",
                "2) AKTUALIZOVAT",
                "3) SMAZAT",
                "4) VYPSAT VŠECHNY",
                "5) SMAZAT VŠECHNY",
                "6) UKONČIT"
            };

            menu["AdminAdd"] = new List<string> {
                "1) Přidat Book",
                "2) Přidat Customer",
                "3) Přidat Order",
                "4) Přidat OrderBook",
                "5) Přidat Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["AdminUpdate"] = new List<string> {
                "1) Aktualizovat Book",
                "2) Aktualizovat Customer",
                "3) Aktualizovat Order",
                "4) Aktualizovat OrderBook",
                "5) Aktualizovat Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["AdminDelete"] = new List<string> {
                "1) Smazat Book",
                "2) Smazat Customer",
                "3) Smazat Order",
                "4) Smazat OrderBook",
                "5) Smazat Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["AdminListAll"] = new List<string> {
                "1) Vypsat všechny Book",
                "2) Vypsat všechny Customer",
                "3) Vypsat všechny Order",
                "4) Vypsat všechny OrderBook",
                "5) Vypsat všechny Address",
                "6) Přidat Supplier",
                "7) Vypsat všechny tabulky",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["AdminDeleteAll"] = new List<string> {
                "1) Smazat všechny Book",
                "2) Smazat všechny Customer",
                "3) Smazat všechny Order",
                "4) Smazat všechny OrderBook",
                "5) Smazat všechny Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["CustomerAdd"] = new List<string> {
                "1) Přidat Book",
                "2) Přidat Customer",
                "3) Přidat Order",
                "4) Přidat OrderBook",
                "5) Přidat Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["CustomerUpdate"] = new List<string> {
                "1) Aktualizovat Book",
                "2) Aktualizovat Customer",
                "3) Aktualizovat Order",
                "4) Aktualizovat OrderBook",
                "5) Aktualizovat Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["CustomerDelete"] = new List<string> {
                "1) Smazat Book",
                "2) Smazat Customer",
                "3) Smazat Order",
                "4) Smazat OrderBook",
                "5) Smazat Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["CustomerListAll"] = new List<string> {
                "1) Vypsat všechny Book",
                "2) Vypsat všechny Customer",
                "3) Vypsat všechny Order",
                "4) Vypsat všechny OrderBook",
                "5) Vypsat všechny Address",
                "6) Přidat Supplier",
                "7) Vypsat všechny tabulky",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };

            menu["CustomerDeleteAll"] = new List<string> {
                "1) Smazat všechny Book",
                "2) Smazat všechny Customer",
                "3) Smazat všechny Order",
                "4) Smazat všechny OrderBook",
                "5) Smazat všechny Address",
                "6) Přidat Supplier",
                "7) NÁVRAT DO HLAVNÍHO MENU"
            };
        }

        /// <summary>
        /// Prints the specified menu to the console.
        /// </summary>
        /// <param name="menuName">The name of the menu to print.</param>
        private void PrintMenu(string menuName)
        {
            if (!filledMenus.Contains(menuName))
            {
                filledMenus.Add(menuName);
            }

            if (menu.ContainsKey(menuName))
            {
                foreach (string item in menu[menuName])
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Menu nenalezeno.");
            }
        }

        public void PrintRoleMenu() => PrintMenu("Role");
        public void PrintEnterMenu() => PrintMenu("Enter");
        public void PrintMainMenu() => PrintMenu("Main");
        public void PrintAddMenu() => PrintMenu("CustomerAdd");
        public void PrintUpdateMenu() => PrintMenu("CustomerUpdate");
        public void PrintDeleteMenu() => PrintMenu("CustomerDelete");
        public void PrintListAllMenu() => PrintMenu("CustomerListAll");
        public void PrintDeleteAllMenu() => PrintMenu("CustomerDeleteAll");
    }
}
