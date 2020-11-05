using System;
using System.Data;
using System.Data.SqlClient;

namespace RestApiTest
{
    public class Sqlservercon
    {
        public UserData Selectuser(string username)
        {
            UserData user = new UserData();
            user.Email = "Test";
            user.Name = "Test";
            user.Password = "Test";
            return user;
        }
        public UserData Adduser(UserData userdata)
        {
            UserData user = new UserData();
            user.Email = "Test";
            user.Name = "Test";
            user.Password = "Test";
            return user;
        }
        public UserData Updateuser(UserData userdata)
        {
            UserData user = new UserData();
            user.Email = "Test";
            user.Name = "Test";
            user.Password = "Test";
            return user;
        }
        public UserData Deleteuser(UserData userdata)
        {
            UserData user = new UserData();
            user.Email = "Test";
            user.Name = "Test";
            user.Password = "Test";
            return user;
        }
    }
}
