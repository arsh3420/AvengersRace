using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers_Race
{
    public class Betors : Bets
    {
        public Bets MyBet;
        public decimal Cash;
        public int[] BetrArray;

        public RadioButton MyRadioButton;
        public Label MyLabel;
        public Label MyLabel2;

     

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has $" + Cash;   
        }

        public void ClearBet()
        {
            MyBet = null;
            MyLabel2.Text = Name + " hasn't placed a bet";
        }

        public bool PlaceBet(int BetAmount, string AvengerToWin, decimal Test)
        {
            this.MyBet = new Bets() { Amount = BetAmount, Avenger = AvengerToWin, Bettor = this, odds = Test};
            if (BetAmount <= Cash)
            {
                 MyLabel2.Text = this.Name + " bets " + BetAmount + " dollars on " + AvengerToWin;
                  this.UpdateLabels();
                   return true;
            }
            else
            {
                  MessageBox.Show(Name + " does not have enough to cover that bet ");
                  this.MyBet = null;
                 return false;
            }
        }

        public void Collect(string Winner)
        {
            if (MyBet != null) 
                Cash = Cash + MyBet.PayOut(Winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
