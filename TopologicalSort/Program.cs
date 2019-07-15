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

            // StreamReader stdin = new StreamReader("..\\..\\topologicalSort.txt");
            // Console.SetIn(stdin);//standard input from txt file


            //2 init empty vertex list (number of vertex)
            int vertexNum = int.Parse(Console.ReadLine());// get the number of tasks  :3
            List<VertexforToplog> startList = new List<VertexforToplog>();
            for (int i = 0; i < vertexNum; i++)
            {
                startList.Add(new VertexforToplog(Console.ReadLine()));
                //add data  0:go  1:ready  2:set
            }
            //2 End


            //3 load des pairs
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            int vertexIndex = int.Parse(words[0]);
            int neibVertexIndex = int.Parse(words[1]);
            startList[vertexIndex].Addneighbour(startList[neibVertexIndex]);//first  dst pair
            startList[neibVertexIndex].IncomingEdge += 1;

            input = Console.ReadLine();
            words = input.Split(' ');
            vertexIndex = int.Parse(words[0]);
            neibVertexIndex = int.Parse(words[1]);
            startList[vertexIndex].Addneighbour(startList[neibVertexIndex]);//second  dst pair
            startList[neibVertexIndex].IncomingEdge += 1;  //add 1 to neibour incomeEdge
            //3 End

            while (startList.Count != 0)
            {
                for (int i = 0; i < startList.Count; i++)
                {
                    if (startList[i].IncomingEdge == 0)//if the vertex's incomeEdge
                    {
                        if (startList[i].adj.Count != 0)  //if the vertex has a neib
                        {
                            startList[i].adj[0].IncomingEdge = 0;//set the neib's vertex to 0
                        }
                        sortedList.Add(startList[i]);         //add the vertex to sorted list
                        startList.RemoveAt(i);        //remove the vertex from origin list
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
