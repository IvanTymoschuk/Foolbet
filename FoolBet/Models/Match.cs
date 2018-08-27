using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class Match
    {
        public int ID { get; set; }
        public Team TeamHome { get; set; }
        public Team TeamAway { get; set; }
        public DateTime MatchTime { get; set; }
        public List<BetProperties> Properties { get; set; }

    }
}
