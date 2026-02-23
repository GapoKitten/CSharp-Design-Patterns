using System;
using System.Collections.Generic;

namespace _4311P11_VaccineSystem
{
    class VaccineBatch
    {
        private string vaccineName;
        private string batchNo;
        private string company;

        public VaccineBatch(string v, string b, string c)
        {
            this.vaccineName = v;
            this.batchNo = b;
            this.company = c;
        }

        public string GetName() { return vaccineName; }
        public string GetBatch() { return batchNo; }
        public string GetCompany() { return company; }

        public string Inject(string catName, int age, string owner)
        {
            string result = $"[Cat: {catName} | Age: {age} yrs | Owner: {owner}]";
            result += $"\n   -> Injection: {vaccineName} (Batch: {batchNo})";

            if (age < 1)
            {
                result += "\n   -> [Advice] Kitten (<1 yr): Schedule Booster in 4 weeks.";
            }
            else if (age >= 10)
            {
                result += "\n   -> [Advice] Senior Cat: Monitor kidney function.";
            }
            else
            {
                result += "\n   -> [Advice]: Standard Annual Dose Complete.";
            }

           return result + "\n";
        }
    }
    class CatRecord
    {
        private string catName;
        private int age;    // ข้อมูลเฉพาะตัว (Extrinsic)
        private string ownerName;
        private VaccineBatch batchInfo;

        public CatRecord(string name, int a, string owner, VaccineBatch b)
        {
            this.catName = name;
            this.age = a;
            this.ownerName = owner;
            this.batchInfo = b;
        }

        public string printResult()
        {
            return batchInfo.Inject(catName, age, ownerName);
        }
    }
    class VaccineFactory
    {
        private List<VaccineBatch> storageVaccine = new List<VaccineBatch>();

        public VaccineBatch GetVaccineBatch(string name, string batch, string comp)
        {
            VaccineBatch foundBatch = null;

            foreach (VaccineBatch existing in storageVaccine)
            {
                if (existing.GetName() == name &&
                    existing.GetBatch() == batch &&
                    existing.GetCompany() == comp)
                {
                    foundBatch = existing; 
                    break;
                }
            }
            if (foundBatch == null)
            {
                foundBatch = new VaccineBatch(name, batch, comp);
                storageVaccine.Add(foundBatch);
                Console.WriteLine($"[SYSTEM LOG] Opening NEW Vaccine Batch: {name} ({batch})");
            }

            return foundBatch;
        }
    }

    class PetClinic
    {
        private List<CatRecord> clinicList= new List<CatRecord>();

        public void vaccinateCat(string catName, int age, string owner, string vName, string vBatch, string vComp, VaccineFactory vac)
        {
            VaccineBatch batch = vac.GetVaccineBatch(vName, vBatch, vComp);

            CatRecord newRecord = new CatRecord(catName, age, owner, batch);
            clinicList.Add(newRecord);
        }

        public string ShowAllRecords()
        {
            string report = "";
            foreach (CatRecord rec in clinicList)
            {
                report += rec.printResult();
            }
            return report;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VaccineFactory storage = new VaccineFactory();
            PetClinic clinic = new PetClinic();

            Console.WriteLine("--- Start Vaccination Process (Watch System Log) ---\n");

            clinic.vaccinateCat("Mimi", 4, "John", "Rabies", "Lot-A1", "Pfizer", storage);
            clinic.vaccinateCat("Oreo", 0, "Jane", "Feline Flu", "Lot-B2", "Merck", storage); // ลูกแมว Age 0
            clinic.vaccinateCat("Khai", 5, "Somchai", "Rabies", "Lot-A2", "Pfizer", storage);
            clinic.vaccinateCat("Som", 12, "Somsri", "Leukemia", "Lot-C3", "Zoetis", storage); // แมวแก่ Age 12
            clinic.vaccinateCat("Dum", 2, "Tony", "Rabies", "Lot-A1", "Pfizer", storage);

            Console.WriteLine("\n--- Medical Records Report ---");
            Console.WriteLine(clinic.ShowAllRecords());

            Console.ReadLine();
        }
    }
}