using System;

namespace MyBlindSpot.Classes
{
    public class UserInformation
    {
        private static UserInformation instance;

        // Properties
        public int? Id { get; private set; }
        public string UserName { get; private set; }

        // Private constructor to prevent instantiation outside the class
        private UserInformation()
        {
            Id = null;
            UserName = null;
        }

        // Method to get the singleton instance
        public static UserInformation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInformation();
                }
                return instance;
            }
        }

        // Method to set user information
        public void SetUserInformation(int id, string userName)
        {
            if (Id == null)
            {
                Id = id;
                UserName = userName;
            }
            else
            {
                // Handle the case where user information is already set
                throw new InvalidOperationException("User information can only be set once.");
            }
        }
    }
}
