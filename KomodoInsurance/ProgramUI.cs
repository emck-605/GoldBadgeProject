using KomodoInsurancePOCO;
using KomodoInsuranceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void SeedContent()
        {
            Badges badgeOne = new Badges(12345, new List<string> { "A7" });
            Badges badgeTwo = new Badges(22345, new List<string> { "A1, A4, B1, B2" });
            Badges badgeThree = new Badges(32345, new List<string> { "A4, A5" });
            _badgesRepo.AddBadge(badgeOne);
            _badgesRepo.AddBadge(badgeTwo);
            _badgesRepo.AddBadge(badgeThree);
        }
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("------------ Komodo Badge ------------\n" +
                    "\n" +
                    "1. Add a badge\n" +
                    "2. Edit existing badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateAndAddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListOfBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
        }
        public void CreateAndAddBadge()
        {
            Badges content = new Badges();
            content.AccessToDoor = new List<string>();

            Console.Clear();
            Console.WriteLine("--- New Badge ---\n" +
                "\n" +
                "Please enter a new badge number: ");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"--- New Badge ---\n" +
                $"Badge ID: {content.BadgeID}\n");
            Console.WriteLine($"Enter a door the Badge#{content.BadgeID} needs acccess to: \n" +
                $"\n");
            content.AccessToDoor.Add(Console.ReadLine());

            bool yes = true;

            Console.WriteLine($"Door successfully added to Badge#{content.BadgeID}");

            while (yes)
            {
                Console.WriteLine($"Would you like to add another door to Badge# {content.BadgeID}? (y/n)");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                        Console.WriteLine($"Enter a door the Badge# {content.BadgeID} needs access to: ");
                        content.AccessToDoor.Add(Console.ReadLine());
                        break;
                    case "n":
                        yes = false;
                        break;
                }
            }
            _badgesRepo.AddBadge(content);
            Console.Clear();
            Console.WriteLine($"Badge# {content.BadgeID} has been successfully created!" +
                $"\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }
        public void EditBadge()
        {
            Badges content = new Badges();
            content.AccessToDoor = new List<string>();

            Console.Clear();
            Console.WriteLine("Please enter the Badge# you would like to edit: ");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"What would you like to edit for {content.BadgeID}\n" +
                $"\n" +
                $"1. Add a door\n" +
                $"2. Remove a door\n" +
                $"3. Return to menu\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddDoor(content.BadgeID);
                    break;
                case "2":
                    RemoveDoor(content.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
            }
        }
        public void AddDoor(int badgeid)
        {
            Console.WriteLine("Enter a door to add: ");
            string door = Console.ReadLine();
            _badgesRepo.GiveAccess(badgeid, door);

            Console.WriteLine("Door access granted!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void RemoveDoor(int badgeid)
        {
            Console.WriteLine("Enter a door to remove: ");
            string door = Console.ReadLine();
            _badgesRepo.RemoveAccess(badgeid, door);

            Console.WriteLine("Door access has been revoked!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void ListOfBadges()
        {
            Dictionary<int, List<string>> BadgeList = _badgesRepo.GetDictionary();

            Console.WriteLine("------------");
            foreach (KeyValuePair<int, List<string>> badge in BadgeList)
            {
                Console.WriteLine($"Badge: {badge.Key}");
                foreach(string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("------------");
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }
    }
}
