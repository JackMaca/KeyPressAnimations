using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Bullet
    {
        public int x, y, size, speed, direction;
        public Bullet(int _x, int _y, int _size, int _speed, int _direction)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
        }
        public void move(Bullet b, int direction)
        {
            if (direction == 0)
            {
                b.x -= b.speed;
            }
            else if (direction == 1)
            {
                b.x += b.speed;
            }
            else if (direction == 2)
            {
                b.y -= b.speed;
            }
            else if (direction == 3)
            {
                b.y += b.speed;
            }
        }
    }
}
