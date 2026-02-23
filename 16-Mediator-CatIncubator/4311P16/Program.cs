using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P16
{
    public interface IncubatorMediator
    {
        void notify(IncubatorComponent sender, string eventCode);
    }

    public class IncubatorController : IncubatorMediator
    {
        private Heater heater;
        private Ventilator ventilator;
        private Humidifier humidifier;
        private SirenAlarm alarm;

        public IncubatorController(Heater h, Ventilator v, Humidifier m, SirenAlarm a)
        {
            this.heater = h;
            this.ventilator = v;
            this.humidifier = m;
            this.alarm = a;

            this.heater.setMediator(this);
            this.ventilator.setMediator(this);
            this.humidifier.setMediator(this);
            this.alarm.setMediator(this);
        }

        public void runTest()
        {
            Console.WriteLine("\n>>> [Mediator]: STARTING SYSTEM PRE-CHECK <<<");
            heater.checkHeatCoil();
            ventilator.silentMode();
            humidifier.refillWater();
            alarm.testSound();
            Console.WriteLine(">>> [Mediator]: PRE-CHECK COMPLETE (Ready to use)\n");
        }

        public void notify(IncubatorComponent sender, string eventCode)
        {
            if (sender == heater && eventCode == "device_active")
            {
                Console.WriteLine(">> [Mediator]: Heater ON -> Balance Env.");
                if (!humidifier.isRunning()) humidifier.activate();
                if (ventilator.isRunning()) ventilator.deActivate();
                if (alarm.isRunning()) alarm.deActivate();
            }
            else if (sender == ventilator && eventCode == "device_active")
            {
                Console.WriteLine(">> [Mediator]: OVERHEAT! -> Emergency.");
                if (heater.isRunning()) heater.deActivate();
                if (humidifier.isRunning()) humidifier.deActivate();
                if (!alarm.isRunning()) alarm.activate();
            }
            else if (sender == alarm && eventCode == "device_inactive")
            {
                Console.WriteLine(">> [Mediator]: Alarm Reset -> Standby.");
                if (ventilator.isRunning()) ventilator.deActivate();
            }
            else if (eventCode == "report_state")
            {
                Console.WriteLine("\n--- INCUBATOR STATUS ---");

                if (heater.isRunning())
                    Console.WriteLine($"Heater: ON ({heater.getTemp()} C)");
                else
                    Console.WriteLine("Heater: OFF");

                if (ventilator.isRunning())
                    Console.WriteLine($"Ventilator: ON (Level {ventilator.getRpmLevel()})");
                else
                    Console.WriteLine("Ventilator: OFF");

                if (humidifier.isRunning())
                    Console.WriteLine($"Humidifier: ON ({humidifier.getMoisture()}%)");
                else
                    Console.WriteLine("Humidifier: OFF");

                if (alarm.isRunning())
                    Console.WriteLine($"Siren: RINGING! (Vol: {alarm.getVolume()}dB)");
                else
                    Console.WriteLine("Siren: Silent");
                Console.WriteLine("------------------------\n");

            }
        }
    }

        public abstract class IncubatorComponent
    {
        protected IncubatorMediator mediator;
        private bool running;

        public void setMediator(IncubatorMediator m) { this.mediator = m; }

        public void activate()
        {
            if (running) return;
            running = true;
            if (mediator != null) mediator.notify(this, "device_active");
        }

        public void deActivate() 
        {
            if (!running) return;
            running = false;
            if (mediator != null) mediator.notify(this, "device_inactive");
        }

        public void reportState()
        {
            if (mediator != null) mediator.notify(this, "report_state");
        }

        public bool isRunning() { return running; }
    }
    public class Heater : IncubatorComponent
    {
        private double temp;
        public Heater() { temp = 37.5; }
        public void setTemp(double t) { this.temp = t; }
        public double getTemp() { return this.temp; }
        public void checkHeatCoil() { Console.WriteLine("   [Heater]: Heating Coils... OK."); }
    }

    public class Ventilator : IncubatorComponent
    {
        private int rpmLevel;
        private bool isSilentMode;

        public Ventilator() { rpmLevel = 1; isSilentMode = false; }
        public void setRpmLevel(int level) { this.rpmLevel = level; }
        public int getRpmLevel() { return this.rpmLevel; }
        public void silentMode()
        {
            isSilentMode = !isSilentMode;
            string status = isSilentMode ? "ON (Quiet)" : "OFF (Normal)";
            Console.WriteLine($"   [Ventilator]: Silent Mode is now {status}");
        }
    }

    public class Humidifier : IncubatorComponent
    {
        private int moisturePercent;
        private int waterLevel;

        public Humidifier() { moisturePercent = 45; waterLevel = 100; }
        public void setMoisture(int p) { this.moisturePercent = p; }
        public int getMoisture() { return this.moisturePercent; }
        public void refillWater() { Console.WriteLine($"   [Humidifier]: Water tank refilled to {waterLevel}%. Ready to mist."); }
    }

    public class SirenAlarm : IncubatorComponent
    {
        private int decibelLevel;
        public SirenAlarm() { decibelLevel = 80; }
        public void setVolume(int db) { this.decibelLevel = db; }
        public int getVolume() { return this.decibelLevel; }
        public void testSound() { Console.WriteLine($"   [Siren]: TEST SOUND... BEEP! BEEP! (Volume: {decibelLevel}dB)"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Heater h = new Heater();
            Ventilator v = new Ventilator();
            Humidifier m = new Humidifier();
            SirenAlarm a = new SirenAlarm();

            IncubatorController ctrl = new IncubatorController(h, v, m, a);

            Console.WriteLine("=== 1. PRE-CHECK SYSTEM ===");
            ctrl.runTest();

            Console.WriteLine("=== 2. START INCUBATION ===");
            h.setTemp(38.0);
            h.activate();
            h.reportState();

            Console.WriteLine("=== 3. EMERGENCY ===");
            v.setRpmLevel(3);
            v.activate();
            v.reportState();

            Console.WriteLine("=== 4. RECOVERY ===");
            a.deActivate();

            Console.ReadLine();
        }
    }
}