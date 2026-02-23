using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P9
{
    public interface Cat
    {
        string getDescription();
        double getWeight();
    }

    public class ScottishFold : Cat
    {
        private string ears;
        private double weight; 

        public ScottishFold(string e, double w)
        {
            this.ears = e;
            this.weight = w;
        }

        public string getDescription()
        {
            return "Scottish Fold Cat [" + this.ears + "]";
        }
        public double getWeight()
        {
            return this.weight;
        }
    }

    public abstract class ClothingDecorator : Cat
    {
        protected Cat cat;

        public ClothingDecorator(Cat c)
        {
            this.cat = c;
        }

        public virtual string getDescription()
        {
            return this.cat.getDescription();
        }

        public virtual double getWeight()
        {
            return this.cat.getWeight();
        }
    }

    public class CatShirt : ClothingDecorator
    {
        public CatShirt(Cat c) : base(c) { }

        public override string getDescription()
        {
            return base.getDescription() + "\n wearing Dinosaur Shirt";
        }

        public override double getWeight()
        {
            return base.getWeight() + 0.2; 
        }
    }

    public class CatHat : ClothingDecorator
    {
        public CatHat(Cat c) : base(c) { }
          public override string getDescription()
        {
            return base.getDescription() + "\n wearing Cowboy Hat";
        }

        public override double getWeight()
        {
            return base.getWeight() + 0.1; 
        }
    }

    public class CatGlasses : ClothingDecorator
    {
        public CatGlasses(Cat c) : base(c) { }

        public override string getDescription()
        {
            return base.getDescription() + "\n wearing Cool Glasses";
        }

        public override double getWeight()
        {
            return base.getWeight() + 0.05; 
        }
    }
    class Program
    {
        static void Client(Cat c)
        {
            Console.WriteLine(c.getDescription());
            Console.WriteLine(">>> Total Weight: " + c.getWeight() + " kg");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n--- Cat 1: Folded (Healthy Cat 4.5 kg) ---");
            Cat cat = new ScottishFold("Folded Ears", 4.5);
            Cat catWithShirt = new CatShirt(cat);
            Cat catWithShirtAndHat = new CatHat(catWithShirt);
            Cat catFullOption = new CatGlasses(catWithShirtAndHat);
            Client(catFullOption);
       
               Console.WriteLine("\n--- Cat 2: Straight(Fat Cat 6.0 kg) ---");
               Cat cat2 = new ScottishFold("Straight Ears", 6.0);
               Cat withGlass = new CatGlasses(cat2);
               Cat withGlassandShirt = new CatShirt(withGlass);
            Client(withGlassandShirt);

        }
    }
}