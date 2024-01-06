using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class APICalls
    {
        public static List<Storage> LoadStorages()
        {
            //Funktion soll alle exsistierenden Storages eines Users über http pullen > diese in Storage objekte verwandeln und dann als gebündelte Liste returnen
            return new List<Storage>();
        }

        public static Storage LoadSpecificStorage(int id)
        {
            //diese Funktion soll einen Spezifischen Storage über http pullen und diesen als Storage object returnen
            return new Storage("",5,5);
        }
    }
}
