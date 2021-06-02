using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Square_chaser
{
    public partial class Form1 : Form
    {
        // global variables
        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 3;
        int player2Speed = 3;

        //randgen 
        Random randGen = new Random();
        int numberPointCube;
        int numberSpeedup;
        int numberspeedDown;

        //sound
        SoundPlayer ding = new SoundPlayer(Properties.Resources.Ding);
        SoundPlayer speedUp = new SoundPlayer(Properties.Resources.speedup);
        SoundPlayer slowDown = new SoundPlayer(Properties.Resources.slowdown);
        SoundPlayer winner = new SoundPlayer(Properties.Resources.winner);

        // keys 
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        //paint 
        Rectangle player1 = new Rectangle(70, 130, 10, 10);
        Rectangle player2 = new Rectangle(70, 200, 10, 10);
        Rectangle pointCube = new Rectangle(200, 200, 5, 5);
        Rectangle speedboost = new Rectangle(300, 320, 5, 5);
        Rectangle slow = new Rectangle(350, 350, 5, 5);
        Rectangle border = new Rectangle(50, 80, 450, 450);

      
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush pinkBrush = new SolidBrush(Color.Pink);
        Pen greenPen = new Pen(Color.Green, 5);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //player movements 
            // P1

            if (wDown == true && player1.Y > 80)
            {
                player1.Y -= player1Speed;
            }
            if (sDown == true && player1.Y < 520 )
            {
                player1.Y += player1Speed;
            }
            if (aDown == true && player1.X > 50)
            {
                player1.X -= player1Speed;
            }
            if (dDown == true && player1.X < 490)
            {
                player1.X += player1Speed;
            }

            //P2
            if (upArrowDown == true && player2.Y > 80)
            {
                player2.Y -= player2Speed;
            }
            if (downArrowDown == true && player2.Y < 520)
            {
                player2.Y += player2Speed;
            }
            if (leftDown == true && player2.X > 50)
            {
                player2.X -= player2Speed;
            }
            if (rightDown == true && player2.X < 490)
            {
                player2.X += player2Speed;
            }

            //players get points // collision 
           
            int numberPointCube = randGen.Next(1, 15);
           
            if (player1.IntersectsWith(pointCube))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                ding.Play();
                switch (numberPointCube)
                {
                    case 1:
                        pointCube = new Rectangle(300, 200, 5, 5);
                        break;
                    case 2:
                        pointCube = new Rectangle(400, 110, 5, 5);
                        break;
                    case 3:
                        pointCube = new Rectangle(120 ,400 ,5 ,5 );
                        break;
                    case 4:
                        pointCube = new Rectangle(370, 280, 5, 5);
                        break;
                    case 5:
                        pointCube = new Rectangle(200, 330, 5, 5);
                        break;
                    case 6:
                        pointCube = new Rectangle(80, 120, 5, 5);
                        break;
                    case 7:
                        pointCube = new Rectangle(90, 300, 5, 5);
                        break;
                    case 8:
                        pointCube = new Rectangle(275, 360, 5, 5);
                        break;
                    case 9:
                        pointCube = new Rectangle(310, 210, 5, 5);
                        break;
                    case 10:
                        pointCube = new Rectangle(420, 110, 5, 5);
                        break;
                    case 11:
                        pointCube = new Rectangle(240, 400, 5, 5);
                        break;
                    case 12:
                        pointCube = new Rectangle(450, 450, 5, 5);
                        break;
                    case 13:
                        pointCube = new Rectangle(170, 110, 5, 5);
                        break;
                    case 14:
                        pointCube = new Rectangle(300, 165, 5, 5);
                        break;
                }
                
            }
            else if (player2.IntersectsWith(pointCube))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                ding.Play();
                switch (numberPointCube)
                {
                    case 1:
                        pointCube = new Rectangle(300, 200, 5, 5);
                        // Rectangle pointCube = new Rectangle(200, 200, 5, 5);
                        break;
                    case 2:
                        pointCube = new Rectangle(400, 110, 5, 5);
                        break;
                    case 3:
                        pointCube = new Rectangle(120, 400, 5, 5);
                        break;
                    case 4:
                        pointCube = new Rectangle(370, 280, 5, 5);
                        break;
                    case 5:
                        pointCube = new Rectangle(200, 330, 5, 5);
                        break;
                    case 6:
                        pointCube = new Rectangle(80, 120, 5, 5);
                        break;
                    case 7:
                        pointCube = new Rectangle(90, 300, 5, 5);
                        break;
                    case 8:
                        pointCube = new Rectangle(275, 360, 5, 5);
                        break;
                    case 9:
                        pointCube = new Rectangle(310, 210, 5, 5);
                        break;
                    case 10:
                        pointCube = new Rectangle(420, 110, 5, 5);
                        break;
                    case 11:
                        pointCube = new Rectangle(240, 400, 5, 5);
                        break;
                    case 12:
                        pointCube = new Rectangle(450, 450, 5, 5);
                        break;
                    case 13:
                        pointCube = new Rectangle(170, 110, 5, 5);
                        break;
                    case 14:
                        pointCube = new Rectangle(300, 165, 5, 5);
                        break;
                }
            }
            // power up (speed)
            int numberSpeedup = randGen.Next(1, 7);

            if (player1.IntersectsWith(speedboost))
            {
                player1Speed ++;
                speedUp.Play();
                switch(numberSpeedup)
                {
                    case 1:
                        speedboost = new Rectangle(130, 300, 5, 5);
                        break;
                    case 2:
                        speedboost = new Rectangle(230, 110, 5, 5);
                        break;
                    case 3:
                        speedboost = new Rectangle(320, 300, 5, 5);
                        break;
                    case 4:
                        speedboost = new Rectangle(400, 150, 5, 5);
                        break;
                    case 5:
                        speedboost = new Rectangle(270, 180, 5, 5);
                        break;
                    case 6:
                        speedboost = new Rectangle(280, 160, 5, 5);
                        break;
                }
            }
            else if (player2.IntersectsWith(speedboost))
            {
                player2Speed ++;
                speedUp.Play();
                switch (numberSpeedup)
                {
                    case 1:
                        speedboost = new Rectangle(130, 300, 5, 5);
                        break;
                    case 2:
                        speedboost = new Rectangle(230, 110, 5, 5);
                        break;
                    case 3:
                        speedboost = new Rectangle(320, 300, 5, 5);
                        break;
                    case 4:
                        speedboost = new Rectangle(400, 150, 5, 5);
                        break;
                    case 5:
                        speedboost = new Rectangle(270, 180, 5, 5);
                        break;
                    case 6:
                        speedboost = new Rectangle(280, 260, 5, 5);
                        break;
                }
            }

            //slowdown power 
            int numberSpeedDown = randGen.Next(1, 7);
            if (player1.IntersectsWith(slow))
            {
                player1Speed--;
                slowDown.Play();
                switch(numberSpeedDown)
                {
                    case 1:
                        slow = new Rectangle(120, 300, 5, 5);
                        break;
                    case 2:
                        slow = new Rectangle(460, 300, 5, 5);
                        break;
                    case 3:
                        slow = new Rectangle(100, 100, 5, 5);
                        break;
                    case 4:
                        slow = new Rectangle(200, 200, 5, 5);
                        break;
                    case 5:
                        slow = new Rectangle(350, 210, 5, 5);
                        break;
                    case 6:
                        slow = new Rectangle(240, 400, 5, 5);
                        break;
                 
                }
            }
            else if (player2.IntersectsWith(slow))
            {
                player2Speed--;
                slowDown.Play();
                switch (numberSpeedDown)
                {
                    case 1:
                        slow = new Rectangle(120, 300, 5, 5);
                        break;
                    case 2:
                        slow = new Rectangle(460, 300, 5, 5);
                        break;
                    case 3:
                        slow = new Rectangle(100, 100, 5, 5);
                        break;
                    case 4:
                        slow = new Rectangle(200, 200, 5, 5);
                        break;
                    case 5:
                        slow = new Rectangle(350, 210, 5, 5);
                        break;
                    case 6:
                        slow = new Rectangle(240, 400, 5, 5);
                        break;

                }
            }


            // end game declare winner 

            if (player1Score == 5)
            {
                outputLabel.Text = $"Player 1 Wins!!";
                winner.Play();
            }
            else if (player2Score == 5)
            {
                outputLabel.Text = $"Player 2 Wins!!";
                winner.Play();
            }

            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, pointCube);
            e.Graphics.FillRectangle(orangeBrush, slow);
            e.Graphics.FillRectangle(pinkBrush, speedboost);
            e.Graphics.DrawRectangle(greenPen, border);
        }
    }
}
