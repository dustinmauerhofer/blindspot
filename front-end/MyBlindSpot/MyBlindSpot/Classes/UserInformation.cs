using System;

namespace MyBlindSpot.Classes
{

    public class UserInformation
    {
        private static UserInformation instance;

        // Properties
        public string Jwt { get; }
        public string UserName { get; }

        // Private constructor to prevent instantiation outside the class
        public UserInformation(string jwt, string username)
        {
            Jwt = jwt;
            UserName = username;
        }

        public static User user;
    }
}
