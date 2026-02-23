using System;

namespace _4311P12
{
    public class Cat
    {
        private string chipID;
        private bool hasPrey;
        private bool isMuddy;

        public Cat(string chip, bool prey, bool muddy)
        {
            this.chipID = chip;
            this.hasPrey = prey;
            this.isMuddy = muddy;
        }

        public string getChipID() { return chipID; }
        public bool getPrey() { return hasPrey; }
        public bool getMuddy() { return isMuddy; }
    }

    public interface Door
    {
        void Open(Cat cat);
    }

    public class HomeDoor : Door
    {
        public void Open(Cat cat)
        {
            Console.WriteLine($"[HomeDoorOpen!!] Welcome home, {cat.getChipID()}! (Door Opens)");
        }
    }

    public class SmartDoorProxy : Door
    {
        private HomeDoor realDoor;

        public SmartDoorProxy(HomeDoor door)
        {
            this.realDoor = door;
        }

        private bool CheckMicrochip(Cat cat)
        {
            if (cat.getChipID() == "GAPO") return true;
            Console.WriteLine($"   [X] Check 1 Failed: Chip ID '{cat.getChipID()}' not recognized.");
            return false;
        }

        private bool CheckPrey(Cat cat)
        {
            if (!cat.getPrey()) return true;
            Console.WriteLine($"   [X] Check 2 Failed: {cat.getChipID()} is carrying a prey!");
            return false;
        }

        private bool CheckCleanliness(Cat cat)
        {
            if (!cat.getMuddy()) return true;
            Console.WriteLine($"   [X] Check 3 Failed: {cat.getChipID()} is too muddy!");
            return false;
        }

        public void Open(Cat cat)
        {
            Console.WriteLine($"\n--- Processing Request: {cat.getChipID()} ---");

            if (CheckMicrochip(cat) && CheckPrey(cat) && CheckCleanliness(cat))
            {
                Console.WriteLine("   [OK] All Checks Passed. Access Granted.");
                realDoor.Open(cat);
            }
            else
            {
                Console.WriteLine("   [X] Access Denied: Stay outside.");
            }
        }
    }

    class Program
    {
        static void client(Door door, Cat cat)
        {
            door.Open(cat);
        }
        static void Main(string[] args)
        {
            HomeDoor realHomeDoor = new HomeDoor();
            Door mySmartDoor = new SmartDoorProxy(realHomeDoor);

            Cat strayCat = new Cat( "UNKNOWN", false, false);        
            Cat hunterCat = new Cat( "GAPO", true, false);
            Cat dirtyCat = new Cat("GAPO", false, true);
            Cat goodCat = new Cat("GAPO", false, false);

            client(mySmartDoor, strayCat);
            client(mySmartDoor, hunterCat);
            client(mySmartDoor, dirtyCat);
            client(mySmartDoor, goodCat);

            Console.ReadLine();
        }
    }
}
