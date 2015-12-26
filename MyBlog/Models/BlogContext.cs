using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyBlog.Models;

namespace MyBlog.Models
{
    public class BlogContext : ApplicationDbContext
    {
        public virtual DbSet<User> BlogUsers { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}