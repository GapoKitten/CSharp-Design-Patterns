using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P22
{
    public interface CatVisitor
    {
        void visitPersian(PersianCat cat);
        void visitSphynx(SphynxCat cat);
        void visitMunchkin(MunchkinCat cat);
    }

    public interface Cat
    {
        void accept(CatVisitor visitor);
    }

    public class PersianCat : Cat
    {
        private string name;
        private int hairLengthCm;

        public PersianCat(string n, int h)
        {
            name = n;
            hairLengthCm = h;
        }

        public void accept(CatVisitor visitor)
        {
            visitor.visitPersian(this);
        }
        public string getName() { return name; }
        public int getHairLength() { return hairLengthCm; }
    }

    public class SphynxCat : Cat
    {
        private string name;
        private double bodyTemp;

        public SphynxCat(string n, double temp)
        {
            name = n;
            bodyTemp = temp;
        }

        public void accept(CatVisitor visitor)
        {
            visitor.visitSphynx(this);
        }

        public string getName() { return name; }
        public double getBodyTemp() { return bodyTemp; }
    }

    public class MunchkinCat : Cat
    {
        private string name;
        private int legLengthCm;

        public MunchkinCat(string n, int legLength)
        {
            name = n;
            legLengthCm = legLength;
        }

        public void accept(CatVisitor visitor)
        {
            visitor.visitMunchkin(this);
        }

        public string getName() { return name; }
        public int getLegLength() { return legLengthCm; }
    }

    public class GroomerVisitor : CatVisitor
    {
        public void visitPersian(PersianCat cat)
        {
            Console.WriteLine($"[Groomer] Brushing {cat.getHairLength()}cm long hair for {cat.getName()} to remove tangles.");
        }

        public void visitSphynx(SphynxCat cat)
        {
            Console.WriteLine($"[Groomer] Wiping {cat.getName()}'s skin with a warm damp cloth.");
        }

        public void visitMunchkin(MunchkinCat cat)
        {
            Console.WriteLine($"[Groomer] Trimming belly fur for {cat.getName()} because its legs are only {cat.getLegLength()}cm short.");
        }
    }

    public class VetVisitor : CatVisitor
    {
        public void visitPersian(PersianCat cat)
        {
            Console.WriteLine($"[Vet] Prescribing hairball remedy for {cat.getName()} due to its long hair.");
        }

        public void visitSphynx(SphynxCat cat)
        {
            Console.WriteLine($"[Vet] Checking {cat.getName()}'s skin. Body temp is normal at {cat.getBodyTemp()}°C.");
        }

        public void visitMunchkin(MunchkinCat cat)
        {
            Console.WriteLine($"[Vet] X-raying {cat.getName()}'s spine to check for joint issues due to short legs.");
        }
    }

    class Program
    {
        static void client(List<Cat> listcats, CatVisitor v)
        {
            foreach (Cat cat in listcats)
            {
                cat.accept(v);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Cat> cats = new List<Cat>();
            cats.Add(new PersianCat("Pepo", 15));
            cats.Add(new SphynxCat("Sunny", 38.5));
            cats.Add(new MunchkinCat("Momo", 5));

            CatVisitor groomer = new GroomerVisitor();
            CatVisitor vet = new VetVisitor();

            Console.WriteLine("==========  Groomer (Spa Time) ==========");
            client(cats, groomer);

            Console.WriteLine("\n========== Vet (Health Check) ==========");
            client(cats, vet);

            Console.ReadLine();
        }
    }
}