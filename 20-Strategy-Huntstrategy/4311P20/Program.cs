using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P20
{
    public class Cat
    {
        private string catName; 
        private HuntStrategy strategy;

        public Cat(string catname)
        {
            this.catName = catname;
        }

        public void setStrategy(HuntStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void executeHunt(string prey)
        {
            if (this.strategy != null)
            {
                Console.WriteLine($"   => {catName} {strategy.hunt(prey)}");
            }
            else
            {
                Console.WriteLine($"   => {catName} sits confused, not knowing what to do.");
            }
        }
    }
    public interface HuntStrategy
    {
        string hunt(string prey);
    }

    public class StealthHunt : HuntStrategy
    {
        private string hidingSpot; 

        public StealthHunt(string spot)
        {
            this.hidingSpot = spot;
        }

        public string hunt(string prey)
        {
            return $"is hiding behind the [{hidingSpot}] and silently pouncing on the [{prey}]!";
        }
    }

    public class PlayfulSlap : HuntStrategy
    {
        private int slapCount; 

        public PlayfulSlap(int count)
        {
            this.slapCount = count;
        }

        public string hunt(string prey)
        {
            return $"is playfully poking and slapping the [{prey}] around {slapCount} times.";
        }
    }

    public class Ignore : HuntStrategy
    {
        private string sleepAction; 

        public Ignore(string action)
        {
            this.sleepAction = action;
        }

        public string hunt(string prey)
        {
            return $"looks at the [{prey}], yawns, and walks away to sleep in a [{sleepAction}] action..";
        }
    }
    public class CrazyDash : HuntStrategy
    {
        private string brokenItem; 

        public CrazyDash(string item)
        {
            this.brokenItem = item;
        }

        public string hunt(string prey)
        {
            return $"is dashing crazily! Chasing the [{prey}] all over the house until [{brokenItem}] shatters!!";
        }
    }
    class Program
    {
        static void Client()
        {
            Cat myCat = new Cat("Gapo");
            Console.WriteLine("========== CAT HUNTING STYLES ==========\n");
            myCat.executeHunt("Lizard");

            Console.WriteLine(">> The Cat sees a [Ceiling Lizard]");
            myCat.setStrategy(new StealthHunt("sofa"));
            myCat.executeHunt("Lizard");

            Console.WriteLine("\n>> The Cat sees a [Fat Cockroach]");
            myCat.setStrategy(new PlayfulSlap(5));
            myCat.executeHunt("Cockroach");

            Console.WriteLine("\n>> The Cat sees a [Red Ant walking by]");
            myCat.setStrategy(new Ignore("belly-up"));
            myCat.executeHunt("Red Ant");

            Console.WriteLine("\n>> The Cat sees a [Giant Sewer Rat]");
            myCat.setStrategy(new CrazyDash("Fan"));
            myCat.executeHunt("Rat");
        }
        static void Main(string[] args)
        {
            Client();
            Console.ReadLine();
        }
    }
}