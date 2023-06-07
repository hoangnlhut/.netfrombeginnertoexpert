using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.C_8Interface
{
    public class Square: ConcreteRegularPolygon
    {
        public Square(int length): base(4, length) { 
        }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }
    }
}
