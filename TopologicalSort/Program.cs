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

             StreamReader stdin = new StreamReader("..\\..\\topologicalSort.txt");
             Console.SetIn(stdin);//standard input from txt file

            List<VertexforToplog> startList1 = new List<VertexforToplog>();


            //2 init empty vertex list (number of vertex)
            int vertexNum = int.Parse(Console.ReadLine());// get the number of tasks  :3
            List<VertexforToplog> vertexList = new List<VertexforToplog>();
            for (int i = 0; i < vertexNum; i++)
            {
                vertexList.Add(new VertexforToplog(Console.ReadLine(),i));
                //add data  0:go  1:ready  2:set
            }
            //2 End

            string input = Console.ReadLine();
            //3 load des pairs
            while (input != null)
            {
                string[] words = input.Split(' ');
                int vertexIndex = int.Parse(words[0]);
                int neibVertexIndex = int.Parse(words[1]);
                vertexList[vertexIndex].Addneighbour(vertexList[neibVertexIndex]);//first  dst pair
                vertexList[neibVertexIndex].IncomingEdge += 1;
                input = Console.ReadLine();
            }

            foreach (var item in vertexList)
            {
                Console.WriteLine(item);
            }

            while (vertexList.Count != 0)
            {
                for (int i = 0; i < vertexList.Count; i++)
                {
                    if (vertexList[i].IncomingEdge == 0)//if the vertex's incomeEdge
                    {
                        if (vertexList[i].adj.Count != 0)  //if the vertex has a neib
                        {
                            vertexList[i].adj[0].IncomingEdge = 0;//set the neib's vertex to 0
                        }
                        sortedList.Add(vertexList[i]);         //add the vertex to sorted list
                        vertexList.RemoveAt(i);        //remove the vertex from origin list
                    }
                }
            }
            // print out the sorted list

            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
