using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimsMST
{
     class WeightedVertexForPMST : IComparable<WeightedVertexForPMST>
    {
        public int Id { get; set; }//0
        public List<WeightedVertexForPMST> adjs = new List<WeightedVertexForPMST>();
        public Dictionary<int,int> AdjWeightPair = new Dictionary<int, int>();
        //1 2              
        public bool Visited { get; set; }
        public int KeyValue { get; set; }
        public int Parent { get; set; }
        public WeightedVertexForPMST(int Id)
        {
            this.Id = Id;
            Visited = false;
            KeyValue = int.MaxValue;
        }

        public void AddneighbourWithWeight(WeightedVertexForPMST nbr,int weightforNb)
        {
            if (!adjs.Contains(nbr))
            {
                adjs.Add(nbr);
                AdjWeightPair.Add(nbr.Id,weightforNb);

                nbr.adjs.Add(this);
                nbr.AdjWeightPair.Add(this.Id, weightforNb);
                nbr.adjs.Sort();//无向图，所以需要互加邻居
                adjs.Sort();
            }
        }

        public override string ToString()
        {
            string adjsWithWeight = null;
            foreach (var adj in adjs)
            {
                adjsWithWeight += string.Format("{0}({1}) ", adj.Id.ToString(), AdjWeightPair[adj.Id]);
            }
            return string.Format("{0}: {1}", Id, adjsWithWeight);
            //return this.Id.ToString();
        }

        public override bool Equals(object obj)
        {
            WeightedVertexForPMST other = obj as WeightedVertexForPMST;
            return this.Id == other.Id;
        }

        public int CompareTo(WeightedVertexForPMST other)
        {
            return Id - other.Id;
        }

    }
}
