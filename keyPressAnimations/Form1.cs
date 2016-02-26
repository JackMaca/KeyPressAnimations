using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Created by Mr. T
 * to demonstrate how to use key presses to control the animation
 * of an object on screen
 */

namespace keyPressAnimations
{
    public partial class Form1 : Form
    {
        //initial starting points for black rectangle
        int drawX = 100;
        int drawY = 200;

        //determines whether a key is being pressed or not
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        //direction variable
        int direction = 0;

        //image array
        Image[] hero = new Image[4];

        public Form1()
        {
            InitializeComponent();

            //start the timer when the program starts
            gameTimer.Enabled = true;
            gameTimer.Start();

            hero[0] = Properties.Resources.RedGuyLeft;
            hero[1] = Properties.Resources.RedGuyDown;
            hero[2] = Properties.Resources.RedGuyRight;
            hero[3] = Properties.Resources.RedGuyUp;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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

        private void Form1_KeyUp(object sender, KeyEventArgs e)
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
            //checks to see if any keys have been pressed and adjusts the X or Y value
            //for the rectangle appropriately
            if (leftArrowDown == true)
            {
                drawX--;
                direction = 0;
            }
            if (downArrowDown == true)
            {
                drawY++;
                direction = 1;
            }
            if (rightArrowDown == true)
            {
                drawX++;
                direction = 2;
            }
            if (upArrowDown == true)
            {
                drawY--;
                direction = 3;
            }

            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //draw hero images based on direction
            //left
            if (direction == 0)
            {
                e.Graphics.DrawImage(hero[0], drawX, drawY, 20, 40);
            }
            //down
            else if (direction == 1)
            {
                e.Graphics.DrawImage(hero[1], drawX, drawY, 20, 40);
            }
            //right
            else if (direction == 2)
            {
                e.Graphics.DrawImage(hero[2], drawX, drawY, 20, 40);
            }
            else if (direction == 3)
            {
                e.Graphics.DrawImage(hero[3], drawX, drawY, 20, 40);
            }
        }

    }

}
