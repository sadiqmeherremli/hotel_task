using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_task
{
    

    public class Room
    {
        private static int nextId = 1;

        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int PersonCapacity { get; }
        public bool IsAvailable { get;set; } = true;

        public Room(string name, decimal price, int personCapacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new MissingInfoException("Otağın adını daxil edin.");

            Id = nextId++;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
        }

        public override string ToString()
        {
            return ShowInfo();
        }

        public string ShowInfo()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price}, Capacity: {PersonCapacity}, Available: {IsAvailable}";
        }
    }

    

}
