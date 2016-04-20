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
        public Image[] hero = new Image[4];

        public Player(int _x, int _y, int _size, int _speed, Array _hero)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            _hero = hero;
        }

        public void move(Player p, int direction)
        {
            if (direction == 0)
            {
                p.x -= p.speed;
            }
            else if (direction == 1)
            {
                p.y += p.speed;
            }
            else if (direction == 2)
            {
                p.x += p.speed;
            }
            else if (direction == 3)
            {
                p.y -= p.speed;
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
