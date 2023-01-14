﻿using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjetDotNet.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext _applicationDbContext) : base(_applicationDbContext)
        {
        }
        public new IEnumerable<Post> GetAll()
        {
            return _applicationDbContext.Post.Include(x => x.Author).ToList();
        }
        
        public IEnumerable<Post>? GetPostsByAuthor(int userId)
        {
            IEnumerable<Post> posts = _applicationDbContext.Post.Where(x => x.Author.Id == userId);
            return posts;
        }
        public void upvotePost(int postId, bool isUp) 
        {
            Post post = _applicationDbContext.Post.Find(postId);
            if (isUp)
            {
                post.Upvotes += 1;
            }
            else
            {
                post.Upvotes -= 1;
            }
        }
    }
}