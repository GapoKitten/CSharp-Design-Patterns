using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P7
{
    public interface TypeCatFood
    {
        string getType();  
        string getTexture();   
        string getBenefit(); 
    }
    public class DryForm : TypeCatFood
    {
        private string type;
        private string texture;
        private string benefit;

        public DryForm(string t, string b)
        {
            this.type = "Dry Food";
            this.texture = t;
            this.benefit = b;
        }
        public string getType() { return this.type; }
        public string getTexture() { return this.texture; }
        public string getBenefit() { return this.benefit; }
    }

    public class WetForm : TypeCatFood
    {
        private string type;
        private string texture;
        private string benefit;

        public WetForm(string t, string b)
        {
            this.type = "Wet Food";
            this.texture = t;
            this.benefit = b;
        }

        public string getType() { return this.type; }
        public string getTexture() { return this.texture; }
        public string getBenefit() { return this.benefit; }
    }

    public class CreamForm : TypeCatFood
    {
        private string type;
        private string texture;
        private string benefit;

        public CreamForm(string t, string b)
        {
            this.type = "Cream Snack";
            this.texture = t;
            this.benefit = b;
        }
        public string getType() { return this.type; }
        public string getTexture() { return this.texture; }
        public string getBenefit() { return this.benefit; }
    }

    public class CatFoodBrand
    {
        protected TypeCatFood detailfood; // Bridge
        protected double price;
        protected string netWeight;

        public CatFoodBrand(TypeCatFood d, double p, string w)
        {
            this.detailfood = d;
            this.price = p;
            this.netWeight = w;
        }
        public virtual string GetProductInfo()
        {
            // ของเรา: เอาข้อมูลตัวเอง 2 ตัว + ข้อมูลฝั่งขวา 3 ตัว มาต่อ String กัน
            return "Price:" + this.price + " Weight:" + this.netWeight + " >> " +
                   detailfood.getType() + " (" +
                   detailfood.getTexture() + ") Benefit:" +
                   detailfood.getBenefit();
        }

        public void show()
        {
            Console.WriteLine(this.GetProductInfo());
        }
    }

    public class RoyalCanin : CatFoodBrand
    {
        public RoyalCanin(TypeCatFood d, double p, string w) : base(d, p, w) { }

        public override string GetProductInfo()
        {
            return "[Royal Canin] " + base.GetProductInfo();
        }
    }

    public class Purina : CatFoodBrand
    {
        public Purina(TypeCatFood d, double p, string w) : base(d, p, w) { }

        public override string GetProductInfo()
        {
            return "[Purina One] " + base.GetProductInfo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. สร้างฝั่งขวา (detailfood) - ใส่ Texture, Benefit
            TypeCatFood indoor = new DryForm("Crunchy", "Indoor");
            TypeCatFood hairball = new WetForm("Jelly", "Hairball Control");
            TypeCatFood snack = new CreamForm("Creammy", "So Fat");

            // 2. สร้างฝั่งซ้าย (Brand) - ใส่ Price, NetWeight และเอาฝั่งขวายัดเข้าไป
            CatFoodBrand royal = new RoyalCanin(indoor, 450.00, "1.5 kg");
            CatFoodBrand puri = new Purina(hairball, 50.00, "85 g");
            CatFoodBrand royal2 = new RoyalCanin(snack, 25.00, "20g");

            royal.show();
            puri.show();
            royal2.show();
        }
    }
}