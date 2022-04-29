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

namespace Square_Chaser
{
    public partial class SquareChaser : Form
    {
        Rectangle player1 = new Rectangle(200, 100, 25, 25);
        Rectangle player2 = new Rectangle(200, 200, 25, 25);

        Random RandGen = new Random();
        Rectangle ball;
        Rectangle boost;
        Rectangle slowBoost;

        int playerTurn = 1;
        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 8;
        int ballXSpeed = -6;
        int ballYSpeed = 6;

        bool aDown = false;
        bool dDown = false;
        bool wDown = false;
        bool sDown = false;

        bool leftArrowDown = false;
        bool rightArrowDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        SolidBrush cyanBrush = new SolidBrush(Color.Cyan);
        SolidBrush pinkBrush = new SolidBrush(Color.DeepPink);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush greenBrush = new SolidBrush(Color.PaleGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        SoundPlayer slowPlayer = new SoundPlayer(Properties.Resources.slowBoost);
        SoundPlayer sonarPlayer = new SoundPlayer(Properties.Resources.sonarr);
        SoundPlayer powerupPlayer = new SoundPlayer(Properties.Resources.powerUp);


        public SquareChaser()
        {
            InitializeComponent();

            int x = RandGen.Next(this.Width - 30);
            int y = RandGen.Next(this.Height - 30);

            ball = new Rectangle(x, y, 10, 10);

            int xx = RandGen.Next(this.Width - 30);
            int yy = RandGen.Next(this.Height - 30);

            boost = new Rectangle(xx, yy, 10, 10);

            int xxx = RandGen.Next(1, this.Width - 30);
            int yyy = RandGen.Next(1, this.Height - 30);

            slowBoost = new Rectangle(xxx, yyy, 10, 10);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }

        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {

            //move player 1
            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - 40 - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            //move player 2
            if (leftArrowDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - 40 - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            //player collision with ball
            if (player1.IntersectsWith(ball))
            {
                sonarPlayer.Play();

                player1Score++;
                p1scoreLabel.Text = $"{player1Score}";

                int x = RandGen.Next(1, this.Width - 30);
                int y = RandGen.Next(1, this.Height -80);

                ball.X = x;
                ball.Y = y;
                //ball.X = player1.X + ball.Width;
                //playerTurn = 2;
            }
            if (player2.IntersectsWith(ball))
            {
                sonarPlayer.Play();

                player2Score++;
                p2scoreLabel.Text = $"{player2Score}";

                int x = RandGen.Next(1, this.Width - 30);
                int y = RandGen.Next(1, this.Height - 30);

                ball.X = x;
                ball.Y = y;
                //ball.X = player2.X + ball.Height;
                //playerTurn = 1;
            }

            //player collision with boost
            if (player1.IntersectsWith(boost))
            {
                
                powerupPlayer.Play();

                playerSpeed++;
                int xx = RandGen.Next(1, this.Width - 30);
                int yy = RandGen.Next(1, this.Height - 30);

                boost.X = xx;
                boost.Y = yy;

            }
            if (player2.IntersectsWith(boost))
            {
                powerupPlayer.Play();

                playerSpeed++;
                int xx = RandGen.Next(1, this.Width - 30);
                int yy = RandGen.Next(1, this.Height - 30);

                boost.X = xx;
                boost.Y = yy;


            }

            //player collision with slow boost
            if (player1.IntersectsWith(slowBoost))
            {
                slowPlayer.Play();

                playerSpeed--;
                int xxx = RandGen.Next(1, this.Width - 30);
                int yyy = RandGen.Next(1, this.Height - 30);

                slowBoost.X = xxx;
                slowBoost.Y = yyy;

            }
            if (player2.IntersectsWith(slowBoost))
            {
                slowPlayer.Play();

                playerSpeed--;
                int xxx = RandGen.Next(1, this.Width - 30);
                int yyy = RandGen.Next(1, this.Height - 30);

                slowBoost.X = xxx;
                slowBoost.Y = yyy;


            }

            // if either player is at 5 points stop game
            if (player1Score == 5)
            {
                gameEngine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
                resetButton.Visible = true;
                resetButton.Enabled = true;
            }
            else if (player2Score == 5)
            {
                gameEngine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
                resetButton.Visible = true;
                resetButton.Enabled = true;
            }


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(cyanBrush, player1);
            e.Graphics.FillRectangle(pinkBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            e.Graphics.FillRectangle(greenBrush, boost);
            e.Graphics.FillRectangle(redBrush, slowBoost);

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            player1Score = player2Score = 0;

            p1scoreLabel.Text = $"{player1Score}";
            p2scoreLabel.Text = $"{player2Score}";
           

            int x = RandGen.Next(1, this.Width - 30);
            int y = RandGen.Next(1, this.Height - 30);

            ball.X = x;
            ball.Y = y;

            x = RandGen.Next(1, this.Width -30);
            y = RandGen.Next(1, this.Height -30);

            boost.X = x;
            boost.Y = y;

            x = RandGen.Next(1, this.Width - 30);
            y = RandGen.Next(1, this.Height - 30);

            player1.X = x;
            player2.Y = y;

            x = RandGen.Next(1, this.Width - 30);
            y = RandGen.Next(1, this.Height - 30);

            slowBoost.X = x;
            slowBoost.Y = y;

            resetButton.Enabled = false;
            resetButton.Visible = false;
            gameEngine.Enabled = true;
            winLabel.Visible = false;
            this.Focus();
        }
    }
}
