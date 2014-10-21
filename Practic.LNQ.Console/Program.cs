using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LNQ.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Practice.LNQ.LNQ lnq = new Practice.LNQ.LNQ();
            Console.WriteLine("Delegate");
            Console.WriteLine("ToString:  {0}", lnq.TraiangleArea.ToString());
            Console.WriteLine("Value: {0}", lnq.TraiangleArea(7, 12));


        }
    }
}
