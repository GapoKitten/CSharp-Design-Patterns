using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P8
{
    public interface CatService
    {
        string getDetail(); 
        void Show();    
    }

    public class Grooming : CatService
    {
        public string getDetail()
        {
            return "   - [Grooming] Bath & Haircut\n";
        }
        public void Show()
        {
            Console.WriteLine("\n--- Show Single Service ---");
            Console.Write(this.getDetail());
        }
    }

    public class Spa : CatService
    {
        public string getDetail()
        {
            return "   - [Spa] Aroma Massage & Mud Mask\n";
        }
        public void Show()
        {
            Console.Write(this.getDetail());
        }
    }

    public class HealthCheck : CatService
    {
        public string getDetail()
        {
            return "   - [Health] Vet Checkup & Vaccination\n";
        }
        public void Show()
        {
            Console.Write(this.getDetail());
        }
    }

    public class ServicePackage : CatService
    {
        private string packageName;
        private List<CatService> services = new List<CatService>();

        public ServicePackage(string name)
        {
            this.packageName = name;
        }

        public void Add(CatService s)
        {
            services.Add(s);
        }

        public string getDetail()
        {
            string result = "";
            foreach (var s in services)
            {
                result += s.getDetail();
            }
            return "Package [" + packageName + "] Includes:\n" + result;
        }
        public void Show()
        {
            Console.WriteLine("--- Show Package Service ---");
            Console.WriteLine(this.getDetail());
        }

    }
    class Program
    {
        static void Client(CatService c)
        {
            Console.Write(c.getDetail());
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Grooming groom = new Grooming();
            Spa spa = new Spa();
            HealthCheck health = new HealthCheck();

            ServicePackage fullPack = new ServicePackage("Full Package Set");
            ServicePackage miniPack = new ServicePackage("Mini Package Set");

            // 3. เอาของใส่กล่อง
            fullPack.Add(groom);
            fullPack.Add(spa);
            fullPack.Add(health);

            miniPack.Add(groom);
            miniPack.Add(spa);

            fullPack.Add(miniPack);

            fullPack.Show();
            Client(fullPack);
            groom.Show();
        }
    }
}