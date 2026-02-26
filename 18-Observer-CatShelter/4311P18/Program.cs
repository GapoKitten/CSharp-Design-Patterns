using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P18
{
    public interface Publisher
    {
        void subscribe(Observer s);
        void unsubscribe(Observer s);
        void notify();
    }

    public class CatShelter : Publisher
    {
        private List<Observer> listObserver;
        private string latestNews;

        public CatShelter()
        {
            listObserver = new List<Observer>();
        }

        public void subscribe(Observer s)
        {
            listObserver.Add(s);
        }

        public void unsubscribe(Observer s)
        {
            listObserver.Remove(s);
        }

        public void notify()
        {
            foreach (Observer s in listObserver)
            {
                s.update(latestNews); // ส่งข่าวล่าสุดไปให้ทุกคน
            }
        }

        public void broadcast(string news)
        {
            this.latestNews = news;
            notify();
        }
    }

    public interface Observer
    {
        void update(string news);
    }
    public class Adopter : Observer
    {
        private string name;
        private string homeType;
        private string receivedNews;

        public Adopter(string name, string hometype)
        {
            this.name = name;
            this.homeType = hometype.ToLower();
            this.receivedNews = "";
        }
        public void update(string news)
        {
            if (this.homeType == "house")
            {
                this.receivedNews = news;
                showReceivedNews();
            }
        }
        public void showReceivedNews()
        {
            Console.WriteLine($"{name} adopter => {receivedNews}");
        }
    }
    public class VetClinic : Observer
    {
        private string clinicName;
        private string branch;
        private string receivedNews;

        public VetClinic(string clinicName,string branch)
        {
            this.clinicName = clinicName;
            this.branch = branch;
            this.receivedNews = "";
        }

        public void update(string news)
        {
            this.receivedNews = news;
            showReceivedNews();
        }
        public void showReceivedNews()
        {
            Console.WriteLine($"{clinicName} clinic ({branch}) => {receivedNews}");
        }
    }

    public class Volunteer : Observer
    {
        private string volunteerName;
        private string receivedNews;

        public Volunteer(string name)
        {
            this.volunteerName = name;
            this.receivedNews = "";
        }

        public void update(string news)
        {
            this.receivedNews = news;
            showReceivedNews();
        }

        public void showReceivedNews()
        {
            Console.WriteLine($"{volunteerName} volunteer => {receivedNews}");
        }
    }
    class Program
    {
        static void Client()
        {
            CatShelter shelter = new CatShelter();

            Adopter pound = new Adopter("Pound","House");
            Adopter mild = new Adopter("Mild","house");
            Adopter rose = new Adopter("Rose", "condo");

            VetClinic happyPet = new VetClinic("Happy Pet", "Ramkhamhaeng");
            VetClinic catSmile = new VetClinic("Cat Smile","Ladprao");

            Volunteer jack = new Volunteer("Jack");
            Volunteer anne = new Volunteer("Anne");

            shelter.subscribe(pound);
            shelter.subscribe(mild);
            shelter.subscribe(rose);
            shelter.subscribe(happyPet);
            shelter.subscribe(catSmile);
            shelter.subscribe(jack);
            shelter.subscribe(anne);

            shelter.broadcast("URGENT! We have 3  kittens needing a home!");
           Console.WriteLine();

            shelter.unsubscribe(pound);

            shelter.broadcast("Update: 1  kitten left! Who wants to adopt?");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Client();
            Console.ReadLine();
        }
    }
}