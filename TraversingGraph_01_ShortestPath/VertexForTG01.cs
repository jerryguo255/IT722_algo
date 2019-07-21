using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversingGraph_01_ShortestPath
{
    class VertexForTG01
    {
        public int Id { get; set; }
        //public string Data { get; set; }
        public int IncomingEdge { get; set; }

        public List<VertexForTG01> adjs = new List<VertexForTG01>();  //相邻元素的ID

        public int Status { get; set; }
        public int Parent { get; set; }
        public void Addneighbour(VertexForTG01 nbr)
        {
            if (!adjs.Contains(nbr))
            {
                adjs.Add(nbr);
            }
            //adjs.Sort();
        }

        public override string ToString()
        {
            return string.Format("ID:{1}  Data:{0} IncomeEdge:{2} ",Id, IncomingEdge);
        }

        //public override bool Equals(object obj)
        //{
        //    VertexforToplog other = obj as VertexforToplog;
        //    return this.Id == other.Id;
        //}

        //public int CompareTo(VertexforToplog other)
        //{
        //    return Id - other.Id;
        //}

    }
}
