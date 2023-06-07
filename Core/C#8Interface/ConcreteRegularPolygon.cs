using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.C_8Interface
{
    //just a ordinary class
    public  class ConcreteRegularPolygon
    {
        //automatic properties
        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        public ConcreteRegularPolygon(int sides, int length) { 
            NumberOfSides = sides;
            SideLength = length;
        }

        //Chu vi
        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        //Diện Tích
        public virtual double GetArea()
        {
            throw new NotImplementedException();
        }

    }
}
