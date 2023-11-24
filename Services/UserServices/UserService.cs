using Pass_It_Out.Context;
using Pass_It_Out.Models;

namespace Pass_It_Out.Services.UserServices
{
    public class UserService : IUser
    {
        private Pass_It_Out_CTX ctx;

        public UserService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }
        public User GetUserById(string id)
        {
            return ctx.Users.Where(val => val.UserId == id).FirstOrDefault();
        }

        public User IsUserExit(User user)
        {
            return ctx.Users.Where(val => val.UserId == user.UserId && val.Password==user.Password).FirstOrDefault();
        }

        public bool Login(User user)
        {
            return true;
        }

        public bool Registration(User user)
        {
            ctx.Users.Add(user);
            int rowsupdated = ctx.SaveChanges();
            return rowsupdated > 0;
        }
    }
}
