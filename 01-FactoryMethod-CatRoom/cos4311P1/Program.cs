using System;

namespace cos4311P1
{
    public interface CatRoom
    {
        void clean();
        void setup();
        void checkin();
    }

    public class Standard : CatRoom
    {
        public void clean()
        {
            Console.WriteLine("[Standard] clean: กวาดพื้นและถูพื้นปกติ");
        }
        public void setup()
        {
            Console.WriteLine("[Standard] setup: เตรียมเบาะนอนธรรมดา");
        }
        public void checkin()
        {
            Console.WriteLine("[Standard] checkin: เปิดพัดลม พาน้องเข้าพัก");
        }
    }

    public class Deluxe : CatRoom
    {
        public void clean()
        {
            Console.WriteLine("[Deluxe] clean: ดูดฝุ่นและถูพื้นน้ำยาฆ่าเชื้อ");
        }

        public void setup()
        {
            Console.WriteLine("[Deluxe] setup: เตรียมเบาะนุ่ม + คอนโดแมวเล็ก");
        }

        public void checkin()
        {
            Console.WriteLine("[Deluxe] checkin: เปิดแอร์ 27 องศา");
        }
    }

    public class Vip : CatRoom
    {
        public void clean()
        {
            Console.WriteLine("[Vip] clean: อบโอโซน + ขัดพื้นเงา");
        }

        public void setup()
        {
            Console.WriteLine("[Vip] setup: เตรียมน้ำพุแมว + คอนโด 3 ชั้น");
        }

        public void checkin()
        {
            Console.WriteLine("[Vip] checkin: เปิดแอร์ 24 องศา + เปิดเพลง");
        }
    }

    public abstract class RoomCreator
    {
        public abstract CatRoom getCatRoom();
        public void prepare()
        {
            CatRoom room = this.getCatRoom();
            Console.WriteLine("--- Start Prepare ---");
            room.clean();
            room.setup();
            room.checkin();
            Console.WriteLine("--- Finish ---\n");
        }
    }
    public class StandardRoomCreator : RoomCreator
    {
        public override CatRoom getCatRoom()
        {
            return new Standard();
        }
    }
    public class DeluxeRoomCreator : RoomCreator
    {
        public override CatRoom getCatRoom()
        {
            return new Deluxe();
        }
    }

    public class VipRoomCreator : RoomCreator
    {
        public override CatRoom getCatRoom()
        {
            return new Vip();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Cat Hotel System ===\n");

            RoomCreator creator1 = new StandardRoomCreator();
            creator1.prepare();

            RoomCreator creator2 = new DeluxeRoomCreator();
            creator2.prepare();

            RoomCreator creator3 = new VipRoomCreator();
            creator3.prepare();

            RoomCreator creator4 = new VipRoomCreator();
            creator4.prepare();

            Console.ReadLine();
        }
    }
}