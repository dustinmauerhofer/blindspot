using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.Classes
{
    public class APICalls
    {
        public static List<StorageField> LoadStorages()
        {
            //Funktion soll alle exsistierenden Storages eines Users über http pullen > diese in Storage objekte verwandeln und dann als gebündelte Liste returnen
            return new List<StorageField>();
        }

        public static StorageField LoadSpecificStorage(int id)
        {
            //diese Funktion soll einen Spezifischen Storage über http pullen und diesen als Storage object returnen
            return new StorageField("",5,5);
        }

        public static void SaveStorage(int id, StorageField storageInformation)
        {

        }

        public static async Task<string> RegisterAccount(RegisterInformation info)
        {
            return "TestOutPut";
        }
    }
}
