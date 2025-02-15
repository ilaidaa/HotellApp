using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp
{
    // Rums klassen
    public class Room
    {
        // Skapa properties
        public int Id { get; set; } // Unikt ID för varje rum
        public string RoomName { get; set; } // Namn på rummet (ex. "Rum 101")
        public string RoomType { get; set; } // "Enkelrum" eller "Dubbelrum"
        public int ExtraBeds { get; set; } //  extrasängar
        public bool IsAvailable { get; set; } // Är rummet ledigt?
        public List<Booking> Bookings { get; set; } = new List<Booking>(); // Lista över bokningar

        // Konstruktor för att skapa ett nytt rum
        public Room(int id, string roomName, string roomType, int extraBeds)
        {
            Id = id;
            RoomName = roomName;
            RoomType = roomType;
            ExtraBeds = extraBeds;
            IsAvailable = true;
        }

    }









    // Kund Klassen
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(int id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phone;
        }
    }












        // Boknings Klassen
       public class Booking
        {
            public DateTime StartDate { get; set; } // Startdatum för bokningen
            public DateTime EndDate { get; set; } // Slutdatum
            public Customer Customer { get; set; } // Kunden som bokar
            public Room BookedRoom { get; set; }



            // Konstruktorrr
            public Booking(DateTime start, DateTime end, Customer customer, Room bokedRoom)
            {
                StartDate = start;
                EndDate = end;
                Customer = customer;
                BookedRoom = BookedRoom;
            }

            // Kontrollera om bokningen överlappar en annan bokning
            public bool IsOverlapping(DateTime start, DateTime end)
            {
                return (start < EndDate && end > StartDate);
            }
        }








    // Hotell Manager Klassen
    public class HotelManager
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public HotelManager()
        {
            SeedData();
        }

        // Seeda rum och kunder
        private void SeedData()
        {
            Rooms.Add(new Room(1, "Rum 101", "Enkelrum", 0));
            Rooms.Add(new Room(2, "Rum 102", "Dubbelrum", 1));
            Rooms.Add(new Room(3, "Rum 103", "Dubbelrum", 2));
            Rooms.Add(new Room(4, "Rum 104", "Enkelrum", 0));

            Customers.Add(new Customer(1, "Alice Karlsson", "alice@example.com", "0701234567"));
            Customers.Add(new Customer(2, "Erik Andersson", "erik@example.com", "0707654321"));
            Customers.Add(new Customer(3, "Maria Svensson", "maria@example.com", "0709876543"));
            Customers.Add(new Customer(4, "Johan Larsson", "johan@example.com", "0706543210"));
        }

        // Lägg till nytt rum
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Rum {room.RoomName} har lagts till.");
        }

        // Lägg till en kund
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            Console.WriteLine($"Kund {customer.Name} har lagts till.");
        }

        // Visa alla rum
        public void ShowRooms()
        {
            Console.WriteLine("Lista över alla rum:");
            foreach (var room in Rooms)
            {
                Console.WriteLine($"ID: {room.Id}, Namn: {room.RoomName}, Typ: {room.RoomType}, Extrasängar: {room.ExtraBeds}, Ledigt: {(room.IsAvailable ? "Ja" : "Nej")}");
            }
        }

        // Visa alla kunder
        public void ShowCustomers()
        {
            Console.WriteLine("Lista över alla kunder:");
            foreach (var customer in Customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Namn: {customer.Name}, Email: {customer.Email}, Telefon: {customer.PhoneNumber}");
            }
        }

        // Skapa en bokning
        public void MakeBooking(int customerId, int roomId, DateTime startDate, int nights)
        {
            if (nights <= 0)
            {
                Console.WriteLine("Antal nätter måste vara minst 1.");
                return;
            }

            if (startDate < DateTime.Today)
            {
                Console.WriteLine("Du kan inte boka ett rum för ett datum som redan har passerat.");
                return;
            }

            Room room = Rooms.FirstOrDefault(r => r.Id == roomId);
            Customer customer = Customers.FirstOrDefault(c => c.Id == customerId);

            if (room == null || customer == null)
            {
                Console.WriteLine("Fel: Rummet eller kunden existerar inte.");
                return;
            }

            DateTime endDate = startDate.AddDays(nights);

            // Kolla om rummet är tillgängligt för datumen
            if (room.Bookings.Any(b => b.IsOverlapping(startDate, endDate)))
            {
                Console.WriteLine("Rummet är redan bokat under denna period.");
                return;
            }

            Booking newBooking = new Booking(startDate, endDate, customer, room);
            room.Bookings.Add(newBooking);
            Bookings.Add(newBooking);
            room.IsAvailable = false;

            Console.WriteLine($"Bokning skapad! {customer.Name} har bokat {room.RoomName} från {startDate.ToShortDateString()} till {endDate.ToShortDateString()}.");
        }
    }
}


    

