using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Classes
{

    // Rums klassen
    public class Room
    {
        // Skapa properties
        public int RoomId { get; set; } // Unikt ID för varje rum
        public string RoomName { get; set; } // Namn på rummet (ex. "Rum 101")
        public string RoomType { get; set; } // "Enkelrum" eller "Dubbelrum"
        public int ExtraBeds { get; set; } //  extrasängar
        public bool IsAvailable { get; set; } // Är rummet ledigt?
        public List<Booking> Bookings { get; set; } = new List<Booking>(); // Lista över bokningar men VARFÖR?
                                                                           // Rummets egen bokningslista sparar alla bokningar för just det rummet,
                                                                           // så det går snabbt att se om det är ledigt eller upptaget i just dehär rummet
                                                                           // utan att söka i hela hotellets bokningslista.
                                                                           // Listan kommer användas i HotelManager klassen längst ner sen


        // Konstruktor för att skapa ett nytt rum
        public Room(int id, string roomName, string roomType, int extraBeds)
        {
            RoomId = id;
            RoomName = roomName;
            RoomType = roomType;
            ExtraBeds = extraBeds;
            IsAvailable = true;
        }




        // DATABAS: Lägg till en parameterlös konstruktor för sist gick det inte att läsa från databasen
        // men den konstruktor som används för att koden ska köras är såklart den över.
        public Room()
        {


        }



    }
}
