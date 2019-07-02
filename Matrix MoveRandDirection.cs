using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMoveDir
{
    public class Location
    {
        public  int X = 0;
        public  int Y = 0;

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Program
    {
        public static Dictionary<string, Location> Creatures = new Dictionary<string, Location>();
        static void Main(string[] args)
        {
            Creatures.Add("Shark", new Location(12,3));
            Creatures.Add("Crab", new Location(3, 14));
            Creatures.Add("Fish", new Location(11, 8));

            MoveDirection();
        }

        public static void MoveDirection()
        {
            foreach (var creature in Creatures)
            {
                string s = GetDirection();

                switch (s)
                {
                    case "U":
                        creature.Value.Y--;
                        break;
                    case "D":
                        creature.Value.Y++;
                        break;
                    case "L":
                        creature.Value.X--;
                        break;
                    case "R":
                        creature.Value.X++;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Creature: {0}  Direction for move: {1}  Position after move: {2}, {3}",
                                creature.Key.ToString(), s, creature.Value.X, creature.Value.Y);
                Console.ReadKey();
            }

        }

        public static string GetDirection()
        {
            List<string> direction = new List<string> { "U", "D", "L", "R" };
            Random rand = new Random();
            int next = rand.Next(direction.Count);

            return direction[next];
        }
    }
}
