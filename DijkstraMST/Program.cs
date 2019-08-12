using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraMST
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            Program p = new Program();
            //Random r = new Random();
            //var list = new List<WeightedVertexForDMST>();
            //for (int i = 0; i < 22; i++)
            //{
            //    list.Add(new WeightedVertexForDMST(r.Next(100)));

            //}
            //list.Sort();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            
            //=============Linq one=================
            //Random r = new Random();
            //Queue<int> pq = new Queue<int>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    //   pq.Enqueue(r.Next(100));
            //    pq.Enqueue(r.Next(100));


            //    // pq.OrderBy(x => x);
            //}
            
            
            //var pqSorter = pq.OrderBy(x => x);
           
            
            //foreach (var item in pqSorter)
            //{
            //    Console.WriteLine(item);
            //}
            
            //=============Linq one=================

            //=============heap one ==================
            //SimplePriorityQueue<int> qs = new SimplePriorityQueue<int>();
            
            //Random r = new Random();
            //for (int i = 0; i < 10000; i++)
            //{
            //    int num = r.Next(100);
            //    qs.Enqueue(num, num);
            //}
            //s.Start();
            //for (int i = 0; i < qs.Count; i++)
            //{
            //    Console.WriteLine(qs.Dequeue());
            //}
            //s.Stop();
            //=============heap one ==================





             p.ShortestWeightedPath();
            Console.WriteLine(s.Elapsed.ToString());
            Console.ReadKey();
        }

        


        List<WeightedVertexForDMST> CreatedEZDUST()
        {

            StreamReader stdin = new StreamReader("..\\..\\input_EZDUST.txt");
            Console.SetIn(stdin);//standard input from txt file
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            int VertexNum = int.Parse(words[0]);//get the number of Vertex
            int EdgeNum = int.Parse(words[1]);  //get the number of Edge


            List<WeightedVertexForDMST> WVlist = new List<WeightedVertexForDMST>();
            for (int i = 1; i < VertexNum + 1; i++)
            {
                WVlist.Add(new WeightedVertexForDMST(i));
            }//init empty vertexList
            //Console.ReadLine();

            return WVlist;
        }
        int ShortestWeightedPath()
        {
            // init
            StreamReader stdin = new StreamReader("..\\..\\input_ShortestWeightedPath.txt");
            Console.SetIn(stdin);//standard input from txt file
            int VertexNum = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            int startVid = int.Parse(words[0]);
            int destinationVid = int.Parse(words[1]);

            List<WeightedVertexForDMST> WVlist = new List<WeightedVertexForDMST>();
            for (int i = 0; i < VertexNum; i++)
            {
                WVlist.Add(new WeightedVertexForDMST(i));
            } // init

            input = Console.ReadLine();
            while (input != null)
            {
                words = input.Split(' ');
                int vid = int.Parse(words[0]);//get the number of Vertex
                int vidadj = int.Parse(words[1]);  //get the number of Edge
                int weight = int.Parse(words[2]);  //get the weight of Edge
                WVlist[vid].AddAdjsWithWeight(WVlist[vidadj], weight);
                WVlist[vid].Adjs.Sort();

                input = Console.ReadLine();
            }//load weighted adjs

            foreach (var item in WVlist)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("=====================");
            SimplePriorityQueue<WeightedVertexForDMST> PQ = new SimplePriorityQueue<WeightedVertexForDMST>();
            WVlist[startVid].ShortestPathfromStartPoint = 0; //初始化
            PQ.Enqueue(WVlist[startVid], WVlist[startVid].ShortestPathfromStartPoint);
            while (PQ.Count !=0)
            {
               var processV= PQ.Dequeue();
                processV.Visited = true;
                foreach (var item in processV.Adjs)
                { //                                     adj's                     
                    if (!item.Visited &&  processV.WeightListRelativeToThisV[item.Vid] < item.ShortestPathfromStartPoint )
                    {
                        item.ShortestPathfromStartPoint = processV.WeightListRelativeToThisV[item.Vid];
                        item.PerdID = processV.Vid;
                        PQ.Enqueue(item,item.ShortestPathfromStartPoint);
                    }
                }
            }
            foreach (var item in WVlist)
            {
                Console.WriteLine(item);
            }
            return -1;
        }
    }
}
