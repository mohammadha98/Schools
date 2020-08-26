using Microsoft.EntityFrameworkCore;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schools.Application.Service.Services.Blogs
{
    public class BlogServices:IBlogServices
    {
        private SchoolsDbContext _context;
        public BlogServices(SchoolsDbContext context)
        {
            _context = context;
        }

        public Tuple<List<ShowCourseBlogViewModel>, int> GetCourse(int pageId = 1, string filter="", int typeId = 0, int groupId = 0,int take=0)
        {
            if (take == 0)
                take = 21;

            IQueryable<Blog> result = _context.Blogs;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(b => b.Title.Contains(filter) || b.Tags.Contains(filter));
            }

            switch (typeId)
            {
                case 0:
                    break;
                case 1:
                    {
                        result = result.Where(b => b.TypeId == 1);
                        break;
                    }
                case 2:
                    {
                        result = result.Where(b => b.TypeId == 2);
                        break;
                    }
            }

            if (groupId != 0)
            {
                result = result.Where(b => b.GroupId == groupId);
            }

            int skip = (pageId - 1) * take;

            int pageCount= result.Include(b => b.BlogType).Include(b => b.BlogGroup)
                .Select(b => new ShowCourseBlogViewModel()
                {
                    BlogId = b.BlogId,
                    BlogType = b.BlogType.TypeTitle,
                    BlogGroup = b.BlogGroup.GroupName,
                    CreateDate = b.CreateDate,
                    ImageName = b.ImageName,
                    Title = b.Title
                }).Count()/take;

            var query = result.Include(b => b.BlogType).Include(b=>b.BlogGroup)
                .Select(b => new ShowCourseBlogViewModel()
            {
                BlogId=b.BlogId,
                BlogType=b.BlogType.TypeTitle,
                BlogGroup=b.BlogGroup.GroupName,
                CreateDate=b.CreateDate,
                ImageName=b.ImageName,
                Title=b.Title
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        List<BlogsViewModels> IBlogServices.FilterBlog(string filter, int getType, List<int> selectedGroups = null)
        {
            IQueryable<Blog> result = _context.Blogs;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(b => b.Title.Contains(filter)||b.BlogId.ToString().Contains(filter));
            }

            switch (getType)
            {
                case 0:
                    break;
                case 1:
                    {
                        result = result.Where(b => b.TypeId == 1);
                        break;
                    }
                case 2:
                    {
                        result = result.Where(b => b.TypeId == 2);
                        break;
                    }
            }

            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(b => b.GroupId == groupId);
                }
            }
            var query = result.Include(b=>b.BlogType).Select(b => new BlogsViewModels()
            {
                BlogId = b.BlogId,
                GroupId = b.GroupId,
                ImageName = b.ImageName,
                TypeId = b.TypeId,
                Title = b.Title,
                ShortDescription=b.ShortDescription,
                CreateDate = b.CreateDate,
                BlogType=b.BlogType.TypeTitle
            }).ToList();

            return query;
        }

        public Tuple<List<BlogComment>, int> GetBlogComments(int blogId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = _context.BlogComments.Where(b => !b.IsDelete && b.BlogId == blogId).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }
            return Tuple.Create(
                _context.BlogComments.Where(b => !b.IsDelete && b.BlogId == blogId).Skip(skip).Take(take)
                .OrderByDescending(b => b.CreateDate).ToList(), pageCount);
        }
    }
}
