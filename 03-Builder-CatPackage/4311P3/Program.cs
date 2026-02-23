using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P3
{
    public class StayPackage
    {
        private string room;
        private string food;
        private string water;
        private string toilet;
        private string aircon;
        private string cctv;
        private string toys;
        private string grooming;
        private string spa;
        private string transport;

        public void setRoom(string r)
        {
            room = r;
        }
        public void setFood(string f)
        {
            food = f;
        }
        public void setWater(string w)
        {
            water = w;
        }
        public void setToilet(string t)
        {
            toilet = t;
        }
        public void setAircon(string a)
        {
            aircon = a;
        }
        public void setCCTV(string c)
        {
            cctv = c;
        }
        public void setToys(string t)
        {
            toys = t;
        }
        public void setGrooming(string g)
        {
            grooming = g;
        }
        public void setSpa(string s)
        {
            spa = s;
        }
        public void setTransport(string tr)
        {
            transport = tr;
        }
        public void Show()
        {
            int i = 1;
            Console.WriteLine("\n[ รายละเอียดแพ็กเกจ (Structured Object) ]"); 
            if (room != null) { Console.WriteLine(i++ + ".ห้อง: " + room); }
            if (food != null) { Console.WriteLine(i++ +".อาหาร: " + food); }
            if (water != null) { Console.WriteLine(i++ + ".น้ำ: " + water); }
            if (toilet != null) { Console.WriteLine(i++ + ".ห้องน้ำ: " + toilet); }
            if (aircon != null) { Console.WriteLine(i++ + ".แอร์: " + aircon); }
            if (cctv != null) { Console.WriteLine(i++ + ".กล้อง: " + cctv); }
            if (toys != null) { Console.WriteLine(i++ + ".ของเล่น: " + toys); }
            if (grooming != null) { Console.WriteLine(i++ + ".อาบน้ำ: " + grooming); }
            if (spa != null) { Console.WriteLine(i++ + ".สปา: " + spa); }
            if (transport != null) { Console.WriteLine(i++ + ".รับส่ง: " + transport); }

            Console.WriteLine("-------------------------");
        }

    }
    public interface Builder
    {
        void reset();
        void buildRoom();   
        void buildFood();      
        void buildWater();    
        void buildToilet();  
        void buildAircon();    
        void buildCCTV();     
        void buildToys();      
        void buildGrooming();   
        void buildSpa();      
        void buildTransport();
        StayPackage getPackage();
    }
    public class BasicPackageBuilder : Builder
    {
        private StayPackage package = new StayPackage();

        public void reset()
        {
            package = new StayPackage();
        }
        public void buildRoom()
        {
            package.setRoom("ห้องกรง Standard");
        }
        public void buildFood()
        {
            package.setFood("อาหารเม็ด");
        }
        public void buildWater()
        {
            package.setWater("ชามน้ำพลาสติก");
        }
        public void buildToilet()
        {
            package.setToilet("กระบะทราย");
        }
        public void buildAircon()
        {
            package.setAircon("แอร์27องศา");
        }
        public void buildCCTV()
        {
            package.setCCTV("ดูผ่านมือถือได้");
        }
        public void buildToys()
        {
            package.setToys("ลูกบอล");
        }
        public void buildGrooming()
        {
            package.setGrooming("หวีขน");
        }
        public void buildSpa()
        {
            package.setSpa("โฟมอาบแห้ง");
        }
        public void buildTransport()
        {
            package.setTransport("รับที่โรงแรมเท่านั้น");
        }
        public StayPackage getPackage()
        {
            StayPackage result = package;
            this.reset(); 
            return result;
        }
    }

    public class PremiumPackageBuilder : Builder
    {
        private StayPackage package = new StayPackage();

        public void reset()
        {
            package = new StayPackage();
        }
        public void buildRoom()
        {
            package.setRoom("ห้องกระจก VIP (กว้างพิเศษ)");
        }
        public void buildFood()
        {
            package.setFood("อาหารเปียก");
        }
        public void buildWater()
        {
            package.setWater("น้ำพุแมวกรองน้ำ");
        }
        public void buildToilet()
        {
            package.setToilet("ห้องน้ำแมวอัตโนมัติ");
        }
        public void buildAircon()
        {
            package.setAircon("แอร์ 25 องศา");
        }
        public void buildCCTV()
        {
            package.setCCTV("ดูผ่านมือถือได้+ขยับได้+พูดได้");
        }
        public void buildToys()
        {
            package.setToys("คอนโดแมว + อุโมงค์");
        }
        public void buildGrooming()
        {
            package.setGrooming("อาบน้ำ ตัดขน (Full Course)");
        }
        public void buildSpa()
        {
            package.setSpa("สปานวดผ่อนคลาย");
        }
        public void buildTransport()
        {
            package.setTransport("รถรับ-ส่งถึงบ้าน");
        }

        public StayPackage getPackage()
        {
            StayPackage result = package;
            this.reset();
            return result;
        }
    }

    public class Director
    {
        public void makeBasicNoSpa(Builder b)
        {
            b.reset();
            b.buildRoom();
            b.buildFood();
            b.buildWater();
            b.buildToilet();
            b.buildAircon();
            b.buildCCTV();
            b.buildToys();
            b.buildGrooming();
            b.buildTransport();
        }

        public void makePremiumFullPackage(Builder b)
        {
            b.reset();
            b.buildRoom();
            b.buildFood();
            b.buildWater();
            b.buildToilet();
            b.buildAircon();
            b.buildCCTV();
            b.buildToys();
            b.buildGrooming(); 
            b.buildSpa();     
            b.buildTransport();
        }

        public void makePremiumNoFood(Builder b)
        {
            b.reset();
            b.buildRoom();
            b.buildWater();
            b.buildToilet();
            b.buildAircon();
            b.buildCCTV();
            b.buildToys();
            b.buildGrooming();
            b.buildSpa();
            b.buildTransport();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Director director = new Director();
            BasicPackageBuilder basicBuilder = new BasicPackageBuilder();
            PremiumPackageBuilder premiumBuilder = new PremiumPackageBuilder();
            BasicPackageBuilder basicTest = new BasicPackageBuilder();

            Console.WriteLine(" >>>Creating Basic NoSpa Package<<<");
            director.makeBasicNoSpa(basicBuilder); // สั่งสูตร Basic
            StayPackage p1 = basicBuilder.getPackage();  
            p1.Show();

            Console.WriteLine("\n>>>Creating Premium FullPackage<<<");
            director.makePremiumFullPackage(premiumBuilder);   // สั่งสูตร Full
            StayPackage p2 = premiumBuilder.getPackage();   
            p2.Show();

            Console.WriteLine("\n>>>Creating NoFood Package<<<");
            director.makePremiumNoFood(premiumBuilder);   // สั่งสูตร Full
            StayPackage p3 = premiumBuilder.getPackage();   
            p3.Show();

            Console.WriteLine("\n>>>Creating No Director<<<");
            basicBuilder.reset();
            basicBuilder.buildRoom();
            basicBuilder.buildFood();
            basicBuilder.buildWater();
            basicBuilder.buildToilet();
            basicBuilder.buildAircon();
            basicBuilder.buildCCTV();
            basicBuilder.buildToys();
            basicBuilder.buildGrooming();
            basicBuilder.buildSpa();
            basicBuilder.buildTransport();
            StayPackage stay = basicBuilder.getPackage();
            stay.Show();
        }
       

        
        
    }
}