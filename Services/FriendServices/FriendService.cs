using Pass_It_Out.Context;
using Pass_It_Out.Models;

namespace Pass_It_Out.Services.FriendServices
{
    public class FriendService : IFriend
    {
        private Pass_It_Out_CTX ctx;

        public FriendService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }

        public List<Friend> GetAllFriends(string UserId)
        {
            List<Friend> friends= ctx.Friends.Where(val=>val.UserId==UserId).ToList();
            return friends;
        }

        public bool Save(Friend friend)
        {
            ctx.Friends.Add(friend);
            int rowsimpacted = ctx.SaveChanges();
            return rowsimpacted > 0;
        }
    }
}
