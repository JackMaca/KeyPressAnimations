using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace keyPressAnimations
{
    class Player
    {
        public int x, y, size, speed;
        Image[] hero = new Image[4];

        public Player(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;

            hero[0] = Properties.Resources.RedGuyLeft;
            hero[1] = Properties.Resources.RedGuyDown;
            hero[2] = Properties.Resources.RedGuyRight;
            hero[3] = Properties.Resources.RedGuyUp;
        }

        public void move(Player p, string direction)
        {
            if (direction == "left")
            {
                p.x -= p.speed;
            }
            else if (direction == "right")
            {
                p.x += p.speed;
            }
            else if (direction == "up")
            {
                p.y -= p.speed;
            }
            else if (direction == "down")
            {
                p.y += p.speed;
            }
        }
        //collision from player with monster
        public bool collision(Player p, Monster m)
        {
            Rectangle pRec = new Rectangle(p.x, p.y, p.size, p.size);
            Rectangle mRec = new Rectangle(m.x, m.y, m.size, m.size);

            if (mRec.IntersectsWith(pRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
