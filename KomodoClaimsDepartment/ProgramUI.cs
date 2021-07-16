using KomodoClaimsDepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoClaimsDepartmentPOCO.ClaimsPOCO;

namespace KomodoClaimsDepartment
{
    public class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void SeedContent()
        {
            Claims claimOne = new Claims(1, TypeOfClaim.Car, "Car accident on 465.", 400, DateTime.Parse("04/25/18"), DateTime.Parse("04/27/18"), true);
            Claims claimTwo = new Claims(2, TypeOfClaim.Home, "House fire in kitchen.", 4000.00m, DateTime.Parse("04/11/18"), DateTime.Parse("04/12/18"), true);
            Claims claimThree = new Claims(3, TypeOfClaim.Theft, "Stolen pancakes.", 4.00m, DateTime.Parse("04/27/18"), DateTime.Parse("06/01/18"), false);
            _claimsRepo.AddClaim(claimOne);
            _claimsRepo.AddClaim(claimTwo);
            _claimsRepo.AddClaim(claimThree);
        }
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("---- Komodo Claims Department Program ----\n" +
                    "\n" +
                    "1. List all claims\n" +
                    "2. Take a new claim\n" +
                    "3. Add a new claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListOfAllClaims();
                        break;
                    case "2":
                        TakeClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        public void ListOfAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimList = _claimsRepo.GetList();
            Console.WriteLine("ClaimID" + "\t\tType" + "\t\tDescription" + "\t\tAmount" + "\t\tDateOfIncident" + "\t\tDateOfClaim" + "\t\tIsValid");
            foreach (Claims content in claimList)
            {
                Console.WriteLine($"{content.ClaimID} \t\t{content.ClaimType} \t\t{content.Description} \t\t{content.ClaimAmount} \t\t{content.DateOfIncident.ToShortDateString()} \t\t{content.DateOfClaim.ToShortDateString()} \t\t{content.IsValid}\n");
            }
            Console.WriteLine("Press and key to continue...");
            Console.ReadKey();
        }
        public void TakeClaim()
        {
            Console.Clear();
            Console.WriteLine("Here is the next claim to be handled: \n");

            Queue<Claims> newList = _claimsRepo.GetList();
            Claims nextClaim = newList.Peek();

            Console.WriteLine($"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Do you want to take this claim? (y/n)");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("You have successfully taken the claim\n" +
                        "Press any key to continue...");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter either y or n");
                    break;
            }
            Console.ReadLine();
        }
        public void AddNewClaim()
        {
            Claims content = new Claims();

            Console.Clear();
            Console.WriteLine($"(ID) \t\t(Type) \t\t(Description) \t\t(Amount) \t\t(Date of Accident) \t\t(Date of Claim) \t\t(Valid?)\n");
            Console.WriteLine("Enter claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) \t\t(Type) \t\t(Description) \t\t(Amount) \t\t(Date of Accident) \t\t(Date of Claim) \t\t(Valid?)\n");
            Console.WriteLine("Enter type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    content.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    content.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    content.ClaimType = TypeOfClaim.Theft;
                    break;
            }
            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) \t\t({content.ClaimType}) \t\t(Description) \t\t(Amount) \t\t(Date of Accident) \t\t(Date of Claim) \t\t(Valid?)\n");
            Console.WriteLine("Enter description of claim: ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) \t\t({content.ClaimType}) \t\t({content.Description}) \t\t(Amount) \t\t(Date of Accident) \t\t(Date of Claim) \t\t(Valid?)\n");
            Console.WriteLine("Enter claim amount: ");
            content.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) \t\t({content.ClaimType}) \t\t({content.Description}) \t\t({content.ClaimAmount}) \t\t(Date of Accident) \t\t(Date of Claim) \t\t(Valid?)\n");
            Console.WriteLine("Enter date of incident: ");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) \t\t({content.ClaimType}) \t\t({content.Description}) \t\t({content.ClaimAmount}) \t\t({content.DateOfIncident}) \t\t(Date of Claim) \t\t(Valid?)\n");
            Console.WriteLine("Enter date of claim: ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimsRepo.IsValid(content);

            Console.Clear();
            Console.WriteLine($"You are about to add a claim: \n" +
                $"\n" +
                $"ID: {content.ClaimID}\n" +
                $"Type: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: {content.ClaimAmount}\n" +
                $"Date of Incident: {content.DateOfIncident}\n" +
                $"Date of Claim: {content.DateOfClaim}\n" +
                $"Valid: {content.IsValid}\n" +
                $"\n" +
                $"Press Enter to add claim");
            Console.ReadKey();

            _claimsRepo.AddClaim(content);

            Console.Clear();
            Console.WriteLine("Claim successfully added!\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
    }
}
