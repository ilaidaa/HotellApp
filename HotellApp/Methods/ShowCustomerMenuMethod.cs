using HotellApp.Methods;
using HotellApp.Context; 
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp
{
    internal class ShowCustomerMenuMethod
    {

        // Metod som ska hantera "Hantera Kunder" alternativet i huvudmenyn Meny
        public static void ShowCustomerMenu(Classes.HotelManager hotelManager, ApplicationDbContext dbContext)  // Metoden måste ha public i början så man kan anropa den i Program fliken
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("|\t1. Lägg till ny kund         |");
            Console.WriteLine("|\t2. Ändra kunduppgifter       |");
            Console.WriteLine("|\t3. Ta bort kund              |");
            Console.WriteLine("|\t4. Återvänd till Huvudmeny   |");
            Console.WriteLine("|\t                             |");
            Console.WriteLine("======================================");


            // Ska bestämmas i while loopen när användaren ger svar men nu deklarerar jag bara så vi kan ändra värdet beroende på vad anvndaren säger
            int choice;

            // Hantera om användaren skriver fel siffra
            while (true)
            {
                // Fråga om inpput
                Console.WriteLine();
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 4 && choice >= 1)
                {
                    break; // Bryt loopen så du kan gå t switchen
                }

                Console.WriteLine("Vänligen välj en siffra från menyn 1 - 4.");
               
            }

            // Hantera kundens önskemål i submenyn beroende på vad hen vlt genom submeny
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    // Ta emot nya kundens namn
                    Console.Write("Ange kundens namn (Ex: Anna Lindborg) : ");

                    string? newCustomerName = Console.ReadLine();

                    // Hantera ? och samtidigt kolla om namn redan finns i hotelManager klasens Customers lista och om så fallet be användren byta namn
                    while (string.IsNullOrWhiteSpace(newCustomerName) || dbContext.Customers.Any(c => c.Name == newCustomerName))
                    {
                        Console.WriteLine();
                        Console.Write("Du skrev ett ogiltigt namn / Kunden är redan registrerad. Vänligen skriv in en ny kund / giltigt namn (Ex: Anna Lindborg): ");
                        newCustomerName = Console.ReadLine();
                    }



                    // Ta emot nya kundens epost             
                    Console.Write("Ange kundens epost (Ex: AnnaLindborg@hotmail.com): ");
                    string? newCustomerMail = Console.ReadLine();
                    // Hantera ?
                    while (string.IsNullOrWhiteSpace(newCustomerMail))
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen ange en giltig e-postadress (Ex: AnnaLindborg@hotmail.com): ");
                        newCustomerMail = Console.ReadLine();
                    }


                    // Ta emot nya kundens mobil nr             
                    Console.Write("Ange kundens telefonnummer (Ex: 0764556227): ");
                    string? newCustomerNumber = Console.ReadLine();
                    // Hantera ?
                    while (string.IsNullOrWhiteSpace(newCustomerNumber))
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen ange en giltig telefonnummer (Ex: 0764556227): ");
                        newCustomerNumber = Console.ReadLine();
                    }



                    // Skapa självaste nya kunden
                    var newCustomer = new Classes.Customer(0, newCustomerName, newCustomerMail, newCustomerNumber);
                    // DB ändring!
                    dbContext.Customers.Add(newCustomer);
                    dbContext.SaveChanges();
                    // Lägg till kunden i Customers listan i hotelMAnager klassen genom att använda AddCustomer metoden som finns i HotelMAnager klassen
                    
                    Console.WriteLine(); // Design
                    Console.WriteLine($"Kunden {newCustomerName} har lagts till.");

                    break;


                case 2:
                    Console.Write("Vänligen ange kundnamnet för den kund du vill ändra uppgifter på (Ex: Ali Chuba): ");
                    string? customerToEditName = Console.ReadLine();

                    var customersToEdit = dbContext.Customers.FirstOrDefault(c => c.Name == customerToEditName); // DB: hämta från DB

                    // Hantera ? och kolla om kunden ens finns i Cutomer listan i hotelmanager klassen
                    while (string.IsNullOrWhiteSpace(customerToEditName) || customersToEdit == null) // Eftersom att vi använde FirstOFDefault måste vi hantera null
                    {
                        Console.WriteLine();
                        Console.Write("Ogiltigt namn / Kunden existerar inte. Vänligen skriv in ett giltigt namn eller en kund som existerar (Ex: Ali Chuba): ");
                        customerToEditName = Console.ReadLine();

                        customersToEdit = dbContext.Customers.FirstOrDefault(c => c.Name == customerToEditName); // DB: uppdatera sökning
                    }


                    // Ge alternativ på det som användaren kan ändra hos kunden
                    Console.WriteLine();
                    Console.WriteLine("1. Ändra Kundnamn (Ex: Ali Chuba) ");
                    Console.WriteLine("2. Ändra Kundmail (Ex: Ali@hotmail.com) ");
                    Console.WriteLine("3. Ändra Kundnummer (Ex: 0764556227) ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                    // Ta emot användarens input men den är i string
                    string? inputChoice = Console.ReadLine();

                    // Skapa en int variabel som kan behålla värdet av inputChoice och som du ska konvertera till
                    int userChoice;

                    // Hantera ? och konvertering och max siffror i menyn vilket är 1-3
                    while (!int.TryParse(inputChoice.ToLower(), out userChoice) || userChoice < 1 || userChoice > 3) // ToLower gör så att alla bokstäver skriv in i små bokstäver även om användaren råkar skriva i caps lock
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen skriv in ett giltigt svar mellan 1 - 3: ");
                        inputChoice = Console.ReadLine();
                    }

                    //Gör en switch sats som hanterar alla saker man kan ändra
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.Write($"Nuvarande kundnamn är {customersToEdit.Name}. Skriv in det namn du vill ändra till: ");
                            string? changedCustomerName = Console.ReadLine();

                            // Hantera ? och att namnet som väljs inte finns i hotelManagers Customer lista
                            while (string.IsNullOrWhiteSpace(changedCustomerName) || dbContext.Customers.Any(n => n.Name == changedCustomerName))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen skriv in ett giltigt namn eller ett namn som inte redan finns i listan (Ex: Maja Karlsson): ");
                                changedCustomerName = Console.ReadLine();
                            }

                            // Spara nya namnet
                            customersToEdit.Name = changedCustomerName;

                            // Meddela användaren om ändringen i kundens namn
                            Console.WriteLine($"Kundens namn har uppdaterats till {changedCustomerName}.");
                            break;


                        case 2:
                            Console.WriteLine();
                            Console.Write($"Nuvarande kundmail är {customersToEdit.Email}. Skriv in det namn du vill ändra till: ");
                            string? changedCustomerEmail = Console.ReadLine();

                            // Hantera ? men i denna case jämfört med första, behöver du inte se till att mejlen finns i Custoemrs listan för du har redan checkat namnet
                            while (string.IsNullOrWhiteSpace(changedCustomerEmail))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen skriv in en giltigt email (Ex: MajaKarlsson@hotmail.com): ");
                                changedCustomerName = Console.ReadLine();
                            }

                            // Spara nya email adressen
                            customersToEdit.Email = changedCustomerEmail;

                            // Meddela användaren om ändringen i kundens namn
                            Console.WriteLine($"Kundens email har uppdateras till {changedCustomerEmail}");
                            break;


                        case 3:
                            Console.WriteLine();
                            Console.Write($"Nuvarande kundnummer är {customersToEdit.PhoneNumber}. Skriv in det nummer du vill ändra till: ");
                            string? changedCustomerPhoneNumber = Console.ReadLine();

                            while (string.IsNullOrWhiteSpace(changedCustomerPhoneNumber))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen skriv in ett giltigt telefonnummer (Ex: 0763999550: ");
                                changedCustomerPhoneNumber = Console.ReadLine();
                            }

                            // Spara nya kundnumret 
                            customersToEdit.PhoneNumber = changedCustomerPhoneNumber;

                            // Meddela användaren
                            Console.WriteLine($"Kundens telefonnummer har uppdateras till {changedCustomerPhoneNumber}");

                            // DB: Spara ändringarna
                            dbContext.Customers.Update(customersToEdit);
                            dbContext.SaveChanges();
                            break;
                    }
                    break;



                case 3:
                    Console.Write("Vänligen ange kundnamnet för den kund du vill ta bort på (Ex: Karin Björk): ");
                    // Ta emot input
                    string? customerBeingDeleted = Console.ReadLine();

                    // Hantera ? och kolla om namnet användaren vill tabort finns i hotelManager klassens Customers lista
                    while (string.IsNullOrWhiteSpace(customerBeingDeleted.ToLower()) || !dbContext.Customers.Any(c => c.Name == customerBeingDeleted)) // ToLower för att göra alla bokstäver småa ifall användarn skiver såhär --> kAriN
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen skriv in ett giltigt namn eller ett kundnamn som finns registrerat: ");
                        customerBeingDeleted = Console.ReadLine();
                    }

                   // DB
                    var customerDeleted = dbContext.Customers.First(c => c.Name == customerBeingDeleted);

                    // Tabort personen nu från CustomersListan
                    dbContext.Customers.Remove(customerDeleted);
                    dbContext.SaveChanges();

                    // Meddela kunden om ändringen
                    Console.WriteLine($"Kunden {customerBeingDeleted} har tagits bort.");
                    break;


                case 4:
                    ReturnToMainMenuMethod.ReturnToMainMenu();
                    break;
            }


        }

    }
}
