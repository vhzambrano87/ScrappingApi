using BusinessEntity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class UserLogic
    {
        public UserData objUserData = new UserData(); 
        public User Get(int id)
        {
            return objUserData.Get(id);
        }

        public List<User> GetAll()
        {
            return objUserData.GetAll();
        }

        public bool Insert(User objUser)
        {
            return objUserData.Insert(objUser);
        }

        public bool Update(User objUser)
        {
            return objUserData.Update(objUser);
        }

        public bool ChangePassword(string username, string password, string newpassword)
        {
            return objUserData.ChangePassword(username,password,newpassword);
        }
    }
}
