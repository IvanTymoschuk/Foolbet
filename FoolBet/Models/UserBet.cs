﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoolBet
{
    public class UserBet
    {
        public int ID { get; set; }
        virtual public Coeficient Coef { get; set; }
        public double Price { get; set; }
        virtual public Accounts Accounts { get; set; }
    }
}
