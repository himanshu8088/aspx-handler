using System;
using System.IO;

namespace Tsp.Net
{
    public class Program
    {        
        static void Main(string[] args)
        {
            string path = args[0];
            Tspx tspx = new Tspx(path);
            tspx.CreateCodeBehindTemplate();
            //PageDefault pageDefault = new PageDefault();
            Console.ReadKey();            
        }               
    }
}
