using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class Items
    {
        public string Name { get; }
        public int LeftRightAlignment { get; }
        public int FrontBackAlignment { get; }

        public Items(string name, int lfa, int fba)
        {
            Name = name;
            LeftRightAlignment = lfa;
            FrontBackAlignment = fba;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();        
            builder.Append("Name: " + Name + ", ");

            //leftrightalignment
            if(LeftRightAlignment == -1)
            {
                builder.Append("Alignment: rechts, ");
            }
            else if(LeftRightAlignment == 1)
            {
                builder.Append("Alignment: links, ");
            }
            else
            {
                builder.Append("Alignment: mitte, ");
            }

            //frontbackalignment

            if(FrontBackAlignment == -1)
            {
                builder.Append("Alignment: hinten");
            }
            else if (FrontBackAlignment == 1)
            {
                builder.Append("Alignment: vorne");
            }
            else
            {
                builder.Append("Alignment: mitte");
            }

            return builder.ToString();
        }
    }
}
