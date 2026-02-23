using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P6
{
    public interface FoodCat
    {
        double getGrams(); 
    }
    public class CanFood
    {
        private double ounce;
        public CanFood(double o)
        {
            this.ounce = o;
        }
        public double getOunce() 
        {
            return this.ounce;
        }
    }
    public class DryFood
    {
        private int spoon;
        public DryFood(int s)
        {
            this.spoon = s;
        }
        public int getSpoon()
        {
            return this.spoon;
        }
    }
    public class CanFoodAdapter : FoodCat
    {
        private CanFood adaptee;

        public CanFoodAdapter(CanFood c)
        {
            this.adaptee = c;
        }
        public double getGrams()
        {
            return adaptee.getOunce() * 28.35;
        }
    }

    public class DryFoodAdapter : FoodCat
    {
        private DryFood adaptee;

        public DryFoodAdapter(DryFood d)
        {
            this.adaptee = d;
        }

        public double getGrams()
        {
            return adaptee.getSpoon() * 15.0;
        }
    }

    public class SmartBowl
    {
        private double capacityGrams;

        public SmartBowl(double g)
        {
            this.capacityGrams = g;
        }

        public int canContain(FoodCat food)
        {
            return (int)(this.capacityGrams / food.getGrams());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SmartBowl myBowl = new SmartBowl(250); // ชามจุ 250g
            CanFood wetFood = new CanFood(3);   // 3 oz
            DryFood dryFood = new DryFood(1);   // 1 spoon

            FoodCat wetAdapter = new CanFoodAdapter(wetFood);
            FoodCat dryAdapter = new DryFoodAdapter(dryFood);

            Console.WriteLine($"ชามนี้ใส่อาหารเปียกได้: {myBowl.canContain(wetAdapter)} กระป๋อง");
            Console.WriteLine($"ชามนี้ใส่อาหารเม็ดได้:   {myBowl.canContain(dryAdapter)} ช้อน");
        }
    }
}