using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraphs_01_WeightedAdjacencyList
{
     class WeightedVertex : IComparable<WeightedVertex>
    {
        public int Id { get; set; }//0
        public List<WeightedVertex> adjs = new List<WeightedVertex>();
        public Dictionary<int,int> VidWeightPair = new Dictionary<int, int>();
        //1 2              
        // public StatusForTG01 Status { get; set; }         
        //   public int Parent { get; set; }
        public WeightedVertex(int Id)
        {
            this.Id = Id;
            //Status = StatusForTG01.Undiscover;
           // Parent = -1;
        }

        public void AddneighbourWithWeight(WeightedVertex nbr,int weightforNb)
        {
            if (!adjs.Contains(nbr))
            {
                adjs.Add(nbr);
                VidWeightPair.Add(nbr.Id,weightforNb);
                adjs.Sort();
            }
        }

        public override string ToString()
        {
            string adjsWithWeight = null;
            foreach (var adj in adjs)
            {
                adjsWithWeight += string.Format("{0}({1}) ", adj.Id.ToString(), VidWeightPair[adj.Id]);
            }
            return string.Format("{0}: {1}", Id, adjsWithWeight);
            //return this.Id.ToString();
        }

        public override bool Equals(object obj)
        {
            WeightedVertex other = obj as WeightedVertex;
            return this.Id == other.Id;
        }

        public int CompareTo(WeightedVertex other)
        {
            return Id - other.Id;
        }

    }
    public enum StatusForTG01 {
        NONE = -1, Undiscover =0, Discover , Processed
    }
}
