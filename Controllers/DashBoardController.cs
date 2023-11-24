using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pass_It_Out.Authentication;
using Pass_It_Out.Models;
using Pass_It_Out.Services.PostServices;

namespace Pass_It_Out.Controllers
{
 //   [UserAuthentication]
    public class DashBoardController : Controller
    {
        private IPost service;

        public DashBoardController(IPost service) 
        { 
            this.service = service;
        }
        public IActionResult Index()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            List<Post> posts=service.GetAllPosts(UserId);
            ViewBag.AllPosts = posts;
            return View();
        }
    }
}
