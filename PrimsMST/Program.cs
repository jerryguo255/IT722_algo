using Priority_Queue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimsMST
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random r = new Random();
            //int num = 10;
            //int weight = num;
            //SimplePriorityQueue<WeightedVertex> pqlist = new SimplePriorityQueue<WeightedVertex>();
            //List<WeightedVertex> Wlist = new List<WeightedVertex>();
            //for (int i = 0; i < num; i++)
            //{

            //    Wlist.Add(new WeightedVertex(i));

            //}

            //foreach (var item in Wlist)
            //{
            //   Console.WriteLine(item);

            //}
            //pqlist.Enqueue(Wlist[2],3);
            //pqlist.Enqueue(Wlist[2],1);
            //pqlist.Enqueue(Wlist[5],2);
            //Console.WriteLine("==============");

            //while (pqlist.Count !=0)
            //{
            //    var xxx = pqlist.Dequeue();
            //    Console.WriteLine(xxx);
            //}
            ////foreach (var item in pq)
            ////{
            ////    Console.WriteLine(item);

            ////}
            //Console.ReadLine();
            ////===========================

            Program p = new Program();
            var LoadedList = p.CreateNLoad_WeightedVertex();

            Console.WriteLine(p.Cal_LeastCostViaPrimsMST(LoadedList));
            Console.ReadKey();
        }


        int Cal_LeastCostViaPrimsMST(List<WeightedVertexForPMST> LoadVList)
        {
            var PQ = new SimplePriorityQueue<WeightedVertexForPMST>();

            PQ.Enqueue(LoadVList[0], LoadVList[0].KeyValue=0);

            while (PQ.Count != 0)
            {
                var processingV = PQ.Dequeue();
                processingV.Visited = true;
                for (int i = 0; i < processingV.adjs.Count; i++)
                {
                    var theAdj = processingV.adjs[i];
                    if (!theAdj.Visited)
                    {
                        var edgeWeight_ForTheAdjAndProcessingV = processingV.AdjWeightPair[theAdj.Id];
                        if (edgeWeight_ForTheAdjAndProcessingV < theAdj.KeyValue)
                        {
                            theAdj.KeyValue = edgeWeight_ForTheAdjAndProcessingV;
                            theAdj.Parent = processingV.Id;
                            PQ.Enqueue(theAdj, theAdj.KeyValue);
                        }
                    }
                }

            }
            int total = 0;
            foreach (var item in LoadVList)
            {
                total += item.KeyValue;
            }
            return total;
        }

        List<WeightedVertexForPMST> CreateNLoad_WeightedVertex()
        {
            StreamReader stdin = new StreamReader("..\\..\\input.txt");
            Console.SetIn(stdin);//standard input from txt file
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            int VertexNum = int.Parse(words[0]);//get the number of Vertex
            int EdgeNum = int.Parse(words[1]);  //get the number of Edge


            List<WeightedVertexForPMST> WVlist = new List<WeightedVertexForPMST>();
            for (int i = 1; i < VertexNum + 1; i++)
            {
                WVlist.Add(new WeightedVertexForPMST(i));
            }//init empty vertexList




            //load adjs and weight
            for (int i = 0; i < EdgeNum; i++)
            {
                words = Console.ReadLine().Split(' ');
                int vertexId = int.Parse(words[0]);
                int adjID = int.Parse(words[1]);
                int edgeWeight = int.Parse(words[2]);
                WVlist[vertexId - 1].AddneighbourWithWeight(WVlist[adjID - 1], edgeWeight);
            }


            //foreach (var item in WVlist)
            //{
            //    Console.WriteLine(item);
            //}
            return WVlist;
        }
    }
}
