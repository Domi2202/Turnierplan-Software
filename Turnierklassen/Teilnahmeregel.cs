using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierklassen
{
    public class Teilnahmerregel
    {
        public struct Kandidat
        {
            public int Group { get; set; }
            public int Rank { get; set; }

            public Kandidat(int group, int rank)
            {
                Group = group;
                Rank = rank;
            }
        }
        public List<Kandidat> CriteriaList { get; set; } = new List<Kandidat>();
        public string Name { get; set; }

        public void AddCriteria(int group, int rank)
        {
            CriteriaList.Add(new Kandidat(group, rank));
            Name = rank + ". Gruppe " + group;
        }
    }
}
