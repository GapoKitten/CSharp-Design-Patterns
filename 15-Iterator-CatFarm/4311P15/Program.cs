using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P15
{

    public interface Feline
    {
        string getStatus(); 
        string getBreed();  
        void show();     
    }

    public class Cat : Feline
    {
        private string  name;
        private string  breed;  
        private string  status; 

        public Cat(string n, string b, string s)
        {
            name = n;
            breed = b;
            status = s;
        }

        public string getBreed() { return breed; }
        public string getStatus() { return status; }
        public void show()
        {
            Console.WriteLine($"   [Cat] Name: {name} | Breed: {breed} | Status: {status}");
        }
    }

    public interface FelineCollection
    {
        FelineIterator createSickIterator();
        FelineIterator createHealthyIterator();
        FelineIterator createAllIterator();
    }

    public class PersianCollection : FelineCollection
    {
        private List<Feline> persain = new List<Feline>();

        public void addPersian(Cat c)
        {
            if (c.getBreed() == "Persian")
            {
                persain.Add(c);
            }
            else
            {
                Console.WriteLine($"[Error] '{c.getBreed()}' cannot enter Persian Farm! (Access Denied)");
            }
        }
        public FelineIterator createSickIterator() { return new SickIterator(persain); }
        public FelineIterator createHealthyIterator() { return new HealthyIterator(persain); }
        public FelineIterator createAllIterator() { return new AllIterator(persain); }
    }

    public class ScottishCollection : FelineCollection
    {
        private List<Feline> scottish = new List<Feline>();

        public void addScottish(Cat c)
        {
            if (c.getBreed() == "Scottish")
            {
                scottish.Add(c);
            }
            else
            {
                Console.WriteLine($"[Error] '{c.getBreed()}' cannot enter Scottish Farm!  (Access Denied)");
            }
        }
        public FelineIterator createSickIterator() { return new SickIterator(scottish); }
        public FelineIterator createHealthyIterator() { return new HealthyIterator(scottish); }
        public FelineIterator createAllIterator() { return new AllIterator(scottish); }
    }

    public interface FelineIterator
    {
        bool hasNext();
        Feline next();
    }

    public class SickIterator : FelineIterator
    {
        private List<Feline> sick = new List<Feline>();
        private int index = 0;

        public SickIterator(List<Feline> sourceCollection)
        {
            foreach (Feline c in sourceCollection)
            {
                if (c.getStatus() == "Sick")
                {
                    sick.Add(c);
                }
            }
        }

        public bool hasNext() { return index < sick.Count; }
        public Feline next() { return sick[index++]; }
    }

    public class HealthyIterator : FelineIterator
    {
        private List<Feline> healthy = new List<Feline>();
        private int  index = 0;

        public HealthyIterator(List<Feline> sourceCollection)
        {
            foreach (Feline c in sourceCollection)
            {
                if (c.getStatus() == "Healthy")
                {
                   healthy.Add(c);
                }
            }
        }

        public bool hasNext() { return index < healthy.Count; }
        public Feline next() { return healthy[index++]; }
    }

    public class AllIterator : FelineIterator
    {
        private List<Feline> allcat = new List<Feline>();
        private int index = 0;

        public AllIterator(List<Feline> sourceCollection)
        {
            foreach (Feline c in sourceCollection)
            {
                allcat.Add(c);
            }
        }

        public bool hasNext() { return index < allcat.Count; }
        public Feline next() { return allcat[index++]; }
    }

    class Program
    {
        static void client(string title, FelineIterator iterator)
        {
            Console.WriteLine($"\n--- {title} ---");
            while (iterator.hasNext())
            {
                iterator.next().show();
            }
        }
        static void Main(string[] args)
        {

            PersianCollection persianFarm = new PersianCollection();
            Console.WriteLine(">>> Adding Cats to Persian Farm...");
            persianFarm.addPersian(new Cat("WrongCat", "Stray", "Healthy"));
            persianFarm.addPersian(new Cat("Pepo", "Persian", "Healthy"));    
            persianFarm.addPersian(new Cat("Party", "Persian", "Healthy")); 
            persianFarm.addPersian(new Cat("Puma", "Persian", "Sick"));    
            Console.WriteLine("...Done adding Persians.");

            ScottishCollection scottishFarm = new ScottishCollection();
            Console.WriteLine("\n>>> Adding Cats to Scottish Farm...");
            scottishFarm.addScottish(new Cat("Star", "Scottish", "Healthy")); 
            scottishFarm.addScottish(new Cat("Sunny", "Scottish", "Sick"));    
            scottishFarm.addScottish(new Cat("Seaweed", "Scottish", "Healthy"));
            scottishFarm.addScottish(new Cat("Snow", "Scottish", "Healthy"));
            Console.WriteLine("...Done adding Scottish.");

   
            client("Persian Farm: All Cats", persianFarm.createAllIterator());
            client("Persian Farm: Healthy Only", persianFarm.createHealthyIterator());
            client("Persian Farm: Sick Only ", persianFarm.createSickIterator());

            client("Scottish Farm: All Cats", scottishFarm.createAllIterator());
            client("Scottish Farm: Healthy Only", scottishFarm.createHealthyIterator());
            client("Scottish Farm: Sick Cats", scottishFarm.createSickIterator());

            Console.ReadLine();
        }
    }
}