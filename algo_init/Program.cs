using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Lab01_adjacency_list_for_graph
{
    class Program
    {
        static void Main(string[] args)
        {
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
            int vertId = int.Parse(words[0]);//本体
            int neiId = int.Parse(words[1]); //邻居


           // TextReader stdin = Console.In;
           // Console.SetIn(new StreamReader("text.txt"));
            while (vertId != -1 && neiId != -1)
            {
                vertexes[vertId].Addneighbour(vertexes[neiId]);

                //Vertex vNei = new Vertex(neiId);
                ////Vertex v0 = new Vertex(0);
                ////vertexes.Add(v0);
                //foreach (var item in vertexes) //0 1 ， 1 0
                //{
                //    if (item.Id == vertId)  // 0 1 2
                //    {
                //        item.Addneighbour(vNei);
                //    }
                //}
                



               // Vertex vNei = new Vertex(neiId);


                input = Console.ReadLine();
                words = input.Split(' ');
                vertId = int.Parse(words[0]);
                neiId = int.Parse(words[1]);
            }

            foreach (var item in vertexes)
            {
                Console.WriteLine(item);
            }
            

            Console.ReadLine();
        }
    }
}
