using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.C_8Interface
{
    public abstract class AbstractRegularPolygon
    {
        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        public AbstractRegularPolygon(int sides, int length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        //Chu vi
        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        //Diện Tích
        public abstract double GetArea();
       
    }
}
