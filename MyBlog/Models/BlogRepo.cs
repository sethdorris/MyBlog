﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class BlogRepo
    {
        private BlogContext context { get; set; }
        public BlogContext Context { get { return context; } }

        public BlogRepo(BlogContext _context)
        {
            context = _context;
        }

        public List<Post> GetAllPosts()
        {
            var query = from posts in context.Posts select posts;
            return query.ToList();
        }

        public List<User> GetAllUsers()
        {
            var query = from users in context.BlogUsers select users;
            return query.ToList();
        }

        public List<User> GetUserByHandle(string handle)
        {
            var query = from users in context.BlogUsers.Where(o => o.Handle.Contains(handle)) select users;
            return query.ToList();
        }
    }
}