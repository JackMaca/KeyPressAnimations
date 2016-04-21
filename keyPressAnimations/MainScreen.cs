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

        //create graphic objectsme
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

            Monster d = new Monster(400, 400, 50, 2, ducks);
            duck.Add(d);

            Monster sk = new Monster(-20, -20, 30, 3, skel);
            skeleton.Add(sk);
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
            #region monster movements
            //movement for monsters
            foreach (Monster d in duck)
            {
                if (d.x < p.x)
                {
                    d.move(d, 2);
                    dDirection = 2;
                }
                else if (d.x > p.x)
                {
                    d.move(d, 0);
                    dDirection = 0;
                }

                if (d.y < p.y)
                {
                    d.move(d, 1);
                    dDirection = 1;
                }
                else if (d.y > p.y)
                {
                    d.move(d, 3);
                    dDirection = 3;
                }
            }
            foreach (Monster d in skeleton)
            {
                if (d.x < p.x)
                {
                    d.move(d, 2);
                    sDirection = 2;
                }
                else if (d.x > p.x)
                {
                    d.move(d, 0);
                    sDirection = 0;
                }

                if (d.y < p.y)
                {
                    d.move(d, 1);

                    //stops buggy image from flashing
                    if (sDirection == 2)
                    {

                    }
                    else
                    {
                        sDirection = 1;
                    }
                }
                else if (d.y > p.y)
                {
                    d.move(d, 3);
                    sDirection = 3;
                }
            }
            #endregion

            #region new monsters
            //new duck after 5 seconds, skeleton after 10
            int time = 0;
            time++;
                if (time == 80)
                {
                    int speedBuff = 2;
                    Monster d = new Monster(400, 400, 50, speedBuff, ducks);
                    duck.Add(d);

                    //increase speed of next duck
                    speedBuff++;
                }
                if (time == 160)
                {
                    //skeletons dont gain speed and are consistant.
                    Monster d0 = new Monster(-30, -30, 30, 3, skel);
                    skeleton.Add(d0);

                    time = 0;
                }
            #endregion

            #region collision
            //collision between skeletons and ducks with bullets
            int dk = 0;
            for (dk = 0; dk <= duck.Count; dk++)
            {               
                //duck vs bullet collision
                foreach (Bullet b in bullets)
                {
                    if (duck[dk].bulletCollision(duck[dk], b) == true)
                    {
                        duck.RemoveAt(dk);
                    }
                    else
                    {

                    }
                }                
            }
            int skl = 0;
            for (skl = 0; skl <= skeleton.Count; skl++)
            {
                //bullet collisions
                foreach (Bullet b in bullets)
                {
                    if (skeleton[skl].bulletCollision(skeleton[skl], b) == true)
                    {
                        skeleton.RemoveAt(skl);
                    }
                    else
                    {

                    }                    
                }
            }

            ////player collision with duck
            //int duckL = 0;
            //for (duckL = 0; duckL <= duck.Count; duckL++)
            //{
            //    if (p.collision(p, duck[duckL]) == true)
            //    {
            //        ((Form)this.TopLevelControl).Close();
            //    }
            //    else
            //    {

            //    }
            //}
            ////player collision with skeleton
            //int skeleL = 0;
            //for (skeleL = 0; skeleL <= skeleton.Count; skeleL++)
            //{
            //    if (p.collision(p, skeleton[skeleL]) == true)
            //    {
            //        ((Form)this.TopLevelControl).Close();
            //    }
            //    else
            //    {

            //    }
            //}

            #endregion

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw player
            DoubleBuffered = true;
            e.Graphics.DrawImage(hero[direction], p.x, p.y, 20, 30);

            //draw bullets
            int i = 0;
            for (i = 0; i < bullets.Count; i++)
            {
                e.Graphics.FillRectangle(whiteBrush, bullets[i].x, bullets[i].y, 2, 2);
            }

            //draw ducks
            foreach (Monster d in duck)
            {
                e.Graphics.DrawImage(ducks[dDirection], d.x, d.y, 50, 50);
            }

            //draw skeletons
            foreach (Monster s in skeleton)
            {
                e.Graphics.DrawImage(skel[sDirection], s.x, s.y, 30, 40);
            }
        }
    }
}
