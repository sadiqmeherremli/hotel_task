using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_task
{
    public class Hotel
    {
        private static int nextId = 1;

        public int Id { get; }
        public string Name { get; }
        private List<Room> Rooms { get; } = new List<Room>();

        public Hotel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new MissingInfoException("Otelin adını daxil edin");

            Id = nextId++;
            Name = name;
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public List<Room> FindAllRooms(Predicate<Room> predicate)
        {
            return Rooms.FindAll(predicate);
        }


        public void MakeReservation(int? roomId, int guestCount)
        {
            if (!roomId.HasValue)
                throw new ArgumentNullException("roomId", "Otağ ID ni daxil edin.");

            Room room = Rooms.Find(r => r.Id == roomId);
            if (room == null)
                throw new NotAvailableException();

            if (!room.IsAvailable || guestCount > room.PersonCapacity)
                throw new NotAvailableException();

            room.IsAvailable = false;
        }
    }
}
