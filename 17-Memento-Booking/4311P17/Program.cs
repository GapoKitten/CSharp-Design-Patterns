using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P17
{
    public interface Memento
    {
        void show();
    }

    public class BookingMemento : Memento
    {
        private string catName;
        private string roomType;
        private int durationDays;
        private bool includeSpa;

        public BookingMemento(string name, string type, int days, bool spa)
        {
            this.catName = name;
            this.roomType = type;
            this.durationDays = days;
            this.includeSpa = spa;
        }

        public string getCatName() { return catName; }
        public string getRoomType() { return roomType; }
        public int getDurationDays() { return durationDays; }
        public bool getIncludeSpa() { return includeSpa; }

        public void show()
        {
            Console.WriteLine($"   [Saved Booking] Cat: {catName}, Room: {roomType}, Days: {durationDays}, Spa: {(includeSpa ? "Yes" : "No")}");
        }
    }

    public interface Originator
    {
        Memento save();
        void restore(Memento m);
    }
    public class Booking : Originator
    {
        private string catName;
        private string roomType;
        private int durationDays;
        private bool includeSpa;

        public Booking(string name, string type, int days, bool spa)
        {
            this.catName = name;
            this.roomType = type;
            this.durationDays = days;
            this.includeSpa = spa;
        }
        // --- Setters สำหรับเปลี่ยนแปลงค่า ---
        public void setCatName(string name) { this.catName = name; }
        public void setRoomType(string type) { this.roomType = type; }
        public void setDurationDays(int days) { this.durationDays = days; }
        public void setIncludeSpa(bool spa) { this.includeSpa = spa; }
        // --- Save State ---
        public Memento save()
        {
            return new BookingMemento(catName, roomType, durationDays, includeSpa);
        }
        public void restore(Memento m)
        {
            BookingMemento bm = (BookingMemento)m;

            string currentSpa = this.includeSpa ? "Yes" : "No";
            string savedSpa = bm.getIncludeSpa() ? "Yes" : "No";

            Console.WriteLine($"\n>> [UNDO] Restore Cat '{this.catName}'->'{bm.getCatName()}', Room '{this.roomType}'->'{bm.getRoomType()}', Spa '{currentSpa}'->'{savedSpa}'");

            this.catName = bm.getCatName();
            this.roomType = bm.getRoomType();
            this.durationDays = bm.getDurationDays();
            this.includeSpa = bm.getIncludeSpa();
        }

        public void showBooking()
        {
            Console.WriteLine($"   [Current Booking] => Cat: '{catName}' | Room: {roomType} | {durationDays} Days | Spa: {(includeSpa ? "Yes" : "No")}");
        }
    }

    public class Caretaker
    {
        private List<Memento> history;
        private Originator originator;

        public Caretaker(Originator o)
        {
            this.originator = o;
            this.history = new List<Memento>();
        }

        public void addHistory()
        {
            history.Add(originator.save()); // เทียบเท่า push_back()
        }

        public void undo()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("No history to undo.");
                return;
            }

            Memento memento = history[history.Count - 1];
            originator.restore(memento);

            history.RemoveAt(history.Count - 1);
        }

        public void showHistory()
        {
            Console.WriteLine("\n--- History Log (Undo Stack) ---");
            foreach (Memento m in history)
            {
                m.show();
            }
            Console.WriteLine("--------------------------------");
        }
    }

    class Program
    {
        static void Client()
        {
            Console.WriteLine("========== [CAT HOTEL BOOKING] ==========\n");

            // 1. เริ่มจองห้องพัก
            Booking booking = new Booking("Mochi", "Standard", 3, false);
            Caretaker caretaker = new Caretaker(booking);

            Console.WriteLine(">> 1. Owner books a Standard room for Mochi.");
            booking.showBooking();
            caretaker.addHistory(); // 🔴 Save 1

            // 2. ลูกค้าขออัปเกรด
            Console.WriteLine("\n>> 2. Owner changes name (typo), upgrades to VIP, and adds Spa.");
            booking.setCatName("Mochii");
            booking.setRoomType("VIP");
            booking.setIncludeSpa(true);

            booking.showBooking();
            caretaker.addHistory(); // 🔴 Save 2

            // 3. ลูกค้าลังเล เปลี่ยนใจ (ยังไม่เซฟ)
            Console.WriteLine("\n>> 3. Owner wants to extend days to 5. (Not saved yet)");
            booking.setDurationDays(5);
            booking.showBooking();

            // โชว์ประวัติทั้งหมด
            caretaker.showHistory();

            Console.WriteLine("\nprint(\"Restore\")");

            // 4. กดย้อนกลับ
            caretaker.undo(); // กลับไปเป็น VIP (3 วัน)
            booking.showBooking();

            caretaker.undo(); // กลับไปเป็น Standard (ไม่มีสปา)
            booking.showBooking();
        }

        static void Main(string[] args)
        {
            Client();
            Console.ReadLine();
        }
    }
}