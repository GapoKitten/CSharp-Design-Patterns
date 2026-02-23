using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P14
{
    class RoboBall
    {
        public void rolling()
        {
            Console.WriteLine("🟢 RoboBall: กลิ้งหลุนๆ ไปข้างหน้า... (Rolling...)");
        }

        public void spin()
        {
            Console.WriteLine("🟢 RoboBall: หมุนติ้วรอบตัวเองเร็วจี๋! (Spinning!)");
        }

        public void meow()
        {
            Console.WriteLine("🟢 RoboBall: ส่งเสียงร้องเมี๊ยวจากลำโพง! (Meow!)");
        }

        // --- ท่าใหม่สำหรับลูกบอล ---
        public void vibrate()
        {
            Console.WriteLine("🟢 RoboBall: สั่นดึ๋งๆ เรียกร้องความสนใจ! (Vibrating!)");
        }
    }

    interface Command
    {
        void execute();
    }


    class Rolling : Command
    {
        private RoboBall ball;
        public Rolling(RoboBall ball) 
        {
            this.ball = ball;
        }
        public void execute() 
        {
            ball.rolling();
        }
    }

    class Spin : Command
    {
        private RoboBall ball;
        public Spin(RoboBall ball)
        {
            this.ball = ball;
        }
        public void execute()
        {
            ball.spin();
        }
    }

    class Meow: Command
    {
        private RoboBall ball;
        public Meow(RoboBall ball)
        {
            this.ball = ball;
        }
        public void execute() 
        {
            ball.meow(); 
        }
    }

    class Vibrate : Command
    {
        private RoboBall ball;
        public Vibrate(RoboBall ball)
        {
            this.ball = ball;
        }
        public void execute()
        {
            ball.vibrate();
        }
    }

    class Controller
    {
        private Command  command;

        public Controller()
        {
            command = null; 
        }
        public void setCommand(Command command) 
        {
            this.command = command;
        }
        public void pressButton()
        {
            if (command != null) command.execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            RoboBall myBall = new RoboBall();
            Controller remote = new Controller();

            Rolling roll = new Rolling(myBall);
            Spin spin = new Spin(myBall);
            Meow meow = new Meow(myBall);
            Vibrate vib = new Vibrate(myBall); 

            Console.WriteLine("--- Playing with RoboBall ---");
            remote.setCommand(roll);
            remote.pressButton();

            remote.setCommand(vib);
            remote.pressButton();

            remote.setCommand(spin);
            remote.pressButton();

            remote.setCommand(meow);
            remote.pressButton();

            Console.ReadLine();
        }
    }
}