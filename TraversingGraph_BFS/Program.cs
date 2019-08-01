using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversingGraph_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            //const int UNDISCOVERED = 0;
            //const int DISCOVERED = 1;
            //const int PROCESSED = 2;
            //const int NONE = -1;
            List<VertexForBFS> Vlist = new List<VertexForBFS>();
            StreamReader stdin = new StreamReader("..\\..\\input.txt");
            Console.SetIn(stdin);//standard input from txt file
            //1 load the num of vertex
            int numOfVertex = int.Parse(Console.ReadLine());

            //1.1 init vertexList
            for (int i = 0; i < numOfVertex; i++)
            {
                Vlist.Add(new VertexForBFS(i));
            }
            // end of 1
            //2 load the start point and end point
            string[] ints = Console.ReadLine().Split(' ');
            int startPoint = int.Parse(ints[0]);
            int endPoint = int.Parse(ints[1]);
            // end of 2
            // 3 add adjs and sorts them
            string input = Console.ReadLine();
            while (input !=null)
            {
                // Regex.Split(s,"")
                string[] words = input.Split(' ');
                int vertId = int.Parse(words[0]);
                int neiId = int.Parse(words[1]);
                Vlist[vertId].adjs.Add(Vlist[neiId]);


               // Console.WriteLine(input);
                input = Console.ReadLine();
            }
            // end of 3

           

            //4 
             
            var processQueue = new Queue<VertexForBFS>();
            processQueue.Enqueue(Vlist[startPoint]);// 1 起始点v2 加到 ProcessingQuere  ;
            Vlist[startPoint].Status = StatusForTG01.Discover;
            while (processQueue.Count !=0)//处理v2 in ProcessingQuere 
            {
                VertexForBFS processingVertex = processQueue.Dequeue();//出列队
                foreach (VertexForBFS adj in processingVertex.adjs)//遍历v2.adj
                {
                    if (adj.Status == StatusForTG01.Undiscover)//仅undiscover的adj
                    {
                        adj.Parent = processingVertex.Id;  // set parent for the adj
                        processQueue.Enqueue(adj);  // adj 入列队
                        adj.Status = StatusForTG01.Discover; //一旦入列队，标记Discover
                    }
                }
                processingVertex.Status = StatusForTG01.Processed; // 一旦出列队，标记Process
            }

            // from endpoint's parent 's parent 's parent till reach the startpoint, than reverse the list.
            List<int> output = new List<int>() ;
            int target = endPoint;
            output.Add(endPoint);  //2 0 1
            while (target != startPoint)
            {
                target = Vlist[target].Parent;
                output.Add(target);
            }
            output.Reverse();//reverse it !!
            foreach (var item in output)
            {
                Console.Write(item.ToString()+' ');
            }
            Console.ReadKey();
        }
    }
}
