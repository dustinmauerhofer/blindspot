using System;

namespace MyBlindSpot.Classes
{
    public class UserInformation
    {
        private static UserInformation instance;

        // Properties
        public int? Id { get; }
        public string UserName { get; }

        // Private constructor to prevent instantiation outside the class
        public UserInformation(int id, string username)
        {
            Id = id;
            UserName = username;
        }  
       
    }
}
