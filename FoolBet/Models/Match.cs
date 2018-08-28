using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class Match
    {
        public Match()
        {
            Coefs = new List<Coeficient>();
        }
        public int ID { get; set; }
        virtual public Team TeamHome { get; set; }
        virtual public Team TeamAway { get; set; }
        public DateTime MatchDate { get; set; }
        public string Score { get; set; }


        virtual public List<Coeficient> Coefs { get; set; }

    }
}
