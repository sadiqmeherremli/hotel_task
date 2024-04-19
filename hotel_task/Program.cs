namespace hotel_task
{
    using System;
    using System.Linq;


    public class Program
    {
        static void Main()
        {
            int choice;
            Hotel currentHotel = null;
            List<Hotel> hotels = new List<Hotel>();

            do
            {
                Console.WriteLine("Menyu");
                Console.WriteLine("1.Sisteme giris");
                Console.WriteLine("0.Cixis");
                Console.WriteLine();

                Console.Write("Seciminizi daxil edin: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        currentHotel = Login(hotels);
                        if (currentHotel != null)
                            HandleHotelMenu(currentHotel);
                        break;
                    case 0:
                        Console.WriteLine("Sistemden cixildi.");
                        break;
                    default:
                        Console.WriteLine("Duzgun secim edin.");
                        break;
                }
            } while (choice != 0);
        }

        static Hotel Login(List<Hotel> hotels)
        {
            Console.Write("Otel adini daxil edin: ");
            string hotelName = Console.ReadLine();

            if (hotels.Any(h => h.Name == hotelName))
            {
                Console.WriteLine("Bu adda bir otel artıq mövcuddur.");
                return null;
            }

            try
            {
                Hotel newHotel = new Hotel(hotelName);
                hotels.Add(newHotel);
                Console.WriteLine("Otel uğurla yaradıldı.");
                return newHotel;
            }
            catch (MissingInfoException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static void HandleHotelMenu(Hotel hotel)
        {
            int choice;

            do
            {
                Console.WriteLine("Hotel Menyu");
                Console.WriteLine("1.Room yarat");
                Console.WriteLine("2.Roomlari gor");
                Console.WriteLine("3.Rezervasya et");
                Console.WriteLine("4.Evvelki menuya qayit.");
                Console.WriteLine("0.Exit");
                Console.WriteLine();

                Console.Write("Seciminizi daxil edin: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Zehmet olmasa duzgun reqem daxil edin.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateRoom(hotel);
                        break;
                    case 2:
                        ShowAllRooms(hotel);
                        break;
                    case 3:
                        MakeReservation(hotel);
                        break;
                    case 4:
                        return;
                    case 0:
                        Console.WriteLine("Sistemden cixildi.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Duzgun secim edin.");
                        break;
                }
            } while (choice != 0);
        }

        static void CreateRoom(Hotel hotel)
        {
            Console.Write("Otaq adini daxil edin: ");
            string roomName = Console.ReadLine();

            Console.Write("Qiymeti daxil edin: ");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Duzgun qiymet daxil edin.");
                return;
            }

            Console.Write("Neferlik sayini daxil edin: ");
            int capacity;
            if (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.WriteLine("Duzgun neferlik sayi daxil edin.");
                return;
            }

            try
            {
                Room room = new Room(roomName, price, capacity);
                hotel.AddRoom(room);
                Console.WriteLine("Otaq uğurla yaradıldı.");
            }
            catch (MissingInfoException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowAllRooms(Hotel hotel)
        {
            Console.WriteLine("***************Rooms***************");
            foreach (var room in hotel.FindAllRooms(r => true))
            {
                Console.WriteLine(room);
            }
            Console.WriteLine();
        }

        static void MakeReservation(Hotel hotel)
        {
            Console.Write("Otaq ID-sini daxil edin: ");
            int roomId;
            if (!int.TryParse(Console.ReadLine(), out roomId))
            {
                Console.WriteLine("Duzgun ID daxil edin.");
                return;
            }

            Console.Write("Misafir sayini daxil edin: ");
            int guestCount;
            if (!int.TryParse(Console.ReadLine(), out guestCount))
            {
                Console.WriteLine("Duzgun say daxil edin.");
                return;
            }

            try
            {
                hotel.MakeReservation(roomId, guestCount);
                Console.WriteLine("Rezervasya uğurla tamamlandı.");
            }
            catch (NotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
