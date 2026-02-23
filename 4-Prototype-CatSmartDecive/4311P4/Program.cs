using System;
using System.Collections.Generic;

namespace CatHotelPrototype
{
    public abstract class CatSmartDevice
    {
        public string brand, model;
        public int price;

        public CatSmartDevice(string b, string m, int p) { brand = b; model = m; price = p; }
        public abstract CatSmartDevice clone();
        public virtual void show() 
        {
            Console.Write($"[{brand} {model}] {price}Baht ");
        }
        public string getBrand()
        {
            return brand;
        }
    }

    public class Autofeed : CatSmartDevice
    {
        public bool camera;
        public Autofeed(bool c, string b, string m, int p) : base(b, m, p)
        {
            camera = c;
        }

        private Autofeed(Autofeed source) : base(source.brand, source.model, source.price)
        {
            this.camera = source.camera; 
        }

        public override CatSmartDevice clone()
        {
            return new Autofeed(this);
        }

        public override void show()
        {
            base.show();
            Console.WriteLine($"| Camera: {(camera ? "Yes" : "No")}");
        }
    }

    public class Waterfountain : CatSmartDevice
    {
        public double capacity;

        public Waterfountain(double c, string b, string m, int p) : base(b, m, p)
        {
            capacity = c; 
        }

        private Waterfountain(Waterfountain source) : base(source.brand, source.model, source.price)
        {
            this.capacity = source.capacity;
        }

        public override CatSmartDevice clone()
        {
            return new Waterfountain(this);
        }

        public override void show()
        {
            base.show(); 
            Console.WriteLine($"| Capacity: {capacity}L");
        }
    }

    public class Lasertoy : CatSmartDevice
    {
        public string color;

        public Lasertoy(string c, string b, string m, int p) : base(b, m, p) 
        {
            color = c; 
        }
        private Lasertoy(Lasertoy source) : base(source.brand, source.model, source.price)
        {
            this.color = source.color;
        }

        public override CatSmartDevice clone()
        {
            return new Lasertoy(this);
        }

        public override void show()
        {
            base.show();
            Console.WriteLine($"| Color: {color}"); 
        }
    }

    public class DeviceRegistry
    {
        private List<CatSmartDevice> devices = new List<CatSmartDevice>();
        public void addDevice(CatSmartDevice d)
        {
            devices.Add(d);
        }

        public CatSmartDevice getByBrand(string brand)
        {
            foreach (var d in devices)
            {
                if (d.getBrand() == brand)
                {
                    return d.clone();
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeviceRegistry registry = new DeviceRegistry();
            Autofeed masterFeed = new Autofeed(true, "PetKit", "Gen.3", 4500);
            Waterfountain masterWater = new Waterfountain(2.5, "Xiaomi", "Gen.2", 1200);
            Lasertoy masterLaser = new Lasertoy("Red", "Pando", "Gen.1", 300);

            registry.addDevice(masterFeed);
            registry.addDevice(masterWater);
            registry.addDevice(masterLaser);

            Console.WriteLine(">>> Client สั่ง Clone จาก Registry (ค้นหาด้วย Brand) <<<");
            CatSmartDevice myFeed = registry.getByBrand("PetKit");
            CatSmartDevice myWater = registry.getByBrand("Xiaomi");
            CatSmartDevice myLaser = registry.getByBrand("Pando");
            myFeed.model = "Gen.4";
            if (myFeed is Autofeed feed)
            {
                feed.camera = false;
            }

            if (myFeed != null) myFeed.show();
            if (masterFeed != null) masterFeed.show();
            if (myWater != null) myWater.show();
            if (myWater != null) myLaser.show();
        }
    }
}