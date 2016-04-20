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
        Boolean ADown, SDown, DDown, WDown, fire;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //direction variable for player
        int direction = 0;

        //player object, monster list, and bullet list
        List<Monster> skeleton = new List<Monster>();
        List<Monster> duck = new List<Monster>();
        List<Bullet> bullets = new List<Bullet>();

        //skeleton direction variable
        int sDirection = 0;

        #region image arrays
        static Image skel0 = Properties.Resources.skeletonDown;
        static Image skel1 = Properties.Resources.skeletonLeft;
        static Image skel2 = Properties.Resources.skeletonRight;
        static Image skel3 = Properties.Resources.skeletonUp;

        static Image[] skel = { skel0, skel1, skel2, skel3 };

        //duck direction variable
        int dDirection = 0;
        static Image duck0 = Properties.Resources.duckDown;
        static Image duck1 = Properties.Resources.duckLeft;
        static Image duck2 = Properties.Resources.duckRight;
        static Image duck3 = Properties.Resources.duckUp;

        static Image[] ducks = { duck0, duck1, duck2, duck3 };

        static Image hero0 = Properties.Resources.RedGuyLeft;
        static Image hero1 = Properties.Resources.RedGuyDown;
        static Image hero2 = Properties.Resources.RedGuyRight;
        static Image hero3 = Properties.Resources.RedGuyUp;

        static Image[] hero = { hero0, hero1, hero2, hero3 };
        #endregion

        Player p;
        public MainScreen()
        {
            InitializeComponent();
            gameTimer.Enabled = true;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            //set initial position
            p = new Player(150, 150, 20, 10, hero);

            //add initial monster to list and set position           

            Monster d = new Monster(700, 700, 40, 4, ducks);
            duck.Add(d);
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    ADown = true;
                    break;
                case Keys.S:
                    SDown = true;
                    break;
                case Keys.D:
                    DDown = true;
                    break;
                case Keys.W:
                    WDown = true;
                    break;
                case Keys.Space:
                    fire = true;
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
                case Keys.A:
                    ADown = false;
                    break;
                case Keys.S:
                    SDown = false;
                    break;
                case Keys.D:
                    DDown = false;
                    break;
                case Keys.W:
                    WDown = false;
                    break;
                case Keys.Space:
                    fire = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {          
            #region Key Booleans
            ////checks to see if any keys have been pressed and adjusts the X or Y value
            ////for the player appropriately
            if (ADown == true)
            {
                p.move(p, 0);
                direction = 0;
            }
            else if (SDown == true)
            {
                p.move(p, 1);
                direction = 1;
            }
            else if (DDown == true)
            {
                p.move(p, 2);
                direction = 2;
            }
            else if (WDown == true)
            {
                p.move(p, 3);
                direction = 3;
            }
            //firing a bullet
            if (fire == true)
            {
                //max 3 bullets at once
                if (bullets.Count <= 2)
                {
                    Bullet b = new Bullet(p.x + 5, p.y + 10, 2, 20, direction);
                    bullets.Add(b);
                }
                else
                {

                }
            }
            int i = 0;
            for (i = 0; i<bullets.Count; i++)
            {
                //move all bullets in their initial direction
                bullets[i].move(bullets[i], bullets[i].direction);

                //remove bullets that leave the screen
                if (bullets[i].x < -2)
                {
                    bullets.RemoveAt(i);
                }
                else if (bullets[i].x > 750)
                {
                    bullets.RemoveAt(i);
                }
                else if (bullets[i].y < -2)
                {
                    bullets.RemoveAt(i);
                }
                else if (bullets[i].y > 750)
                {
                    bullets.RemoveAt(i);
                }
                else
                {

                }
            }
            #endregion

            //move bullets after checking if null

            #region new monsters
            //new duck after 10 seconds, skeleton after 20
            //int i = 0;
            //for (i = 0; i<=320; i++)
            //{
            //    if (i == 160)
            //    {
            //        Monster d = new Monster(700, 700, 40, 4, ducks);
            //        duck.Add(d);
            //    }
            //    if (i == 320)
            //    {
            //        Monster d0 = new Monster(500, 500, 30, 7, skel);
            //        skeleton.Add(d0);

            //        i = 0;
            //    }
            //}
            #endregion

            #region collision
            //collision between skeletons and ducks
            //int sk = 0;
            //int dk = 0;
            //for (sk = 0; sk<=skeleton.Count; sk++)
            //{

            //}
            //for (dk = 0; dk<=duck.Count; dk++)
            //{

            //}
            #endregion

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            e.Graphics.DrawImage(hero[direction], p.x, p.y, 20, 30);

            int i = 0;
            for (i = 0; i < bullets.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, bullets[i].x, bullets[i].y, 2, 2);
            }
            //int i1 = 0;
            //int i2 = 0;

            ////draw images for skeletons and ducks
            //for (i1 = 0; i<skeleton.Count; i++)
            //{
            //    e.Graphics.DrawImage(skeleton[sDirection], )
            //}

            //for (i2 = 0; i2 < skeleton.Count; i2++)
            //{
            //    e.Graphics.DrawImage(duck(dDirection), )
            //}
        }
    }
}
