using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class Storage
    {
        public string Name { get; set; }
        public int XCord { get; set; }
        public int YCord { get; set; }

        public Storage(string name, int xcord, int ycord) { 
            Name = name; XCord = xcord; YCord = ycord;
        }
    }
}
