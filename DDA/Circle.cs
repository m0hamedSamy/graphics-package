using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsPackage
{
    internal class Circle
    {
        private int x;
        private int y;

        public Circle()
        {
            x=y=0;

        }

        public void setCoords(int xCoordValue,int  yCoordValue)
        {
            x = xCoordValue;
            y = yCoordValue;
        }

        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
        public void incrementx()
        {
            x++;
        }
        public void decrementy()
        {
            y--;
        }
    }
}
