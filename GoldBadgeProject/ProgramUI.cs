using KomodoCafePOCO;
using KomodoCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeProject
{
    public class ProgramUI
    {
        private CafeRepo _cafeRepo = new CafeRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void SeedContent()
        {
            CafeMenu hotDog = new CafeMenu(1, "Hot Dog", "Hot Dog with your choice of toppings.", "hot dog inside of a fresh bun with a choice of ketchup, mustard, relish, and/or chili sauce.");
            CafeMenu cheeseBurger = new CafeMenu(2, "Cheeseburger", "Delicious cheeseburger made fresh with your choice of toppings.", "hamburger patty between fresh buns with a choice of ketchup, mustard, mayonaise, lettuce, tomato, and/or pickle");
            CafeMenu macNCheese = new CafeMenu(3, "Mac n Cheese", "Made just right is our amazing mac n cheese.", "noodles and cheese");

            _cafeRepo.AddItem(hotDog);
            _cafeRepo.AddItem(cheeseBurger);
            _cafeRepo.AddItem(macNCheese);
        }
        private void RunMenu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("------------ Welcome to Komodo Cafe! ------------\n" +
                    "\n" +
                    "1. List of all items\n" +
                    "2. Add an item\n" +
                    "3. Remove an item\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListOfAllItems();
                        break;
                    case "2":
                        AddAnItem();
                        break;
                    case "3":
                        RemoveAnItem();
                        break;
                    case "4":
                        continueRunning = false;
                        break;
                }
            }
        }
        public void ListOfAllItems()
        {
            List<CafeMenu> ItemList = _cafeRepo.ListItems();
            
            foreach(CafeMenu content in ItemList)
            {
                Console.WriteLine($"#{content.ItemNumber} {content.Name}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {content.Ingredients}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.ReadLine();
        }
        public void AddAnItem()
        {
            CafeMenu content = new CafeMenu();

            Console.Clear();
            Console.WriteLine("(ID) \t\t(Name) \t\t(Description) \t\t(Ingredients)\n");
            Console.WriteLine("Enter the new item number: ");
            content.ItemNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) \t\t(Name) \t\t(Description) \t\t(Ingredients)\n");
            Console.WriteLine("Enter the item's name: ");
            content.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) \t\t({content.Name}) \t\t(Description) \t\t(Ingredients)\n");
            Console.WriteLine($"Enter a description for {content.Name}: ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) \t\t({content.Name}) \t\t({content.Description}) \t\t(Ingredients)\n");
            Console.WriteLine($"Enter the ingredients for {content.Name}: ");
            content.Ingredients = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Item Summary:\n");
            Console.WriteLine($"Item Number: {content.ItemNumber}\n" +
                $"Name: {content.Name}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredients: {content.Ingredients}\n");
            Console.WriteLine("Press Enter to confirm order");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Item successfully added!\n" +
                "Press any key to continue...");
            _cafeRepo.AddItem(content);
        }
        public void RemoveAnItem()
        {
            Console.WriteLine("What item would you like to remove?\n" +
                "(Select by item number)");
            List<CafeMenu> ItemList = _cafeRepo.ListItems();

            foreach (CafeMenu item in ItemList)
            {
                Console.WriteLine($"#{item.ItemNumber} - {item.Name}\n");
            }

            int numRemove = int.Parse(Console.ReadLine());

            CafeMenu menuItem = _cafeRepo.FindItemByID(numRemove);

            _cafeRepo.RemoveItem(menuItem);

            Console.WriteLine("Item successfully removed!\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
