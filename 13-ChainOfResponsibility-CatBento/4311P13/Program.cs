using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P13
{
    public interface FoodHandler
    {
        FoodHandler setNext(FoodHandler next);
        void prepareFood(string bento);
    }

    public abstract class BaseFoodStation : FoodHandler
    {
        private FoodHandler nextHandler;

        public FoodHandler setNext(FoodHandler next)
        {
            this.nextHandler = next;
            return next;
        }

        public virtual void prepareFood(string bento)
        {
            if (this.nextHandler != null)
            {
                this.nextHandler.prepareFood(bento);
            }
        }
    }

    class CatFoodStage : BaseFoodStation
    {
        public override void prepareFood(string bento)
        {
                Console.WriteLine("   [1] Cat Food: Scooped");
                base.prepareFood(bento);
        }
    }

    class FreezeDriedStage : BaseFoodStation
    {
        public override void prepareFood(string bento)
        {
            if (bento != "Diet")
            {
                Console.WriteLine("   [2] Freeze-Dried Cat Treats: Added");
            }
            base.prepareFood(bento);
        }
    }

    class VitaminStage : BaseFoodStation
    {
        public override void prepareFood(string bento)
        {
            Console.WriteLine("   [3] Vitamin: Sprinkled");
            base.prepareFood(bento);
        }
    }

    class DecorationStage : BaseFoodStation
    {
        public override void prepareFood(string bento)
        {
            if (bento != "Stray")
            {
                Console.WriteLine("   [4] Decoration: Name Flag Added");
            }
            base.prepareFood(bento);
        }
    }

    class PackagingStage : BaseFoodStation
    {
        public override void prepareFood(string bento)
        {
            if (bento != "DineIn")
            {
                Console.WriteLine("   [5] Packaging: Put in Box");
            }
            base.prepareFood(bento);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FoodHandler s1 = new CatFoodStage();
            FoodHandler s2 = new FreezeDriedStage();
            FoodHandler s3 = new VitaminStage();
            FoodHandler s4 = new DecorationStage();
            FoodHandler s5 = new PackagingStage();

            s1.setNext(s2).setNext(s3).setNext(s4).setNext(s5);

            Console.WriteLine("--- Order: DineIn Cat ---");
            s1.prepareFood("DineIn");

            Console.WriteLine("\n--- Order: Normal Cat ---");
            s1.prepareFood("Mimi");

            Console.WriteLine("\n--- Order: Stray Cat ---");
            s1.prepareFood("Stray");

            Console.WriteLine("\n--- Order: Stray Cat ---");
            s3.prepareFood("");


            Console.ReadLine();
        }
    }
}
