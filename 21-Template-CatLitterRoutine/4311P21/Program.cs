using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4311P21
{

    public abstract class CatLitterRoutine
    {
        public void useLitterBox()
        {
            walkToBox();   
            digSand();     
            doBusiness();  
            coverSand();   
            cleanSelf();   
            Console.WriteLine("----------------------------------");
        }

        protected void walkToBox()
        {
            Console.WriteLine("   -> 1. Walks into the litter box.");
        }

        protected void doBusiness()
        {
            Console.WriteLine("   -> 3. Does personal business (pee/poop).");
        }

        protected abstract void digSand();
        protected abstract void coverSand();
        protected virtual void cleanSelf()
        {
 
        }
    }

    // แมวเจ้าระเบียบ
    public class NeatCat : CatLitterRoutine
    {
        private string ownerAction;

        public NeatCat(string action)
        {
            this.ownerAction = action;
        }

        public void setOwnerAction(string action)
        {
            this.ownerAction = action;
        }

        protected override void digSand()
        {
            Console.WriteLine("   -> 2. Digs a deep hole, preparing the area well.");
        }

        protected override void coverSand()
        {
            Console.WriteLine("   -> 4. Covers the sand perfectly, leaving no trace.");
        }

        protected override void cleanSelf()
        {
            Console.WriteLine($"   -> 5. Sits down and cleans itself. The owner sees this and gives a [{ownerAction}]!");
        }
    }

    public class LazyCat : CatLitterRoutine
    {
        protected override void digSand()
        {
            Console.WriteLine("   -> 2. Scratches the sand lightly (barely digging).");
        }

        protected override void coverSand()
        {
            Console.WriteLine("   -> 4. Doesn't cover! Leaves a mess and jumps out.");
        }

    }

    class Program
    {
        static void Client(CatLitterRoutine catRoutine)
        {
            catRoutine.useLitterBox();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==========  NEAT CAT ROUTINE ==========");
            NeatCat neatCat = new NeatCat("Big Hug");
            Client(neatCat);

            Console.WriteLine("\n=========  NEAT CAT (Changed Owner Action) ==========");
            neatCat.setOwnerAction("Kiss on the head");
            Client(neatCat);

            Console.WriteLine("\n========== LAZY CAT ROUTINE =========");
            CatLitterRoutine lazyCat = new LazyCat();
            Client(lazyCat);

            Console.ReadLine();
        }
    }
}