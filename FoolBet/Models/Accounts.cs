using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
     public class Accounts
    {
        public Accounts()
        {
            Bets = new List<UserBet>();
        }
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserBet> Bets { get; set; }


    }
}
