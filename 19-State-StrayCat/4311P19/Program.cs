using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P19
{

    public class StrayCat
    {
        private CatState state;

        public StrayCat(CatState s)
        {
            changeState(s);
        }

        public void changeState(CatState s)
        {
            this.state = s;
            this.state.setCat(this);
            Console.WriteLine($"\n>> state: {s.getMood()}");
        }

        public void giveFood(string food)
        {
            state.giveFood(food);
        }

        public void approachSlowly()
        {
            state.approachSlowly();
        }

        public void tryToTouch()
        {
            state.tryToTouch();
        }

        public void makeLoudNoise()
        {
            state.makeLoudNoise();
        }
    }

    public abstract class CatState
    {
        protected string mood;
        protected StrayCat cat;

        public void setCat(StrayCat bc)
        {
            this.cat = bc;
        }
        public string getMood()
        {
            return mood;
        }
        public abstract void giveFood(string food);
        public abstract void approachSlowly();
        public abstract void tryToTouch();
        public abstract void makeLoudNoise();
    }
    // สถานะที่ 1: หวาดกลัว
    public class Fearful : CatState
    {
        public Fearful() { mood = "fearful"; }
        public override void giveFood(string food)
        {
            if (food == "fish") 
            {
                Console.WriteLine($"Cat slowly comes out to eat {food}.");
                cat.changeState(new Curious());
            }
            else
            {
                Console.WriteLine("Cat looks at the food but stays hidden.");
            }
        }

        public override void approachSlowly()
        {
            Console.WriteLine("Cat runs away and hides deeper!");
        }

        public override void tryToTouch()
        {
            Console.WriteLine("Cat hisses at you! (ขู่ฟ่อ)");
        }

        public override void makeLoudNoise()
        {
            Console.WriteLine("Cat panics and runs away!");
        }
    }

    // สถานะที่ 2: อยากรู้อยากเห็น
    public class Curious : CatState
    {
        public Curious() { mood = "curious"; }

        public override void giveFood(string food)
        {
            Console.WriteLine($"Cat happily eats {food}.");
        }
        public override void approachSlowly()
        {
            Console.WriteLine("Cat watches you closely but doesn't run.");
            cat.changeState(new Relaxed()); // ขยับเข้าไปใกล้สำเร็จ
        }
        public override void tryToTouch()
        {
            Console.WriteLine("Cat dodges your hand and steps back.");
            cat.changeState(new Fearful()); // พยายามจับเร็วไป แมวหนีกลับไปกลัว
        }
        public override void makeLoudNoise()
        {
            Console.WriteLine("Cat is startled!");
            cat.changeState(new Fearful());
        }
    }
    // สถานะที่ 3: ผ่อนคลาย
    public class Relaxed : CatState
    {
        public Relaxed() { mood = "relaxed"; }

        public override void giveFood(string food)
        {
            Console.WriteLine($"Cat eats {food} and sits comfortably.");
        }
        public override void approachSlowly()
        {
            Console.WriteLine("Cat closes its eyes and rests.");
        }
        public override void tryToTouch()
        {
            Console.WriteLine("Cat sniffs your hand and lets you pet its head!");
            cat.changeState(new Trusting()); 
        }
        public override void makeLoudNoise()
        {
            Console.WriteLine("Cat stands up, looking alert.");
            cat.changeState(new Curious()); // ตกใจเสียงดัง ถอยกลับไประแวงนิดๆ
        }
    }

    // สถานะที่ 4: ไว้ใจ
    public class Trusting : CatState
    {
        public Trusting() { mood = "trusting"; }

        public override void giveFood(string food)
        {
            Console.WriteLine($"Cat meows loudly, asking for more {food}!");
        }

        public override void approachSlowly()
        {
            Console.WriteLine("Cat walks towards you and rubs against your legs.");
        }

        public override void tryToTouch()
        {
            Console.WriteLine("Cat purrs loudly. ");
        }

        public override void makeLoudNoise()
        {
            Console.WriteLine("Cat jumps a little but stays near you.");
            cat.changeState(new Relaxed()); 
        }
    }

    class Program
    {
        static void Client()
        {
            StrayCat blackcat = new StrayCat(new Fearful());

            Console.WriteLine("\n--- You try to approach the cat ---");
            blackcat.approachSlowly(); // แมววิ่งหนี

            Console.WriteLine("\n--- You try to pet it ---");
            blackcat.tryToTouch(); // แมวขู่

            Console.WriteLine("\n--- You give it 'Fish' ---");
            blackcat.giveFood("fish"); // แมวเปลี่ยนเป็น Curious

            Console.WriteLine("\n--- You approach slowly again ---");
            blackcat.approachSlowly(); // แมวเปลี่ยนเป็น Relaxed

            Console.WriteLine("\n--- You accidentally drop your keys! (Loud Noise) ---");
            blackcat.makeLoudNoise(); // แมวตกใจ กลับไป Curious

            Console.WriteLine("\n--- You approach slowly again ---");
            blackcat.approachSlowly(); // แมวเปลี่ยนกลับมา Relaxed

            Console.WriteLine("\n--- You reach out to pet it ---");
            blackcat.tryToTouch(); // แมวเปลี่ยนเป็น Trusting ยอมให้จับแล้ว!

            Console.WriteLine("\n--- You pet it again ---");
            blackcat.tryToTouch(); // แมวครางกรนอย่างมีความสุข
        }

        static void Main(string[] args)
        {
            Client();
            Console.ReadLine();
        }
    }
}