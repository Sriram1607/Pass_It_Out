using Pass_It_Out.Models;

namespace Pass_It_Out.Services.FriendServices
{
    public interface IFriend
    {
        bool Save(Friend friend);
        List<Friend> GetAllFriends(string UserId);
    }
}
