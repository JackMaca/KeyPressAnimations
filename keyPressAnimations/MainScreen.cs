using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace keyPressAnimations
{
    public partial class MainScreen : UserControl
    {

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        //direction variable
        int direction = 0;

        //player object, monster list, and bullet list
        List<Monster> skeleton = new List<Monster>();
        List<Monster> duck = new List<Monster>();
        List<Bullet> bullets = new List<Bullet>();
        Image[] hero = new Image[4];

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            hero[0] = Properties.Resources.RedGuyDown;
            hero[1] = Properties.Resources.RedGuyLeft;
            hero[2] = Properties.Resources.RedGuyRight;
            hero[3] = Properties.Resources.RedGuyUp;
            Player p = new Player(50, 50, 20, 5, hero);
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void MainScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ////checks to see if any keys have been pressed and adjusts the X or Y value
            ////for the rectangle appropriately
            //if (leftArrowDown == true)
            //{
            //    p.x--;
            //    direction = 0;
            //}
            //if (downArrowDown == true)
            //{
            //    p.y++;
            //    direction = 1;
            //}
            //if (rightArrowDown == true)
            //{
            //    p.x++;
            //    direction = 2;
            //}
            //if (upArrowDown == true)
            //{
            //    p.y--;
            //    direction = 3;
            //}

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(p.hero[direction], p.x, p.y, 20, 40);
        }
    }
}
