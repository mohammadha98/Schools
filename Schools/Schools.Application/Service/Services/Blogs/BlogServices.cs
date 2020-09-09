using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.Application.Service.Services.Blogs
{
    public class BlogServices : IBlogServices
    {

        private IBlogRepository _blog;

        public BlogServices(IBlogRepository blog)
        {
            _blog = blog;
        }

        public bool AddBlog(Blog blog, IFormFile image)
        {
            if (image == null) return false;
            if (!image.IsImage()) return false;

            var fileName = SaveFileInServer.SaveFile(image, "wwwroot/images/blogs");
            blog.IsDelete = false;
            blog.CreateDate = DateTime.Now;
            blog.ShortLink = GenerateShortKey(4);
            blog.ImageName = fileName;
            _blog.InsertBlog(blog);
            return true;
        }

        public bool EditBlog(Blog blog, IFormFile image)
        {
            if (image != null)
            {
                if (!image.IsImage()) return false;

                DeleteFileFromServer.DeleteFile(blog.ImageName, "wwwroot/images/blogs");
                var fileName = SaveFileInServer.SaveFile(image, "wwwroot/images/blogs");
                blog.ImageName = fileName;
            }
            _blog.UpdateBlog(blog);
            return true;
        }

        public BlogCategoryViewModel GetBlogsByFilter(int pageId, int take, string search, int? typeId, string groupTitle)
        {
            var result = _blog.GetAllBlogs();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                result = result.Where(r => r.Title.Contains(search) || r.Tags.Contains(search));
            }
            if (!string.IsNullOrEmpty(groupTitle))
            {
                result = result.Where(r => r.BlogGroup.GroupName == groupTitle);
            }

            if (typeId != null)
            {
                switch (typeId)
                {
                    case 4:
                        result = result.Where(r => r.TypeId == 4);
                        break;
                    case 5:
                        result = result.Where(r => r.TypeId == 5);
                        break;
                }
            }


            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);
            var blogs = result.OrderByDescending(b => b.CreateDate).Skip(skip).Take(take).Select(b => new BlogViewModel()
            {
                GroupTitle = b.BlogGroup.GroupName,
                ImageName = b.ImageName,
                CreateDate = b.CreateDate,
                Title = b.Title,
                BlogId = b.BlogId,
                BlogType = b.TypeId == 4 ? "خبر" : "مقاله",
                ShortLink = b.ShortLink
            }).ToList();
            var blogsModel = new BlogCategoryViewModel()
            {
                GroupTitle = groupTitle,
                Search = search,
                TypeId = typeId,
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                Blogs = blogs
            };
            return blogsModel;
        }

        public List<BlogViewModel> GetLastBlogs(int take)
        {
            var blogModel = _blog.GetAllBlogs().OrderByDescending(b => b.CreateDate).Take(take).Select(b =>
                new BlogViewModel()
                {
                    GroupTitle = b.BlogGroup.GroupName,
                    ImageName = b.ImageName,
                    CreateDate = b.CreateDate,
                    Title = b.Title,
                    BlogId = b.BlogId,
                    BlogType = b.TypeId == 4 ? "اخبار" : "مقالات",
                    ShortLink = b.ShortLink
                }).ToList();
            return blogModel;
        }

        public void AddVisitForBlog(Blog blog)
        {
            blog.BlogVisit += 1;
            _blog.UpdateBlog(blog);
        }

        private string GenerateShortKey(int length)
        {
            //در این جا یک کلید با طول دلخواه تولید میکنیم
            var key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

            while (_blog.GetBlog(key) != null)
            {
                //تا زمانی که کلید ساخته شده تکراری باشد این اعملیات تکرار میشود

                key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            }
            //در آخر یک کلید غیره تکراری با طول دلخواه ساخته شده
            return key;
        }
    }
}
