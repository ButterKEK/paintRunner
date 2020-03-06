using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintRunner
{
    public partial class Form1 : Form
    {

        //Player Speed
        int PlayerSpeed = 3;
        Point PlayerDelta = new Point(0, 0);

        //EnemySpeed
        const int Enemy01Speed = 2;
        Point Enemy02Delta = new Point(-3, -3);
        int Enemy03Speed = 0;
        int Enemy04Speed = 0;


        //Powerup Radomizer
        int PowerupRandom = 0;

        //PowerupActive
        bool ShieldActive = false;

        PictureBox[] Foods;
        String[] FoodNames = { "Apple", "Pear", "Lemon", "Cherry", "Grape", "Pineapple", "Powerup" };
        int[] StateOfFoods = new int[6];
        Dictionary<int, int> FoodStates = new Dictionary<int, int>() {
            {0, 50 },
            {1, 100 },
            {2, 150 },
            {3, 200 },
            {4, 250 },
            {5,300 },
            {6, 500 }
        };
        int[] scores = new int[6];
        Dictionary<int, Label> scoreBoards = new Dictionary<int, Label>();

        //PowerupTimer
        int wait = 10;
        int wait2 = 5;

        //Enemy Location
        Point Enemy01Start = new Point(1070, 793);
        Point Enemy02Start = new Point(1050, 894);

        int XEnemy03 = 1340;
        int YEnemy03 = 763;
        int XEnemy04 = 1340;
        int YEnemy04 = 884;

        //Score
        int score = 0;

        //Lost
        bool lost = false;

        //Pause
        bool pause = false;

        //Random Generator
        Random random = new Random();


        //Starting Enemy Timers
        private void EnemyTimersStart()
        {
            Enemy01Timer.Start();
            Enemy02Timer.Start();
            Enemy03Timer.Start();
            Enemy04Timer.Start();
        }

        //Stopping Enemy Timers
        private void EnemyTimersStop()
        {
            Enemy01Timer.Stop();
            Enemy02Timer.Stop();
            Enemy03Timer.Stop();
            Enemy04Timer.Stop();
        }

        public Form1()
        {
            InitializeComponent();

            MoveTimer.Start();

            //Stop Powerup Timers
            Powerup01Timer.Stop();
            Powerup02Timer.Stop();

            Foods = new PictureBox[] { Food01, Food02, Food03, Food04, Food05, Food06 };
            scoreBoards = new Dictionary<int, Label>()
            {
                { 0, AppleCounter},
                { 1, PearCounter},
                { 2, LemonCounter},
                { 3, CherryCounter},
                { 4, GrapeCounter},
                { 5, PineappleCounter}
            };
            //Random Food Placement
            foreach (PictureBox item in Foods)
            {
                item.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            }
        }


        //Moving
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (lost || pause)
                return;
            if ((Player.Left >= 958 && PlayerDelta.X > 0) || (Player.Left <= 17 && PlayerDelta.X < 0))
            {
                PlayerDelta.X = 0;
            }
            if ((Player.Top >= 958 && PlayerDelta.Y > 0) || (Player.Top <= 17 && PlayerDelta.Y < 0))
            {
                PlayerDelta.Y = 0;
            }
            Player.Location += new Size(PlayerDelta.X * PlayerSpeed, PlayerDelta.Y * PlayerSpeed);

        }

        //Key Detection
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lost && !pause)
            {

                switch (e.KeyCode)
                {
                    case (Keys.W):
                        PlayerDelta = new Point(0, -1);
                        break;
                    case (Keys.A):
                        PlayerDelta = new Point(-1, 0);
                        break;
                    case (Keys.S):
                        PlayerDelta = new Point(0, 1);
                        break;
                    case (Keys.D):
                        PlayerDelta = new Point(1, 0);
                        break;
                }

            }

        }
        //Reset the Game
        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Reset Player
            Player.Location = new Point(947, 26);
            PlayerDelta = Point.Empty;

            //Reset scores
            scores = new int[6];

            //Reset Enemies
            Enemy01.Location = Enemy01Start;
            Enemy02.Location = Enemy02Start;

            XEnemy03 = 1340;
            YEnemy03 = 763;
            Enemy03.Location = new Point(1340, 763);

            XEnemy04 = 1340;
            YEnemy04 = 884;
            Enemy04.Location = new Point(1340, 884);

            //Reset Food Location
            foreach (PictureBox item in Foods)
            {
                item.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            }

            StateOfFoods = new int[6];

            //Reset Food Pictures
            Image Apple = Image.FromFile("asserts\\Apple.png");
            foreach (PictureBox item in Foods)
            {
                item.Image = Apple;
            }

            //Reset Score
            score = 0;
            Scoreboard.Text = "Score: " + score;

            foreach (KeyValuePair<int, Label> scb in scoreBoards.ToArray())
            {
                scb.Value.Text = "";
            }

            //Reset Bools
            lost = false;
            pause = false;

            //Reset Labels
            PauseScreen.Visible = false;
            LostScreen.Visible = false;

            //Reset Speed
            PlayerSpeed = 3;

            Enemy02Delta = new Point(-3, -3);
            Enemy03Speed = 0;
            Enemy04Speed = 0;

            MoveTimer.Start();

            EnemyTimersStart();

            FoodCollectionTimer.Start();
        }

        //Pausing the Game
        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (lost == false)
            {
                if (pause == true)
                {
                    pause = false;
                    PauseScreen.Visible = false;

                    PauseButton.Text = "PAUSE";

                    //Starting all Timers
                    EnemyTimersStart();

                    FoodCollectionTimer.Start();
                }
                else
                {
                    pause = true;
                    PauseScreen.Visible = true;

                    PauseButton.Text = "WEITER";

                    PlayerDelta = Point.Empty;

                    EnemyTimersStop();

                    FoodCollectionTimer.Stop();
                }
            }

        }

        //Closing the Game
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Enemy AI
        private void Enemy01Timer_Tick(object sender, EventArgs e)
        {
            //Enemy01
            if (score > 999)
            {
                //Calculates a vector direction between the enemy and the Player and moves Enemy in that direction
                PointF direction = new PointF(Player.Location.X - Enemy01.Location.X, Player.Location.Y - Enemy01.Location.Y);
                float len = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
                direction.X = (direction.X / len * Enemy01Speed);
                direction.Y = (direction.Y / len * Enemy01Speed);
                Console.WriteLine(direction.ToString());
                Enemy01.Location = new Point(Enemy01.Location.X + (int)direction.X, Enemy01.Location.Y + (int)direction.Y);
                if (Player.Bounds.IntersectsWith(Enemy01.Bounds))
                {
                    if (!ShieldActive)
                    {
                        Lost();
                    }
                }
            }
        }

        private void Enemy02Timer_Tick(object sender, EventArgs e)
        {
            //Enemy02
            if (score > 4999)
            {

                Enemy02.Location += (Size)Enemy02Delta;

                if (Enemy02.Location.X < 17)
                {
                    Enemy02Delta.X = random.Next(2, 6);
                }
                if (Enemy02.Location.Y < 17)
                {
                    Enemy02Delta.Y = random.Next(2, 6);
                }
                if (Enemy02.Location.X > 918)
                {
                    Enemy02Delta.X = random.Next(-6, -2);
                }
                if (Enemy02.Location.Y > 918)
                {
                    Enemy02Delta.Y = random.Next(-6, -2);
                }

                if (Player.Bounds.IntersectsWith(Enemy02.Bounds))
                {
                    if (!ShieldActive)
                    {
                        Lost();
                    }
                }
            }
        }

        private void Enemy03Timer_Tick(object sender, EventArgs e)
        {
            //Enemy03
            if (score > 9999)
            {

            }
        }

        private void Enemy04Timer_Tick(object sender, EventArgs e)
        {
            //Enemy04
            if (score > 19999)
            {

            }
        }

        //Collection
        private void FoodCollectionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Foods.Length; i++)
            {
                if (Foods[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    //Change Powerup to Apple
                    if (StateOfFoods[i] == 6)
                    {

                        //SpeedBoost
                        if (PowerupRandom == 1)
                        {
                            PlayerSpeed = PlayerSpeed + 3;
                            SpeedBoostCounter.Visible = true;
                            Powerup01Timer.Start();

                            if (wait != 0)
                            {
                                wait = 10;
                                SpeedBoostCounter.Text = wait + " sec";
                            }
                        }

                        //Shield
                        if (PowerupRandom == 2)
                        {
                            ShieldActive = true;

                            //Player Image to Shielded
                            Image PlayerShield = Image.FromFile("asserts\\Player(HappyHarry)Shielded.png");
                            Player.Image = PlayerShield;

                            ShieldCounter.Visible = true;
                            Powerup02Timer.Start();

                            if (wait2 != 0)
                            {
                                wait2 = 5;
                                ShieldCounter.Text = wait2 + " sec";
                            }
                        }
                        score += FoodStates[StateOfFoods[i]];
                        Scoreboard.Text = "Score: " + score;

                        StateOfFoods[i] = 0;
                        Image img = Image.FromFile(String.Format("asserts\\{0}.png", FoodNames[StateOfFoods[i]]));
                        Foods[i].Image = img;
                        return;
                    }
                    score += FoodStates[StateOfFoods[i]];
                    Scoreboard.Text = "Score: " + score;
                    scores[StateOfFoods[i]]++;
                    scoreBoards[StateOfFoods[i]].Text = scores[StateOfFoods[i]].ToString();


                    StateOfFoods[i] = (StateOfFoods[i] + 1) % FoodNames.Length;

                    if (StateOfFoods[i] == 6)
                    {
                        PowerupRandom = random.Next(1, 3);
                        if (PowerupRandom == 1)
                        {
                            Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                            Foods[i].Image = SpeedBoost;
                        }
                        if (PowerupRandom == 2)
                        {
                            Image Shield = Image.FromFile("asserts\\Shield.png");
                            Foods[i].Image = Shield;
                        }
                        //Change Location
                        Foods[i].Location = new Point(random.Next(17, 958), random.Next(17, 958));
                        return;
                    }

                    Image FoodImage = Image.FromFile(String.Format("asserts\\{0}.png", FoodNames[StateOfFoods[i]]));
                    Foods[i].Image = FoodImage;




                    //Change Location
                    Foods[i].Location = new Point(random.Next(17, 958), random.Next(17, 958));

                }
            }
        }
        private void Lost()
        {
            lost = true;
            //Stopping all Timers
            PlayerDelta = Point.Empty;

            EnemyTimersStop();

            FoodCollectionTimer.Stop();

            //LostScreen
            LostScreen.Visible = true;

        }

        //SpeedBoostTimer
        private void Powerup01Timer_Tick(object sender, EventArgs e)
        {
            //Waiting for 10 seconds
            wait--;
            SpeedBoostCounter.Text = wait + " sec";
            if (wait == 0)
            {
                //deactivating Powerup
                PlayerSpeed = 3;
                SpeedBoostCounter.Visible = false;
                wait = 10;
                SpeedBoostCounter.Text = wait + " sec";
                Powerup01Timer.Stop();
            }
        }

        //ShieldTimer
        private void Powerup02Timer_Tick(object sender, EventArgs e)
        {
            //Waiting for 5 seconds
            wait2--;
            ShieldCounter.Text = wait2 + " sec";
            if (wait2 == 0)
            {
                //deactivating Powerup
                ShieldActive = false;

                //Player Image to Normal
                Image PlayerNormal = Image.FromFile("asserts\\Player(HappyHarry).png");
                Player.Image = PlayerNormal;

                ShieldCounter.Visible = false;
                wait2 = 5;
                ShieldCounter.Text = wait2 + " sec";
                Powerup02Timer.Stop();
            }
        }
    }
}
