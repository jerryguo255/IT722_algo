using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversingGraph_01_ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stdin = new StreamReader("..\\..\\input.txt");
            Console.SetIn(stdin);//standard input from txt file
            string input = Console.ReadLine();
            while (input !=null)
            {
                Console.WriteLine(input);
                input = Console.ReadLine();
            } 
            Console.ReadKey();
        }
    }
}
