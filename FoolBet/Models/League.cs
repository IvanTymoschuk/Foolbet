using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class League
    {
        public League()
        {
            Teams = new List<Team>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Team> Teams { get; set; }
    }
}
