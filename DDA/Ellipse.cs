using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsPackage
{
    class Ellipse
    {
        private int x;
        private int y;
        private int rx;
        private int ry;

        public Ellipse(int x, int y, int rx, int ry)
        {
            this.x = x;
            this.y = y;
            this.rx = rx;
            this.ry = ry;

        }

        public void setCoords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void incrementX()
        {
            x++;
        }

        public void decrementY()
        {
            y--;
        }
    }
}
