using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversingGraph_BFS
{
    class VertexForBFS : IComparable<VertexForBFS>
    {
        public int Id { get; set; }//0
        public List<VertexForBFS> adjs = new List<VertexForBFS>();  //1 2
        public StatusForTG01 Status { get; set; }//
        public int Parent { get; set; }//

        public VertexForBFS(int Id)
        {
            this.Id = Id;
            Status = StatusForTG01.Undiscover;
            Parent = -1;
        }

        public void Addneighbour(VertexForBFS nbr)
        {
            if (!adjs.Contains(nbr))
            {
                adjs.Add(nbr);
            }
            adjs.Sort();
        }

        public override string ToString()
        {
            //string neig = null;
            //foreach (var item in adjs)
            //{
            //    neig +=  item.Id.ToString() + ",";
            //}
            //return string.Format("Id:{0}|Adjs:{1} |Parent:{2}", Id, neig,Parent);
            return this.Id.ToString();
        }

        public override bool Equals(object obj)
        {
            VertexForBFS other = obj as VertexForBFS;
            return this.Id == other.Id;
        }

        public int CompareTo(VertexForBFS other)
        {
            return Id - other.Id;
        }

    }
    public enum StatusForTG01 {
        NONE = -1, Undiscover =0, Discover , Processed
    }
}
