using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class StorageInformation
    {
        public string StoredObject { get; set; }
        public (int, int) Location { get; set; } //x,y location where item is stored
        public List<int> Space { get; set; } //left middel right allignment (-1) (0) (1)
        public int FrontBackAlignment { get; set; } // front (0) or back (1)

        public StorageInformation() { }
    }
}
