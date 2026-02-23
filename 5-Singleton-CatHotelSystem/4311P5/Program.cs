using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P5
{
    public class CatHotelSystem
    {
        private static CatHotelSystem instance = null;
        private string hotelStatus;
        private CatHotelSystem()
        {
            Console.WriteLine("System Boot: Gapo Cat Hotel is Online...");
            this.hotelStatus = "Open - High Vacancy"; 
        }

        public static CatHotelSystem getInstance()
        {
            if (instance == null)
            {
                instance = new CatHotelSystem();
            }
            return instance;
        }

        public void setHotelStatus(string status)
        {
            this.hotelStatus = status;
        }

        public string getHotelStatus()
        {
            return this.hotelStatus;
        }
        public void shutdown()
        {
            Console.WriteLine("System Shutdown..."); 
            Console.WriteLine("Final Status: " + hotelStatus); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CatHotelSystem h1 = CatHotelSystem.getInstance();
            Console.WriteLine("Current Status: " + h1.getHotelStatus());
            h1.setHotelStatus("Open - Nearly Full");
            Console.WriteLine("Current Status: " + h1.getHotelStatus());
            Console.WriteLine();

            CatHotelSystem h2 = CatHotelSystem.getInstance();
            h2.setHotelStatus("Closed - Full Booked");
            Console.WriteLine("Current Status: " + h2.getHotelStatus());
            Console.WriteLine("Check h1 : " + h1.getHotelStatus());

            h1.shutdown();

        }
    }
}