using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Lab01_adjacency_list_for_graph
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stdin = new StreamReader("test.txt");
            Console.SetIn(stdin);
            // ---- 

            int vertexNum = int.Parse(Console.ReadLine());

            List<Vertex> vertexes = new List<Vertex>();
            for (int i = 0; i < vertexNum; i++)
            {
                vertexes.Add(new Vertex(i));
            }
            // init the List of Vertex  

            

            string input = Console.ReadLine();
            // Regex.Split(s,"")
            string[] words = input.Split(' ');
            int vertId = int.Parse(words[0]);
            int neiId = int.Parse(words[1]);




            while (vertId != -1 && neiId != -1)
            {
                vertexes[vertId].Addneighbour(vertexes[neiId]);
                vertexes[neiId].Addneighbour(vertexes[vertId]); 


                input = Console.ReadLine();
                words = input.Split(' ');
                vertId = int.Parse(words[0]);
                neiId = int.Parse(words[1]);
            }

            foreach (var item in vertexes)
            {
                Console.WriteLine(item);
            }


            //----------------- standard input with TXT file-------
            //Console.WriteLine("Started");

            //StreamReader stdin = new StreamReader("test.txt");
            //Console.SetIn(stdin);
            //string name =  Console.ReadLine();
            //while (name != "#")
            //{
            //    Console.WriteLine(name);
            //    name = Console.ReadLine();
            //    Thread.Sleep(1111);
            //}
            //----------------- standard input with TXT file-------


            Console.ReadKey();
        }
    }
}
