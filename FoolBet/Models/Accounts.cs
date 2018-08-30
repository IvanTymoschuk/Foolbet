using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
     public class Accounts : INotifyPropertyChanged
    {
        public Accounts()
        {
            Bets = new List<UserBet>();
        }

        private decimal money;


        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Money {
            get
            {
                return money;
            }
            set
            {
                money = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Money"));
            }
        }
        virtual public List<UserBet> Bets { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
