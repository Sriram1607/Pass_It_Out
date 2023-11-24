using Microsoft.AspNetCore.Mvc;
using Pass_It_Out.Authentication;
using Pass_It_Out.Models;
using Pass_It_Out.Services.FriendServices;
using Pass_It_Out.ViewModels;

namespace Pass_It_Out.Controllers
{
    [UserAuthentication]
    public class FriendController : Controller
    {
        private IFriend service;

        public FriendController(IFriend service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult MyFriends()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            List<Friend> friends = service.GetAllFriends(UserId);
            ViewBag.FriendsList=friends;
            return View(friends);
        }

        public IActionResult Save(FriendsVM friendsVM)
        {
            if(ModelState.IsValid)
            {
                Friend friend=new Friend();
                friend.UserId = HttpContext.Session.GetString("UserId");
                friend.FriendId=friendsVM.FriendId;
                friend.Status = friendsVM.Status;
                friend.RequestDate=DateTime.Now;
                friend.ConfirmDate=friendsVM.ConfirmDate;
                bool success= service.Save(friend);
                if(success)
                {
                    TempData["Message"] = "Data Saved Successfully!!!";
                    return RedirectToAction("MyFriends");
                }
                else
                {
                    TempData["Message"] = "Data Not Saved!!!";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
