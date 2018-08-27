using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class UserBet
    {
        public int ID { get; set; }
        public List<Match> Matches { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
