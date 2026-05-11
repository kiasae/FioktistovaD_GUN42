using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes2
{
    internal class Dungeon
    {
       public Room[] rooms;

       public Dungeon() 
        {
            rooms = new Room[]
                    {
                    new Room(new Unit("Goblin"), new Weapon("Spear", 3, 7)),
                    new Room(new Unit("Ogre"), new Weapon("Club", 5, 10)),
                    new Room(new Unit("Skeleton"), new Weapon("Bone", 1, 3)),
                    };
        }
        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine("Unit of room: " +room.Unit.Name);
                Console.WriteLine("Weapon of room: " +room.Weapon.Name);
                Console.WriteLine("—");
            }
        }
    }

}
