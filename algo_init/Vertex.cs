using System;
using System.Collections.Generic;

namespace Lab01_adjacency_list_for_graph
{
    class Vertex : IComparable<Vertex>
    {
        public int Id { get; set; }
        public int IncomingEdge { get; set; }

        public List<Vertex> adj = new List<Vertex>();  //相邻元素的ID

        public Vertex(int Id)
        {
            this.Id = Id;
        }

        public void Addneighbour(Vertex nbr)
        {
            if (!adj.Contains(nbr))
            {
                adj.Add(nbr);
            }
            adj.Sort();
        }

        public override string ToString()
        {
            string neig = null;
            foreach (var item in adj)
            {
                neig += " " + item.Id.ToString();
            }
            return string.Format("{0}:{1}", Id, neig);
        }

        public override bool Equals(object obj)
        {
            Vertex other = obj as Vertex;
            return this.Id == other.Id;
        }

        public int CompareTo(Vertex other)
        {
            return Id - other.Id;
        }
    }
}
