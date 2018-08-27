using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public League League  { get; set; }
        public string Coach { get; set; }
        public List<Player> Players { get; set; }
    }
}
