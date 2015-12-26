using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlog.Models;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyBlog.Tests.Models
{
    [TestClass]
    public class BlogRepoTests
    {
        private Mock<BlogContext> _mycontext;
        private Mock<DbSet<Post>> _postSet;
        private Mock<DbSet<User>> _userSet;
        private BlogRepo _myrepo;

        [TestInitialize]
        public void Initialize()
        {
            _mycontext = new Mock<BlogContext>();
            _postSet = new Mock<DbSet<Post>>();
            _userSet = new Mock<DbSet<User>>();
            _myrepo = new BlogRepo(_mycontext.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mycontext = null;
            _postSet = null;
            _userSet = null;
            _myrepo = null;
        }

        [TestMethod]
        public void ConnectMocksToDataStore(IEnumerable<Post> data_source)
        {
            var data = data_source.AsQueryable();
            _postSet.As<IQueryable<Post>>().Setup(p => p.Provider).Returns(data.Provider);
            _postSet.As<IQueryable<Post>>().Setup(p => p.Expression).Returns(data.Expression);
            _postSet.As<IQueryable<Post>>().Setup(p => p.ElementType).Returns(data.ElementType);
            _postSet.As<IQueryable<Post>>().Setup(p => p.GetEnumerator()).Returns(data.GetEnumerator());
            _mycontext.Setup(p => p.Posts).Returns(_postSet.Object);
        }


        [TestMethod]
        public void BlogRepoTestsEnsureICanGetAllPosts()
        {
            List<Post> expected = new List<Post>
            {
                new Post { PostID = 1, Title = "NEWS" },
                new Post { PostID = 2, Title = "NEWS2" }
            };

            ConnectMocksToDataStore(expected);
            List<Post> actual = _myrepo.GetAllPosts();
            Assert.AreEqual(expected[0].PostID, actual[0].PostID);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
