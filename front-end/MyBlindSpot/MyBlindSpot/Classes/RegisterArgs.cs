using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class RegisterArgs : EventArgs
    {
        public string Response { get; }

        public RegisterArgs(string response)
        {
            Response = response;
        }
    }
}
