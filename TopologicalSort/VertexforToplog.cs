using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    class VertexforToplog //: IComparable<VertexforToplog>
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int IncomingEdge { get; set; }

        public List<VertexforToplog> adj = new List<VertexforToplog>();  //相邻元素的ID

        public VertexforToplog(string Data, int Id)
        {
            this.Data = Data;
            this.Id = Id;
        }

        public void Addneighbour(VertexforToplog nbr )
        {
            if (!adj.Contains(nbr))
            {
                adj.Add(nbr);
            }
            //adj.Sort();
        }

        public override string ToString()
        {
            return string.Format("ID:{1}  Data:{0} ", Data,Id);
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
