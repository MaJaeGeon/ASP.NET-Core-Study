using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Services.Svcs
{
    public class UserService : IUser
    {
        bool IUser.MatchTheUserInfo(LoginInfo login)
        {
            return checkTheUserInfo(login.UserId, login.Password);
        }

        #region Private Methods

        private IEnumerable<User> GetUserInfos()
        {
            return new List<User>
            {
                new User
                {
                    UserId      = "akworjs0517",
                    UserName    = "마재건",
                    UserEmail   = "akworjs0517@gmail.com",
                    Password    = "123456"
                }
            };
        }

        private bool checkTheUserInfo(string userId, string password)
        {
            return GetUserInfos().Where(u => u.UserId.Equals(userId) && u.Password.Equals(password)).Any();
        }

        #endregion
    }
}