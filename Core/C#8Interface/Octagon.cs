using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.C_8Interface
{
    public class Octagon : IRegularPolygon
    {
        public int NumberOfSides { get ; set; }
        public int SideLength { get ; set ; }

        public Octagon(int length) {
            NumberOfSides = 8;
            SideLength = length;
        }

        #region Check Yield keyword
        public int GetNumber() { return 5; }

        public IEnumerable<int> GetNumber2()
        {
            yield return 5;
            yield return 10;
            yield return 15;
        }
        //check yield keyword 
        public IEnumerable<int> Numbers(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("Returning {0}", i);
                yield return i;
            }
        }
        #endregion

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        public double GetArea()
        {
            //Console.WriteLine(GetNumber());
            //foreach (int i in GetNumber2()) Console.WriteLine(i); 
            //foreach (int i in Numbers(10).Take(3))
            //{
            //    Console.WriteLine("Number {0}", i);
            //}
            return SideLength * SideLength * (2 + 2 * Math.Sqrt(2));
        }
    }
}
