using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraMST
{
    class WeightedVertexForDMST : IComparable<WeightedVertexForDMST>
    {
        public int Vid { get; set; }
        public bool Visited { get; set; }
        public List<WeightedVertexForDMST> Adjs { get; set; }
        public Dictionary<int,int> WeightListRelativeToThisV { get; set; }
        public int ShortestPathfromStartPoint { get; set; }
        public int PerdID { get; set; }

        public WeightedVertexForDMST(int id)
        {
            Vid = id;
            Adjs = new List<WeightedVertexForDMST>();
            WeightListRelativeToThisV = new Dictionary<int, int> ();
            Visited = false;
            ShortestPathfromStartPoint = int.MaxValue;  
        }

       public void AddAdjsWithWeight(WeightedVertexForDMST v, int weight ) {
            this.Adjs.Add(v);
            WeightListRelativeToThisV.Add(v.Vid,weight);
        }
        
        public override string ToString()
        {
            string outadj=null;

            foreach (var item in Adjs)
            {
                outadj += item.Vid.ToString()+",";
            }
            return string.Format("VID:{0} | Perd:{3}|Visited:{4}| ShortestPath:{1}| Adjs:{2}",Vid, ShortestPathfromStartPoint,outadj,PerdID,Visited);
        }

        public int CompareTo(WeightedVertexForDMST other)
        {
            return this.Vid - other.Vid;
        }
    }
}
