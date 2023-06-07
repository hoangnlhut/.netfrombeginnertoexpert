using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.C_8Interface
{
    public interface IRegularPolygon
    {
        // all method and property IN INTERFACE is public by default
        double GetPerimeter();
        double GetArea();
        public IEnumerable<int> Numbers(int max);
    }
}
