using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class User : IComparable
    {
        [Key]
        public int UserID;
        public ApplicationUser RealUser;
        public string Handle;
        public string FirstName;
        public string LastName;
        public int Age;
        public string Occupation;

        public int CompareTo(object obj)
        {
            User user = obj as User;
            return this.Handle.CompareTo(user.Handle);
        }
    }
}