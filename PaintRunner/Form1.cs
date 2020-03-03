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
        //Player Location
        int XPlayer = 947;
        int YPlayer = 26;

        //Player Speed
        int PlayerSpeed = 3;

        //EnemySpeed
        int Enemy01Speed = 1;
        int XEnemy02Speed = -3;
        int YEnemy02Speed = -3;
        int Enemy03Speed = 0;
        int Enemy04Speed = 0;

        //FoodCollection Points
        int Food01CollectionPoints = 50;
        int Food02CollectionPoints = 50;
        int Food03CollectionPoints = 50;
        int Food04CollectionPoints = 50;
        int Food05CollectionPoints = 50;
        int Food06CollectionPoints = 50;

        //Food Score
        int AppleScore = 0;
        int PearScore = 0;
        int LemonScore = 0;
        int CherryScore = 0;
        int GrapeScore = 0;
        int PineappleScore = 0;

        //Powerup Radomizer
        int Powerup01Random = 0;
        int Powerup02Random = 0;
        int Powerup03Random = 0;
        int Powerup04Random = 0;
        int Powerup05Random = 0;
        int Powerup06Random = 0;

        //PowerupActive
        bool SpeedBoostActive = false;
        bool ShieldActive = false;

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

            //Random Food Placement
            Food01.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food02.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food03.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food04.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food05.Location = new Point(random.Next(67, 908), random.Next(67, 908));
            Food06.Location = new Point(random.Next(67, 908), random.Next(67, 908));
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
            if (lost == false)
            {
                if (pause == false)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        MoveUpTimer.Start();

                        MoveDownTimer.Stop();
                        MoveLeftTimer.Stop();
                        MoveRightTimer.Stop();
                    }
                    if (e.KeyCode == Keys.A)
                    {
                        MoveLeftTimer.Start();

                        MoveUpTimer.Stop();
                        MoveDownTimer.Stop();
                        MoveRightTimer.Stop();
                    }
                    if (e.KeyCode == Keys.S)
                    {
                        MoveDownTimer.Start();

                        MoveUpTimer.Stop();
                        MoveLeftTimer.Stop();
                        MoveRightTimer.Stop();
                    }
                    if (e.KeyCode == Keys.D)
                    {
                        MoveRightTimer.Start();

                        MoveUpTimer.Stop();
                        MoveDownTimer.Stop();
                        MoveLeftTimer.Stop();
                    }
                }
            }
        }
        //Reset the Game
        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Reset Player
            XPlayer = 947;
            YPlayer = 26;
            Player.Location = new Point(947, 26);

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

            //Reset Food Points
            Food01CollectionPoints = 50;
            Food02CollectionPoints = 50;
            Food03CollectionPoints = 50;
            Food04CollectionPoints = 50;
            Food05CollectionPoints = 50;
            Food06CollectionPoints = 50;

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

            AppleScore = 0;
            AppleCounter.Text = "" + AppleScore;
            PearScore = 0;
            PearCounter.Text = "" + PearScore;
            LemonScore = 0;
            LemonCounter.Text = "" + LemonScore;
            CherryScore = 0;
            CherryCounter.Text = "" + CherryScore;
            GrapeScore = 0;
            GrapeCounter.Text = "" + GrapeScore;
            PineappleScore = 0;
            PineappleCounter.Text = "" + PineappleScore;

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
            LostCheckTimer.Start();
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
                if (Player.Location.X + 20 >= Enemy01.Location.X + 20)
                {
                    XEnemy01 = XEnemy01 + Enemy01Speed;
                    Enemy01.Location = new Point(XEnemy01, YEnemy01);
                }
                if (Player.Location.X + 20 <= Enemy01.Location.X + 20)
                {
                    XEnemy01 = XEnemy01 - Enemy01Speed;
                    Enemy01.Location = new Point(XEnemy01, YEnemy01);
                }
                if (Player.Location.Y + 20 >= Enemy01.Location.Y + 20)
                {
                    YEnemy01 = YEnemy01 + Enemy01Speed;
                    Enemy01.Location = new Point(XEnemy01, YEnemy01);
                }
                if (Player.Location.Y + 20 <= Enemy01.Location.Y + 20)
                {
                    YEnemy01 = YEnemy01 - Enemy01Speed;
                    Enemy01.Location = new Point(XEnemy01, YEnemy01);
                }
                if (Player.Location.X >= Enemy01.Location.X - 40 && Player.Location.X <= Enemy01.Location.X + 40 && Player.Location.Y >= Enemy01.Location.Y - 40 && Player.Location.Y <= Enemy01.Location.Y + 40)
                {
                    if (ShieldActive == true)
                    {}
                    else
                    {
                        lost = true;
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
                    if (Enemy02First == false)
                    { }
                    if (Enemy02First == true)
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
                
                if (Player.Location.X >= Enemy02.Location.X - 40 && Player.Location.X <= Enemy02.Location.X + 80 && Player.Location.Y >= Enemy02.Location.Y - 40 && Player.Location.Y <= Enemy02.Location.Y + 80)
                {
                    if (ShieldActive == true)
                    {}
                    else
                    {
                        lost = true;
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
            //Food01
            if (Player.Location.X >= Food01.Location.X - 40 && Player.Location.X <= Food01.Location.X + 40 && Player.Location.Y >= Food01.Location.Y - 40 && Player.Location.Y <= Food01.Location.Y + 40)
            {
                //Change Powerup to Apple
                if (Food01CollectionPoints == 500)
                {
                    Image Apple = Image.FromFile("asserts\\Apple.png");
                    Food01.Image = Apple;

                    //SpeedBoost
                    if (Powerup01Random == 1)
                    {
                        PlayerSpeed = PlayerSpeed + 3;
                        SpeedBoostCounter.Visible = true;
                        Powerup01Timer.Start();

                        SpeedBoostActive = true;
                        if (wait != 0)
                        {
                            wait = 10;
                            SpeedBoostCounter.Text = wait + " sec";
                        }
                    }

                    //Shield
                    if (Powerup01Random == 2)
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
                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 50;
                }

                //Change Pineapple to Powerup
                else if (Food01CollectionPoints == 300)
                {
                    Powerup01Random = random.Next(1, 2);
                    if (Powerup01Random == 1)
                    {
                        Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                        Food01.Image = SpeedBoost;
                    }
                    if (Powerup01Random == 2)
                    {
                        Image Shield = Image.FromFile("asserts\\Shield.png");
                        Food01.Image = Shield;
                    }

                    PineappleScore = PineappleScore + 1;
                    PineappleCounter.Text = "" + PineappleScore;

                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 500;
                }

                //Change Grape to Pineapple
                else if (Food01CollectionPoints == 250)
                {
                    Image Pineapple = Image.FromFile("asserts\\Pineapple.png");
                    Food01.Image = Pineapple;

                    GrapeScore = GrapeScore + 1;
                    GrapeCounter.Text = "" + GrapeScore;

                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 300;
                }

                //Change Cherry to Grape
                else if (Food01CollectionPoints == 200)
                {
                    Image Grape = Image.FromFile("asserts\\Grape.png");
                    Food01.Image = Grape;

                    CherryScore = CherryScore + 1;
                    CherryCounter.Text = "" + CherryScore;

                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 250;
                }

                //Change Lemon to Cherry
                else if (Food01CollectionPoints == 150)
                {
                    Image Cherry = Image.FromFile("asserts\\Cherry.png");
                    Food01.Image = Cherry;

                    LemonScore = LemonScore + 1;
                    LemonCounter.Text = "" + LemonScore;

                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 200;
                }

                //Change Pear to Lemon
                else if (Food01CollectionPoints == 100)
                {
                    Image Lemon = Image.FromFile("asserts\\Lemon.png");
                    Food01.Image = Lemon;

                    PearScore = PearScore + 1;
                    PearCounter.Text = "" + PearScore;

                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 150;
                }

                //Change Apple to Pear
                else if (Food01CollectionPoints == 50)
                {
                    Image Pear = Image.FromFile("asserts\\Pear.png");
                    Food01.Image = Pear;

                    AppleScore = AppleScore + 1;
                    AppleCounter.Text = "" + AppleScore;

                    score = score + Food01CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food01CollectionPoints = 100;
                }

                //Change Location
                Food01.Location = new Point(random.Next(17, 958), random.Next(17, 958));
            }
            //Food02
            if (Player.Location.X >= Food02.Location.X - 40 && Player.Location.X <= Food02.Location.X + 40 && Player.Location.Y >= Food02.Location.Y - 40 && Player.Location.Y <= Food02.Location.Y + 40)
            {
                //Change Powerup to Apple
                if (Food02CollectionPoints == 500)
                {
                    Image Apple = Image.FromFile("asserts\\Apple.png");
                    Food02.Image = Apple;

                    //SpeedBoost
                    if (Powerup01Random == 1)
                    {
                        PlayerSpeed = PlayerSpeed + 3;
                        SpeedBoostCounter.Visible = true;
                        Powerup01Timer.Start();

                        SpeedBoostActive = true;
                        if (wait != 0)
                        {
                            wait = 10;
                            SpeedBoostCounter.Text = wait + " sec";
                        }
                    }

                    //Shield
                    if (Powerup01Random == 2)
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
                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 50;
                }

                //Change Pineapple to Powerup
                else if (Food02CollectionPoints == 300)
                {
                    Powerup01Random = random.Next(1, 2);
                    if (Powerup01Random == 1)
                    {
                        Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                        Food02.Image = SpeedBoost;
                    }
                    if (Powerup01Random == 2)
                    {
                        Image Shield = Image.FromFile("asserts\\Shield.png");
                        Food02.Image = Shield;
                    }

                    PineappleScore = PineappleScore + 1;
                    PineappleCounter.Text = "" + PineappleScore;

                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 500;
                }

                //Change Grape to Pineapple
                else if (Food02CollectionPoints == 250)
                {
                    Image Pineapple = Image.FromFile("asserts\\Pineapple.png");
                    Food02.Image = Pineapple;

                    GrapeScore = GrapeScore + 1;
                    GrapeCounter.Text = "" + GrapeScore;

                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 300;
                }

                //Change Cherry to Grape
                else if (Food02CollectionPoints == 200)
                {
                    Image Grape = Image.FromFile("asserts\\Grape.png");
                    Food02.Image = Grape;

                    CherryScore = CherryScore + 1;
                    CherryCounter.Text = "" + CherryScore;

                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 250;
                }

                //Change Lemon to Cherry
                else if (Food02CollectionPoints == 150)
                {
                    Image Cherry = Image.FromFile("asserts\\Cherry.png");
                    Food02.Image = Cherry;

                    LemonScore = LemonScore + 1;
                    LemonCounter.Text = "" + LemonScore;

                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 200;
                }

                //Change Pear to Lemon
                else if (Food02CollectionPoints == 100)
                {
                    Image Lemon = Image.FromFile("asserts\\Lemon.png");
                    Food02.Image = Lemon;

                    PearScore = PearScore + 1;
                    PearCounter.Text = "" + PearScore;

                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 150;
                }

                //Change Apple to Pear
                else if (Food02CollectionPoints == 50)
                {
                    Image Pear = Image.FromFile("asserts\\Pear.png");
                    Food02.Image = Pear;

                    AppleScore = AppleScore + 1;
                    AppleCounter.Text = "" + AppleScore;

                    score = score + Food02CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food02CollectionPoints = 100;
                }

                //Change Location
                Food02.Location = new Point(random.Next(17, 958), random.Next(17, 958));
            }
            //Food03
            if (Player.Location.X >= Food03.Location.X - 40 && Player.Location.X <= Food03.Location.X + 40 && Player.Location.Y >= Food03.Location.Y - 40 && Player.Location.Y <= Food03.Location.Y + 40)
            {
                //Change Powerup to Apple
                if (Food03CollectionPoints == 500)
                {
                    Image Apple = Image.FromFile("asserts\\Apple.png");
                    Food03.Image = Apple;

                    //SpeedBoost
                    if (Powerup01Random == 1)
                    {
                        PlayerSpeed = PlayerSpeed + 3;
                        SpeedBoostCounter.Visible = true;
                        Powerup01Timer.Start();

                        SpeedBoostActive = true;
                        if (wait != 0)
                        {
                            wait = 10;
                            SpeedBoostCounter.Text = wait + " sec";
                        }
                    }

                    //Shield
                    if (Powerup01Random == 2)
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
                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 50;
                }

                //Change Pineapple to Powerup
                else if (Food03CollectionPoints == 300)
                {
                    Powerup01Random = random.Next(1, 2);
                    if (Powerup01Random == 1)
                    {
                        Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                        Food03.Image = SpeedBoost;
                    }
                    if (Powerup01Random == 2)
                    {
                        Image Shield = Image.FromFile("asserts\\Shield.png");
                        Food03.Image = Shield;
                    }

                    PineappleScore = PineappleScore + 1;
                    PineappleCounter.Text = "" + PineappleScore;

                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 500;
                }

                //Change Grape to Pineapple
                else if (Food03CollectionPoints == 250)
                {
                    Image Pineapple = Image.FromFile("asserts\\Pineapple.png");
                    Food03.Image = Pineapple;

                    GrapeScore = GrapeScore + 1;
                    GrapeCounter.Text = "" + GrapeScore;

                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 300;
                }

                //Change Cherry to Grape
                else if (Food03CollectionPoints == 200)
                {
                    Image Grape = Image.FromFile("asserts\\Grape.png");
                    Food03.Image = Grape;

                    CherryScore = CherryScore + 1;
                    CherryCounter.Text = "" + CherryScore;

                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 250;
                }

                //Change Lemon to Cherry
                else if (Food03CollectionPoints == 150)
                {
                    Image Cherry = Image.FromFile("asserts\\Cherry.png");
                    Food03.Image = Cherry;

                    LemonScore = LemonScore + 1;
                    LemonCounter.Text = "" + LemonScore;

                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 200;
                }

                //Change Pear to Lemon
                else if (Food03CollectionPoints == 100)
                {
                    Image Lemon = Image.FromFile("asserts\\Lemon.png");
                    Food03.Image = Lemon;

                    PearScore = PearScore + 1;
                    PearCounter.Text = "" + PearScore;

                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 150;
                }

                //Change Apple to Pear
                else if (Food03CollectionPoints == 50)
                {
                    Image Pear = Image.FromFile("asserts\\Pear.png");
                    Food03.Image = Pear;

                    AppleScore = AppleScore + 1;
                    AppleCounter.Text = "" + AppleScore;

                    score = score + Food03CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food03CollectionPoints = 100;
                }

                //Change Location
                Food03.Location = new Point(random.Next(17, 958), random.Next(17, 958));
            }
            //Food04
            if (Player.Location.X >= Food04.Location.X - 40 && Player.Location.X <= Food04.Location.X + 40 && Player.Location.Y >= Food04.Location.Y - 40 && Player.Location.Y <= Food04.Location.Y + 40)
            {
                //Change Powerup to Apple
                if (Food03CollectionPoints == 500)
                {
                    Image Apple = Image.FromFile("asserts\\Apple.png");
                    Food03.Image = Apple;

                    //SpeedBoost
                    if (Powerup01Random == 1)
                    {
                        PlayerSpeed = PlayerSpeed + 3;
                        SpeedBoostCounter.Visible = true;
                        Powerup01Timer.Start();

                        SpeedBoostActive = true;
                        if (wait != 0)
                        {
                            wait = 10;
                            SpeedBoostCounter.Text = wait + " sec";
                        }
                    }

                    //Shield
                    if (Powerup01Random == 2)
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
                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 50;
                }

                //Change Pineapple to Powerup
                else if (Food04CollectionPoints == 300)
                {
                    Powerup01Random = random.Next(1, 2);
                    if (Powerup01Random == 1)
                    {
                        Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                        Food04.Image = SpeedBoost;
                    }
                    if (Powerup01Random == 2)
                    {
                        Image Shield = Image.FromFile("asserts\\Shield.png");
                        Food04.Image = Shield;
                    }

                    PineappleScore = PineappleScore + 1;
                    PineappleCounter.Text = "" + PineappleScore;

                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 500;
                }

                //Change Grape to Pineapple
                else if (Food04CollectionPoints == 250)
                {
                    Image Pineapple = Image.FromFile("asserts\\Pineapple.png");
                    Food04.Image = Pineapple;

                    GrapeScore = GrapeScore + 1;
                    GrapeCounter.Text = "" + GrapeScore;

                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 300;
                }

                //Change Cherry to Grape
                else if (Food04CollectionPoints == 200)
                {
                    Image Grape = Image.FromFile("asserts\\Grape.png");
                    Food04.Image = Grape;

                    CherryScore = CherryScore + 1;
                    CherryCounter.Text = "" + CherryScore;

                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 250;
                }

                //Change Lemon to Cherry
                else if (Food04CollectionPoints == 150)
                {
                    Image Cherry = Image.FromFile("asserts\\Cherry.png");
                    Food04.Image = Cherry;

                    LemonScore = LemonScore + 1;
                    LemonCounter.Text = "" + LemonScore;

                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 200;
                }

                //Change Pear to Lemon
                else if (Food04CollectionPoints == 100)
                {
                    Image Lemon = Image.FromFile("asserts\\Lemon.png");
                    Food04.Image = Lemon;

                    PearScore = PearScore + 1;
                    PearCounter.Text = "" + PearScore;

                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 150;
                }

                //Change Apple to Pear
                else if (Food04CollectionPoints == 50)
                {
                    Image Pear = Image.FromFile("asserts\\Pear.png");
                    Food04.Image = Pear;

                    AppleScore = AppleScore + 1;
                    AppleCounter.Text = "" + AppleScore;

                    score = score + Food04CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food04CollectionPoints = 100;
                }

                //Change Location
                Food04.Location = new Point(random.Next(17, 958), random.Next(17, 958));
            }
            //Food05
            if (Player.Location.X >= Food05.Location.X - 40 && Player.Location.X <= Food05.Location.X + 40 && Player.Location.Y >= Food05.Location.Y - 40 && Player.Location.Y <= Food05.Location.Y + 40)
            {
                //Change Powerup to Apple
                if (Food04CollectionPoints == 500)
                {
                    Image Apple = Image.FromFile("asserts\\Apple.png");
                    Food04.Image = Apple;

                    //SpeedBoost
                    if (Powerup01Random == 1)
                    {
                        PlayerSpeed = PlayerSpeed + 3;
                        SpeedBoostCounter.Visible = true;
                        Powerup01Timer.Start();

                        SpeedBoostActive = true;
                        if (wait != 0)
                        {
                            wait = 10;
                            SpeedBoostCounter.Text = wait + " sec";
                        }
                    }

                    //Shield
                    if (Powerup01Random == 2)
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
                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 50;
                }

                //Change Pineapple to Powerup
                else if (Food05CollectionPoints == 300)
                {
                    Powerup01Random = random.Next(1, 2);
                    if (Powerup01Random == 1)
                    {
                        Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                        Food05.Image = SpeedBoost;
                    }
                    if (Powerup01Random == 2)
                    {
                        Image Shield = Image.FromFile("asserts\\Shield.png");
                        Food05.Image = Shield;
                    }

                    PineappleScore = PineappleScore + 1;
                    PineappleCounter.Text = "" + PineappleScore;

                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 500;
                }

                //Change Grape to Pineapple
                else if (Food05CollectionPoints == 250)
                {
                    Image Pineapple = Image.FromFile("asserts\\Pineapple.png");
                    Food05.Image = Pineapple;

                    GrapeScore = GrapeScore + 1;
                    GrapeCounter.Text = "" + GrapeScore;

                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 300;
                }

                //Change Cherry to Grape
                else if (Food05CollectionPoints == 200)
                {
                    Image Grape = Image.FromFile("asserts\\Grape.png");
                    Food05.Image = Grape;

                    CherryScore = CherryScore + 1;
                    CherryCounter.Text = "" + CherryScore;

                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 250;
                }

                //Change Lemon to Cherry
                else if (Food05CollectionPoints == 150)
                {
                    Image Cherry = Image.FromFile("asserts\\Cherry.png");
                    Food05.Image = Cherry;

                    LemonScore = LemonScore + 1;
                    LemonCounter.Text = "" + LemonScore;

                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 200;
                }

                //Change Pear to Lemon
                else if (Food05CollectionPoints == 100)
                {
                    Image Lemon = Image.FromFile("asserts\\Lemon.png");
                    Food05.Image = Lemon;

                    PearScore = PearScore + 1;
                    PearCounter.Text = "" + PearScore;

                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 150;
                }

                //Change Apple to Pear
                else if (Food05CollectionPoints == 50)
                {
                    Image Pear = Image.FromFile("asserts\\Pear.png");
                    Food05.Image = Pear;

                    AppleScore = AppleScore + 1;
                    AppleCounter.Text = "" + AppleScore;

                    score = score + Food05CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food05CollectionPoints = 100;
                }

                //Change Location
                Food05.Location = new Point(random.Next(17, 958), random.Next(17, 958));
            }
            //Food06
            if (Player.Location.X >= Food06.Location.X - 40 && Player.Location.X <= Food06.Location.X + 40 && Player.Location.Y >= Food06.Location.Y - 40 && Player.Location.Y <= Food06.Location.Y + 40)
            {
                //Change Powerup to Apple
                if (Food05CollectionPoints == 500)
                {
                    Image Apple = Image.FromFile("asserts\\Apple.png");
                    Food05.Image = Apple;

                    //SpeedBoost
                    if (Powerup01Random == 1)
                    {
                        PlayerSpeed = PlayerSpeed + 3;
                        SpeedBoostCounter.Visible = true;
                        Powerup01Timer.Start();

                        SpeedBoostActive = true;
                        if (wait != 0)
                        {
                            wait = 10;
                            SpeedBoostCounter.Text = wait + " sec";
                        }
                    }

                    //Shield
                    if (Powerup01Random == 2)
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
                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 50;
                }

                //Change Pineapple to Powerup
                else if (Food06CollectionPoints == 300)
                {
                    Powerup01Random = random.Next(1, 2);
                    if (Powerup01Random == 1)
                    {
                        Image SpeedBoost = Image.FromFile("asserts\\SpeedBoost.png");
                        Food06.Image = SpeedBoost;
                    }
                    if (Powerup01Random == 2)
                    {
                        Image Shield = Image.FromFile("asserts\\Shield.png");
                        Food06.Image = Shield;
                    }

                    PineappleScore = PineappleScore + 1;
                    PineappleCounter.Text = "" + PineappleScore;

                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 500;
                }

                //Change Grape to Pineapple
                else if (Food06CollectionPoints == 250)
                {
                    Image Pineapple = Image.FromFile("asserts\\Pineapple.png");
                    Food06.Image = Pineapple;

                    GrapeScore = GrapeScore + 1;
                    GrapeCounter.Text = "" + GrapeScore;

                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 300;
                }

                //Change Cherry to Grape
                else if (Food06CollectionPoints == 200)
                {
                    Image Grape = Image.FromFile("asserts\\Grape.png");
                    Food06.Image = Grape;

                    CherryScore = CherryScore + 1;
                    CherryCounter.Text = "" + CherryScore;

                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 250;
                }

                //Change Lemon to Cherry
                else if (Food06CollectionPoints == 150)
                {
                    Image Cherry = Image.FromFile("asserts\\Cherry.png");
                    Food06.Image = Cherry;

                    LemonScore = LemonScore + 1;
                    LemonCounter.Text = "" + LemonScore;

                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 200;
                }

                //Change Pear to Lemon
                else if (Food06CollectionPoints == 100)
                {
                    Image Lemon = Image.FromFile("asserts\\Lemon.png");
                    Food06.Image = Lemon;

                    PearScore = PearScore + 1;
                    PearCounter.Text = "" + PearScore;

                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 150;
                }

                //Change Apple to Pear
                else if (Food06CollectionPoints == 50)
                {
                    Image Pear = Image.FromFile("asserts\\Pear.png");
                    Food06.Image = Pear;

                    AppleScore = AppleScore + 1;
                    AppleCounter.Text = "" + AppleScore;

                    score = score + Food06CollectionPoints;
                    Scoreboard.Text = "Score: " + score;

                    Food06CollectionPoints = 100;
                }

                //Change Location
                Food06.Location = new Point(random.Next(17, 958), random.Next(17, 958));
            }            
        }

        private void LostCheckTimer_Tick(object sender, EventArgs e)
        {
            if(lost == true)
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
