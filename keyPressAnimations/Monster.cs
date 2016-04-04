using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace keyPressAnimations
{
    class Monster
    {
        public int x, y, size, speed;
        Image[] hero = new Image[4];

        public Monster(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        
            //TODO add monster images
        }

        public void move(Monster m, string direction)
        {
            if (direction == "mLeft")
            {
                m.x -= m.speed;
            }
            else if (direction == "mRight")
            {
                m.x += m.speed;
            }
            else if (direction == "mUp")
            {
                m.y -= m.speed;
            }
            else if (direction == "mDown")
            {
                m.y += m.speed;
            }
        }
        //collision between bullet and monster
        public bool collision(Monster m, Bullet b)
        {
            Rectangle mRec = new Rectangle(m.x, m.y, m.size, m.size);
            Rectangle bRec = new Rectangle(b.x, b.y, b.size, b.size);

            if (bRec.IntersectsWith(mRec))
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
