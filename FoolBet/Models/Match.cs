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


        public double FirstWin { get; set; }
        public double SecondWin { get; set; }
        public double Draw { get; set; }
        //public List<UserBet> userBets { get; set; }

    }
}
