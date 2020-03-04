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

        //EnemySpeed
        int Enemy01Speed = 2;
        int XEnemy02Speed = -3;
        int YEnemy02Speed = -3;
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
        int XEnemy01 = 1070;
        int YEnemy01 = 793;
        int XEnemy02 = 1050;
        int YEnemy02 = 894;
        bool Enemy02First = false;
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

        //Stopping Movement Timers
        private void MoveTimersStop()
        {
            MoveUpTimer.Stop();
            MoveDownTimer.Stop();
            MoveLeftTimer.Stop();
            MoveRightTimer.Stop();
        }

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

            //Stop Movement Timers
            MoveTimersStop();

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
            foreach  (PictureBox item in Foods)
            {
                item.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            }
        }

        //Moving Up
        private void MoveUpTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 17)
            {
                Player.Top -= PlayerSpeed;
            }
        }

        //Moving Down
        private void MoveDownTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 958)
            {
                Player.Top += PlayerSpeed;
            }
        }

        //Moving Left
        private void MoveLeftTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 17)
            {
                Player.Left -= PlayerSpeed;
            }
        }

        //Moving Right
        private void MoveRightTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 958)
            {
                Player.Left += PlayerSpeed;
            }
        }

        //Key Detection
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lost && !pause)
            {

                MoveTimersStop();
                switch (e.KeyCode)
                {
                    case (Keys.W):
                        MoveUpTimer.Start();
                        break;
                    case (Keys.A):
                        MoveLeftTimer.Start();
                        break;
                    case (Keys.S):
                        MoveDownTimer.Start();
                        break;
                    case (Keys.D):
                        MoveRightTimer.Start();
                        break;
                }

            }

        }
        //Reset the Game
        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Reset Player
            Player.Location = new Point(947, 26);

            //Reset scores
            scores = new int[6];

            //Reset Enemies
            XEnemy01 = 1070;
            YEnemy01 = 793;
            Enemy01.Location = new Point(1070, 793);

            XEnemy02 = 1050;
            YEnemy02 = 894;
            Enemy02First = false;
            Enemy02.Location = new Point(1050, 894);

            XEnemy03 = 1340;
            YEnemy03 = 763;
            Enemy03.Location = new Point(1340, 763);

            XEnemy04 = 1340;
            YEnemy04 = 884;
            Enemy04.Location = new Point(1340, 884);

            //Reset Food Location
            Food01.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food02.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food03.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food04.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food05.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food06.Location = new Point(random.Next(67, 908), random.Next(67, 908));

            StateOfFoods = new int[6];

            //Reset Food Pictures
            Image Apple = Image.FromFile("asserts\\Apple.png");
            Food01.Image = Apple;
            Food02.Image = Apple;
            Food03.Image = Apple;
            Food04.Image = Apple;
            Food05.Image = Apple;
            Food06.Image = Apple;

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

            Enemy01Speed = 1;
            XEnemy02Speed = -3;
            YEnemy02Speed = -3;
            Enemy03Speed = 0;
            Enemy04Speed = 0;

            //Reset Timer
            MoveTimersStop();

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

                    //Stopping all Timers
                    MoveTimersStop();

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
                PointF direction = new PointF(Player.Location.X -Enemy01.Location.X, Player.Location.Y - Enemy01.Location.Y);
                float len = (float)Math.Sqrt(direction.X *direction.X + direction.Y *direction.Y);
                direction.X = (direction.X / len *Enemy01Speed);
                direction.Y = (direction.Y / len *Enemy01Speed);
                Console.WriteLine(direction.ToString());
                Enemy01.Location = new Point(Enemy01.Location.X + (int)direction.X,Enemy01.Location.Y +(int)direction.Y);
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
                XEnemy02 = XEnemy02 + XEnemy02Speed;
                YEnemy02 = YEnemy02 + YEnemy02Speed;

                Enemy02.Location = new Point(XEnemy02, YEnemy02);

                if (XEnemy02 < 17)
                {
                    XEnemy02Speed = random.Next(2, 6);
                    Enemy02First = true;
                }
                if (YEnemy02 < 17)
                {
                    YEnemy02Speed = random.Next(2, 6);
                }
                if (XEnemy02 > 918)
                {
                    if (Enemy02First)
                    {
                        XEnemy02Speed = random.Next(2, 6);
                        XEnemy02Speed = XEnemy02Speed * -1;
                    }
                }
                if (YEnemy02 > 918)
                {
                    YEnemy02Speed = random.Next(2, 6);
                    YEnemy02Speed = YEnemy02Speed * -1;
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
                    Console.WriteLine(StateOfFoods[i]);
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
            if (lost == true)
            {
                //Stopping all Timers
                MoveTimersStop();

                EnemyTimersStop();

                FoodCollectionTimer.Stop();

                //LostScreen
                LostScreen.Visible = true;
            }
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
