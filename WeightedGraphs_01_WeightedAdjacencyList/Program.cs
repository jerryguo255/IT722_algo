using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraphs_01_WeightedAdjacencyList
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stdin = new StreamReader("..\\..\\input.txt");
            Console.SetIn(stdin);//standard input from txt file
            int vnum = int.Parse(Console.ReadLine());

            List<WeightedVertex> WVlist = new List<WeightedVertex>();
            for (int i = 0; i < vnum; i++)
            {
                WVlist.Add(new WeightedVertex(i));
            }
            string input = Console.ReadLine();
            while (input != "#")
            {
                string[] words = input.Split(' ');
                int vertexId = int.Parse(words[0]);
                int adjID = int.Parse(words[1]);
                int edgeWeight = int.Parse(words[2]);

                WVlist[vertexId].AddneighbourWithWeight(WVlist[adjID], edgeWeight);
                input = Console.ReadLine();
            }

            foreach (var item in WVlist)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
