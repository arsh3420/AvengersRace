using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers_Race
{
    public class Bets:RaceGround
    {
       
        public decimal Amount;
        public string Avenger;
        public Betors Bettor;
        public decimal odds;
        public decimal DBodds;
       

        public string GetDescription()
        {
            if (Amount == 0)
                return Bettor.Name + "hasn't placed a bet";
            else
                return Bettor.Name + " placed a bet of " + Amount + " dollars on " + Avenger;
        }
     
        public decimal PayOut(string Winner)
        {
            if (Winner == Avenger)
                return Amount * odds;
            else
                return (0 - Amount);
        }
    }
}
