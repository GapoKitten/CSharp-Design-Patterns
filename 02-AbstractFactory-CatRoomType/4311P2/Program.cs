using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P2
{
    public interface Food
    {
        void serve();
    }

    public interface Toy
    {
        void play();
    }

    public interface Bed
    {
        void sleep();
    }

    public class StandardFood : Food
    {
        public void serve()
        {
            Console.WriteLine("[Standard] Food: อาหารเม็ด");
        }
    }
    public class StandardToy : Toy
    {
        public void play()
        {
            Console.WriteLine("[Standard] Toy: ลูกบอล");
        }
    }
    public class StandardBed : Bed
    {
        public void sleep()
        {
            Console.WriteLine("[Standard] Bed: เบาะนุ่ม");
        }
    }

    public class DeluxeFood : Food
    {
        public void serve()
        {
            Console.WriteLine("[Deluxe] Food: อาหารเปียก");
        }
    }
    public class DeluxeToy : Toy
    {
        public void play()
        {
            Console.WriteLine("[Deluxe] Toy: ไม้ตกแมว");
        }
    }
    public class DeluxeBed : Bed
    {
        public void sleep()
        {
            Console.WriteLine("[Deluxe] Bed: กล่องบ้านแมว");
        }
    }

    public class VipFood : Food
    {
        public void serve()
        {
            Console.WriteLine("[Vip] Food: บาร์ฟ");
        }
    }
    public class VipToy : Toy
    {
        public void play()
        {
            Console.WriteLine("[Vip] Toy: ไม้ขนนกอันใหญ่");
        }
    }
    public class VipBed : Bed
    {
        public void sleep()
        {
            Console.WriteLine("[Vip] Bed: คอนโดแมว");
        }
    }

    public interface RoomFactory
    {
        Food createFood();
        Toy createToy();
        Bed createBed();
    }

    public class StandardFactory : RoomFactory
    {
        public Food createFood()
        {
            return new StandardFood();
        }
        public Toy createToy()
        {
            return new StandardToy();
        }
        public Bed createBed()
        {
            return new StandardBed();
        }
    }

    public class DeluxeFactory : RoomFactory
    {
        public Food createFood()
        {
            return new DeluxeFood();
        }
        public Toy createToy()
        {
            return new DeluxeToy();
        }
        public Bed createBed()
        {
            return new DeluxeBed();
        }
    }

    public class VipFactory : RoomFactory
    {
        public Food createFood()
        {
            return new VipFood();
        }
        public Toy createToy()
        {
            return new VipToy();
        }
        public Bed createBed()
        {
            return new VipBed();
        }
    }

    class Client
    {
        private RoomFactory factory;
        private Food food;
        private Toy toy;
        private Bed bed;

        public Client(RoomFactory r)
        {
            this.factory = r;
        }

        public void createRoom()
        {
            food = factory.createFood();
            toy = factory.createToy();
            bed = factory.createBed();
        }

        public void getserve()
        {
            food.serve();
        }

        public void getplay()
        {
             toy.play();
        }

        public void getsleep()
        {
            bed.sleep();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Room 1: Standard ---");
    
            Client client1 = new Client(new StandardFactory()); // 1. ส่งโรงงานเข้าไป (แต่ของยังไม่เกิด)
            client1.createRoom();// 2. ต้องสั่ง createRoom ก่อน ของถึงจะมา
            client1.getserve();
            client1.getplay();
            client1.getsleep();

            Console.WriteLine("\n--- Room 2: Vip ---");
            Client client2 = new Client(new VipFactory());
            client2.createRoom(); 
            client2.getserve();
            client2.getplay();
            client2.getsleep();

        }
    }
}