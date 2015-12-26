using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Post : IComparable
    {
        [Key]
        public int PostID;
        public User Author;
        public DateTime DateTime;
        public string Title;
        public string Content;
        public string ImageURL;

        public int CompareTo(object obj)
        {
            Post post = obj as Post;
            return 1 * (this.DateTime.CompareTo(post.DateTime));
        }
    }
}