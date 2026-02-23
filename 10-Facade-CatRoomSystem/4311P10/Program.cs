using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P10
{
    class RoomSystem
    {
        private string roomType;
        private string cooling;
        private string pillow;
        private string toilet;
        private string airQuality;

        public string getWalkin()
        {
            this.roomType = "Walk In Cage";
            this.cooling = "Fan";
            return this.roomType + " (" + this.cooling + ")";
        }

        public string getMember()
        {
            this.roomType = "Member Room";
            this.cooling = "Air Con";
            return this.roomType + " (" + this.cooling + ")";
        }

        public string getSoftPillow()
        {
            this.pillow = "Soft Pillow";
            return " + " + this.pillow;
        }

        public string getLitterBox()
        {
            this.toilet = "Clean Litter Box";
            return " + " + this.toilet;
        }

        public string getAirPurifier()
        {
            this.airQuality = "PM 2.5 Air Purifier";
            return " + " + this.airQuality;
        }
    }

    class FoodSystem
    {
        private string mainFood;
        private string snack;
        private string water;

        public string getFood(string type)
        {
            if (type == "Barf")
            {
                this.mainFood = "Fresh Chicken BARF";
            }
            else if (type == "Wet")
            {
                this.mainFood = "Tuna Wet Food";
            }
            else
            {
                this.mainFood = "Normal Dry Food";
            }
            return this.mainFood;
        }

        public string getVitaminSnack()
        {
            this.snack = "Vitamin Gel";
            return " + " + this.snack;
        }

        public string getCleanWater()
        {
            this.water = "Fountain Water";
            return " + " + this.water;
        }
    }
    class SpaSystem
    {
        private string treatment;
        private string nail;
        private string ear;
        private string paw;
        public string getSpaTreatment(string type)
        {
            if (type == "Full")
            {
                this.treatment = "Full Bath & Shampoo";
            }
            else
            {
                this.treatment = "Basic Brushing";
            }
            return this.treatment;
        }
        public string getNailClipping()
        {
            this.nail = " + Nail Clip";
            return " + " + this.nail;
        }
        public string getEarCleaning()
        {
            this.ear = " + Ear Clean";
            return " + " + this.ear;
        }
        public string getPawMassage() 
        {
            this.paw = " + Paw Massage";
            return " + " +this.paw;
        }
    }

    class PlaySystem
    {
        private string toyName;
        private string walkType;
        private string catnip; 

        public string getToy(string type)
        {
            if (type == "Feather")
            {
                this.toyName = "Feather Wand";
            }
            else
            {
                this.toyName = "Laser Pointer";
            }
            return this.toyName;
        }

        public string getWalk(string type)
        {
            if (type == "Garden")
            {
                this.walkType = "Private Garden Walk";
            }
            else
            {
                this.walkType = "Running in Tunnel";
            }
            return " + " + this.walkType;
        }

        public string getCatnip()
        {
            this.catnip = "Premium Catnip";
            return " + " + this.catnip;
        }
    }

    class CatHotelReception
    {
        protected RoomSystem room;
        protected FoodSystem food;
        protected SpaSystem spa;
        protected PlaySystem play;

        public CatHotelReception()
        {
            room = new RoomSystem();
            food = new FoodSystem();
            spa = new SpaSystem();
            play = new PlaySystem();
        }

        public string serviceCat(string pack, bool member)
        {
            string result = "";
            if (member)
            {
                result += "Room: " + room.getMember();
                result += room.getAirPurifier();
                result += room.getLitterBox();
            }
            else
            {
                result += "Room: " + room.getWalkin();
                result += room.getSoftPillow();
                result += room.getLitterBox();
            }
            result += "\n";

            result += "Food: ";
            if (pack == "Luxury")
            {
                result += food.getFood("Barf");
                result += food.getVitaminSnack();
            }
            else if (pack == "Deluxe")
            {
                result += food.getFood("Wet");
            }
            else
            {
                result += food.getFood("Dry");
            }
            result += food.getCleanWater();
            result += "\n";

            result += "Spa: ";
            if (pack == "Luxury")
            {
                result += spa.getSpaTreatment("Full"); 
                result += spa.getNailClipping();
                result += spa.getEarCleaning();
                result += spa.getPawMassage();
            }
            else if (pack == "Deluxe")
            {
                result += spa.getSpaTreatment("Basic"); 
                result += spa.getEarCleaning();
            }
            else
            {
                result += spa.getSpaTreatment("Basic"); 
            }
            result += "\n";
            result += "Play: ";
            if (pack == "Luxury")
            {
                result += play.getWalk("Garden"); 
                result += play.getWalk("Tunnel"); 
                result += play.getCatnip();
            }
            else if (pack == "Deluxe")
            {
                result += play.getToy("Feather"); 
                result += play.getWalk("Tunnel"); 
            }
            else
            {
                result += play.getToy("Laser"); 
            }

            return result;
        }
    }

    class Program
    {
        static void Client(CatHotelReception f)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Order 1: Standard (Walk-in)");
            Console.WriteLine(f.serviceCat("Standard", false));

            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("Order 2: Deluxe (Member)");
            Console.WriteLine(f.serviceCat("Deluxe", true));

            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("Order 3: Luxury (Member)");
            Console.WriteLine(f.serviceCat("Luxury", true));
        }

        static void Main(string[] args)
        {
            CatHotelReception facade = new CatHotelReception();
            Client(facade);
        }
    }
}