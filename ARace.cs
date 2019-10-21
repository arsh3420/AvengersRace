using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers_Race
{
    public partial class ARace : Form
    {
        RaceGround[] Avengers = new RaceGround[4];
        int SmithBet = 0;
        int KevinBet = 0;
        int MichealBet = 0;
        bool Bet = false;
        public string Winner;
        public decimal Test;
        Betors[] BetrArray = new Betors[3];
        Random Randomizer = new Random();

        public ARace()
        {
            InitializeComponent();

            Avengers[0] = new RaceGround() { MyPictureBox = pictureBox1, Name = "Thenos", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox1.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 8) };
            Avengers[1] = new RaceGround() { MyPictureBox = pictureBox2, Name = "Spider", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox2.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 14) };
            Avengers[2] = new RaceGround() { MyPictureBox = pictureBox3, Name = "Hulk", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox3.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 12) };
            Avengers[3] = new RaceGround() { MyPictureBox = pictureBox4, Name = "Iron", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox4.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 10) };

            BetrArray[0] = new Betors() { MyBet = null, Name = "Smith", Cash = 50, MyLabel = lblSmith, MyRadioButton = rdbtnSmith, MyLabel2 = lblSmithBet };
            BetrArray[1] = new Betors() { MyBet = null, Name = "Kevin", Cash = 75, MyLabel = lblKevin, MyRadioButton = rdbtnKevin, MyLabel2 = lblKevinBet };
            BetrArray[2] = new Betors() { MyBet = null, Name = "Micheal", Cash = 45, MyLabel = lblMicheal, MyRadioButton = rdbtnMicheal, MyLabel2 = lblMichealBet };

            BetrArray[0].UpdateLabels();
            BetrArray[1].UpdateLabels();
            BetrArray[2].UpdateLabels();


            if (Avengers[0].oddsFor.ToString() == Avengers[0].oddsAgainst.ToString())
                lblDBOdds.Text = "Even";
            else
                lblDBOdds.Text = Avengers[0].oddsAgainst.ToString() + " : " + Avengers[0].oddsFor.ToString();
            if (Avengers[1].oddsFor.ToString() == Avengers[1].oddsAgainst.ToString())
                LROdds.Text = "Even";
            else
                LROdds.Text = Avengers[1].oddsAgainst.ToString() + " : " + Avengers[1].oddsFor.ToString();
            if (Avengers[2].oddsFor.ToString() == Avengers[2].oddsAgainst.ToString())
                MOdds.Text = "Even";
            else
                MOdds.Text = Avengers[2].oddsAgainst.ToString() + " : " + Avengers[2].oddsFor.ToString();
            if (Avengers[3].oddsFor.ToString() == Avengers[3].oddsAgainst.ToString())
                SSOdds.Text = "Even";
            else
                SSOdds.Text = Avengers[3].oddsAgainst.ToString() + " : " + Avengers[3].oddsFor.ToString();


        }

        private void btnStartRace_Click(object sender, EventArgs e)
        {

            Avengers[0].Starting_Position();
            Avengers[1].Starting_Position();
            Avengers[2].Starting_Position();
            Avengers[3].Starting_Position();
            SmithBet = 0;
            KevinBet = 0;
            MichealBet = 0;
            btnStartRace.Enabled = false;
            timer1.Start();

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //Avengers[0].Run();
            //Avengers[1].Run();
            //Avengers[2].Run();
            //Avengers[3].Run();
            //while (Avengers[0].Run() == false && Avengers[1].Run() == false && Avengers[2].Run() == false && Avengers[3].Run() == false)
            //{
            for (int i = 0; i < Avengers.Length; i++)
            {

                Avengers[i].Run();
                if (Avengers[i].Run() == true)
                {
                    // Avengers[i].Run() = true;
                    timer1.Stop();
                    timer1.Enabled = false;
                    MessageBox.Show(Avengers[i].Name + " has won the race");
                    Winner = Avengers[i].Name;
                    i = Avengers.Length;
                    btnStartRace.Enabled = true;
                    BetrArray[0].Collect(Winner);
                    BetrArray[1].Collect(Winner);
                    BetrArray[2].Collect(Winner);


                    //BetrArray[0].ClearBet();
                    //BetrArray[1].ClearBet();
                    //BetrArray[2].ClearBet();
                }

            }
            //}
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblKevin_Click(object sender, EventArgs e)
        {

        }

        private void rdbtnSmith_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnSmith.Enabled)
                lblBetter.Text = "Smith";
        }

        private void rdbtnKevin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnKevin.Enabled)
                lblBetter.Text = "Kevin";
        }

        private void rdbtnMicheal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnMicheal.Enabled)
                lblBetter.Text = "Micheal";
        }

        private void btnSetBet_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "Thenos")
                Test = Avengers[0].oddsAgainst / Avengers[0].oddsFor;
            if (comboBox1.Text.ToString() == "Spider")
                Test = Avengers[1].oddsAgainst / Avengers[1].oddsFor;
            if (comboBox1.Text.ToString() == "Hulk")
                Test = Avengers[2].oddsAgainst / Avengers[2].oddsFor;
            if (comboBox1.Text.ToString() == "Iron")
                Test = Avengers[3].oddsAgainst / Avengers[3].oddsFor;

            if (lblBetter.Text == "Smith")
            {
                if (SmithBet == 0)
                {

                    Bet = BetrArray[0].PlaceBet(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString(), Test);
                    if (Bet == true)
                    {
                        SmithBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Smith has already placed a bet.");
                }

            }
            if (lblBetter.Text == "Kevin")
            {
                if (KevinBet == 0)
                {
                    Bet = BetrArray[1].PlaceBet(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString(), Test);
                    if (Bet == true)
                    {
                        KevinBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Kevin has already placed a bet.");
                }

            }
            if (lblBetter.Text == "Micheal")
            {
                if (MichealBet == 0)
                {
                    Bet = BetrArray[2].PlaceBet(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString(), Test);
                    if (Bet == true)
                    {
                        MichealBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Micheal has already placed a bet.");
                }

            }
        }

        private void lblSmithBet_Click(object sender, EventArgs e)
        {

        }

        private void lblOdds_Click(object sender, EventArgs e)
        {

        }

        private void dbOddsAgainst_Click(object sender, EventArgs e)
        {

        }


    }
}
