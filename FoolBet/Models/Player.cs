using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class Player
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        virtual public Team Team { get; set; }
        public string Country { get; set; }
        public string Position { get; set; }
    }
}
