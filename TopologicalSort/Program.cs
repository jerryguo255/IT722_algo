using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {

            List<VertexforToplog> sortedList = new List<VertexforToplog>();
            //1 create a target list
            List<VertexforToplog> startList = new List<VertexforToplog>();
            //2 create a startlist for processing
            StreamReader stdin = new StreamReader("..\\..\\courses.txt");
            Console.SetIn(stdin);//standard input from txt file




            //3 init empty vertex list (number of vertex)
            int vertexNum = int.Parse(Console.ReadLine());// get the number of tasks  :3
            List<VertexforToplog> vertexList = new List<VertexforToplog>();
            for (int i = 0; i < vertexNum; i++)
            {
                vertexList.Add(new VertexforToplog(Console.ReadLine(), i));
                //add data  0:go  1:ready  2:set
            }
            //3 End

            string input = Console.ReadLine();
            //4 load des pairs in to vertexlist
            while (input != null)
            {
                string[] words = input.Split(' ');
                int vertexIndex = int.Parse(words[0]);
                int neibVertexIndex = int.Parse(words[1]);
                vertexList[vertexIndex].Addneighbour(vertexList[neibVertexIndex]);//first  dst pair
                vertexList[neibVertexIndex].IncomingEdge += 1;
                input = Console.ReadLine();
            }

            // when vertexlist has an vertex
            while (vertexList.Count != 0)
            {
                for (int i = 0; i < vertexList.Count; i++)
                { // traverse list  find all vertex that it's incomingEdge is 0, add to StartList
                    if (vertexList[i].IncomingEdge == 0) //if the vertex's IncomingEdge is 0
                    {
                        startList.Add(vertexList[i]);  // add to start list
                        vertexList.Remove(vertexList[i]); //remove from vertexList
                    }
                }

                foreach (var item in startList.ToList())
                {//process the startList
                    foreach (VertexforToplog adj in item.adjs)
                    {
                        adj.IncomingEdge--;
                    }
                    startList.Remove(item);
                    sortedList.Add(item);
                }
            }

        
            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }


    }
}
