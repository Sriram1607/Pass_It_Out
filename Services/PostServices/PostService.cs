using Microsoft.EntityFrameworkCore.Update.Internal;
using Pass_It_Out.Context;
using Pass_It_Out.Models;

namespace Pass_It_Out.Services.PostServices
{
    public class PostService : IPost
    {
        private Pass_It_Out_CTX ctx;

        public PostService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }

        public List<Post> GetAllPosts(string UserId)
        {
            List<Post> posts = ctx.Posts.Where((val => val.UserId != UserId && val.Status.Equals(true))).ToList();
            return posts;
        }
        public List<Post> GetAllPosts()
        {
            List<Post> AllPosts=ctx.Posts.Where(val=>val.PostTo=="2").ToList();
            return AllPosts;
        }
        public List<Post> MyPosts(string UserId)
        {
            return ctx.Posts.Where(val=>val.UserId==UserId).ToList();
        }
        public bool Save(Post post)
        {
            ctx.Posts.Add(post);
            int rowsimpacted=ctx.SaveChanges();
            return rowsimpacted > 0;
        }
        public List<Category> GetAllCategories() 
        { 
            return ctx.Categories.ToList();
        }
        public Post GetPostById(int id)
        {
            Post post= ctx.Posts.Where(val => val.Id == id).FirstOrDefault();
            return post;
        }

        public bool Update(Post post)
        {
            ctx.Posts.Update(post);
            int rowsupdated =ctx.SaveChanges();
            return rowsupdated > 0;
        }

      

        public List<Post> GetAllFriendsPosts()
        {
            List<Post> posts = ctx.Posts.Where(val => val.PostTo == "1").ToList();
            return posts;
        }

        public bool Update(Post post, int id)
        {
            int rowsimpacted=0;
            //Post mypost=ctx.Posts.Where(val=>val.Id==id).FirstOrDefault();
            Post updatedpost = post;
            ctx.Update(post);
            rowsimpacted = ctx.SaveChanges();
            return rowsimpacted > 0;
        }
    }
}
