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
        Image[] monster = new Image[4];

        public Monster(int _x, int _y, int _size, int _speed, Array _monster)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            _monster = monster;
        }

        public void move(Monster m, int direction)
        {
            if (direction == 0)
            {
                m.x -= m.speed;
            }
            else if (direction == 1)
            {
                m.x += m.speed;
            }
            else if (direction == 2)
            {
                m.y -= m.speed;
            }
            else if (direction == 3)
            {
                m.y += m.speed;
            }
        }
        //collision between bullet and monster
        public bool bulletCollision(Monster m, Bullet b)
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
