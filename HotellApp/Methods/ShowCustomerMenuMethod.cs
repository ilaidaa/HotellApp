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
        public static void ShowCustomerMenu(Classes.HotelManager hotelManager)  // Metoden måste ha public i början så man kan anropa den i Program fliken
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
                Console.Write("Vänligen välj ett alternativ genom att skriva in siffran för det val du önskar och tryck på Enter: ");

                // Lagra input
                string? input = Console.ReadLine();
                Console.WriteLine();

                // Hantera ? och om det är mer eller mindre än 5
                if (int.TryParse(input, out choice) && choice <= 5 && choice >= 1)
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
                    Console.WriteLine();

                    // Hantera ? och samtidigt kolla om namn redan finns i hotelManager klasens Customers lista och om så fallet be användren byta namn
                    while (string.IsNullOrWhiteSpace(newCustomerName) || hotelManager.Customers.Any(c => c.Name == newCustomerName))
                    {
                        Console.WriteLine();
                        Console.Write("Du skrev ett ogiltigt namn / Kunden är redan registrerad. Vänligen skriv in en ny kund / giltigt namn (Ex: Anna Lindborg): ");
                        newCustomerName = Console.ReadLine();
                    }



                    // Ta emot nya kundens epost             
                    Console.Write("Ange kundens epost (Ex: AnnaLindborg@hotmail.com): ");

                    string? newCustomerMail = Console.ReadLine();
                    Console.WriteLine();

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
                    Console.WriteLine();

                    // Hantera ?
                    while (string.IsNullOrWhiteSpace(newCustomerNumber))
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen ange en giltig telefonnummer (Ex: 0764556227): ");
                        newCustomerNumber = Console.ReadLine();
                    }


                    // Skapa ett ID nummer till den nya kunden
                    // du skapar ett nytt Id via variabeln nesCustomerID
                    // du letar i HotelManager klassens Customers lista och
                    // Count liksom räknar alla kunder som redan finns i listan och + 1 lägger till nästa lediga plats
                    int newCustomerID = hotelManager.Customers.Count + 1;

                    // Skapa självaste nya kunden
                    var newCustomer = new Classes.Customer(newCustomerID, newCustomerName, newCustomerMail, newCustomerNumber);

                    // Lägg till kunden i Customers listan i hotelMAnager klassen genom att använda AddCustomer metoden som finns i HotelMAnager klassen
                    hotelManager.AddCustomer(newCustomer);

                    //Skriv meddelande till användaren om att kunden lagts till
                    Console.WriteLine($"Ny kund {newCustomerName} har lagts till. ");
                    break;


                case 2:
                    Console.Write("Vänligen ange kundnamnet för den kund du vill ändra uppgifter på (Ex: Ali Chuba): ");

                    string? customerToEditName = Console.ReadLine();

                    // Hantera ? och kolla om kunden ens finns i Cutomer listan i hotelmanager klassen
                    while (string.IsNullOrWhiteSpace(customerToEditName) || !hotelManager.Customers.Any(c => c.Name == customerToEditName))
                    {
                        Console.WriteLine();
                        Console.Write("Ogiltigt namn / Kunden existerar inte. Vänligen skriv in ett giltigt namn eller en kund som existerar (Ex: Ali Chuba): ");
                        customerToEditName = Console.ReadLine();
                    }

                    // Hämta det faktiska Customer-objektet
                    // för customerToEditName är bara namnet i STRING som användaren vill ändra
                    var customerToEdit = hotelManager.Customers.First(c => c.Name == customerToEditName); // First hittar första matchande värde


                    // Ge alternativ på det som användaren kan ändra hos kunden
                    Console.WriteLine();
                    Console.WriteLine("1. Kundnamn (Ex: Ali Chuba) ");
                    Console.WriteLine("2. Kundmail (Ex: Ali@hotmail.com) ");
                    Console.WriteLine("3. Kundnummer (Ex: 0764556227) ");
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
                            Console.Write($"Nuvarande kundnamn är {customerToEdit.Name}. Skriv in det namn du vill ändra till: ");

                            string? changedCustomerName = Console.ReadLine();

                            // Hantera ? och att namnet som väljs inte finns i hotelManagers Customer lista
                            while (string.IsNullOrWhiteSpace(changedCustomerName) || hotelManager.Customers.Any(n => n.Name == changedCustomerName))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen skriv in ett giltigt namn eller ett namn som inte redan finns i listan (Ex: Maja Karlsson): ");
                                changedCustomerName = Console.ReadLine();
                            }

                            // Spara nya namnet
                            customerToEdit.Name = changedCustomerName;

                            // Meddela användaren om ändringen i kundens namn
                            Console.WriteLine($"Kundens namn har uppdaterats till {changedCustomerName}.");
                            break;


                        case 2:
                            Console.WriteLine();
                            Console.Write($"Nuvarande kundmail är {customerToEdit.Email}. Skriv in det namn du vill ändra till: ");

                            string? changedCustomerEmail = Console.ReadLine();

                            // Hantera ? men i denna case jämfört med första, behöver du inte se till att mejlen finns i Custoemrs listan för du har redan checkat namnet
                            while (string.IsNullOrWhiteSpace(changedCustomerEmail))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen skriv in en giltigt email (Ex: MajaKarlsson@hotmail.com): ");
                                changedCustomerName = Console.ReadLine();
                            }

                            // Spara nya email adressen
                            customerToEdit.Email = changedCustomerEmail;

                            // Meddela användaren om ändringen i kundens namn
                            Console.WriteLine($"Kundens email har uppdateras till {changedCustomerEmail}");
                            break;


                        case 3:
                            Console.WriteLine();
                            Console.Write($"Nuvarande kundnummer är {customerToEdit.PhoneNumber}. Skriv in det nummer du vill ändra till: ");

                            string? changedCustomerPhoneNumber = Console.ReadLine();

                            while (string.IsNullOrWhiteSpace(changedCustomerPhoneNumber))
                            {
                                Console.WriteLine();
                                Console.Write("Vänligen skriv in ett giltigt telefonnummer (Ex: 0763999550: ");
                                changedCustomerPhoneNumber = Console.ReadLine();
                            }

                            // Spara nya kundnumret 
                            customerToEdit.PhoneNumber = changedCustomerPhoneNumber;

                            // Meddela användaren
                            Console.WriteLine($"Kundens telefonnummer har uppdateras till {changedCustomerPhoneNumber}");
                            break;
                    }
                    break;



                case 3:
                    Console.Write("Vänligen ange kundnamnet för den kund du vill ta bort på (Ex: Karin Björk): ");

                    // Ta emot input
                    string? customerBeingDeleted = Console.ReadLine();

                    // Hantera ? och kolla om namnet användaren vill tabort finns i hotelManager klassens Customers lista
                    while (string.IsNullOrWhiteSpace(customerBeingDeleted.ToLower()) || !hotelManager.Customers.Any(c => c.Name == customerBeingDeleted)) // ToLower för att göra alla bokstäver småa ifall användarn skiver såhär --> kAriN
                    {
                        Console.WriteLine();
                        Console.Write("Vänligen skriv in ett giltigt namn eller ett kundnamn som finns registrerat: ");
                        customerBeingDeleted = Console.ReadLine();
                    }

                    // Skapa en Customer objekt av stringen customerBeingDeleted för att vi ska kunna tabort den från listan, nu är d ju bara en string
                    var customerDeleted = hotelManager.Customers.Find(c => c.Name == customerBeingDeleted);

                    // Tabort personen nu från CustomersListan
                    hotelManager.Customers.Remove(customerDeleted);

                    // Meddela kunden om ändringen
                    Console.WriteLine($"Kunden {customerBeingDeleted} har tagits bort.");
                    break;


                case 4:
                    Program.ReturnToMainMenu();
                    break;
            }


        }

    }
}
