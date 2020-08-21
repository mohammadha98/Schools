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
                result = result.Where(c => c.Title.Contains(filter) || c.Tags.Contains(filter));
            }

            switch (typeId)
            {
                case 0:
                    break;
                case 1:
                    {
                        result = result.Where(c => c.TypeId == 1);
                        break;
                    }
                case 2:
                    {
                        result = result.Where(c => c.TypeId == 2);
                        break;
                    }
            }

            if (groupId != 0)
            {
                result = result.Where(c => c.GroupId == groupId);
            }

            int skip = (pageId - 1) * take;

            int pageCount= result.Include(c => c.BlogType).Include(c => c.BlogGroup)
                .Select(c => new ShowCourseBlogViewModel()
                {
                    BlogId = c.BlogId,
                    BlogType = c.BlogType.TypeTitle,
                    BlogGroup = c.BlogGroup.GroupName,
                    CreateDate = c.CreateDate,
                    ImageName = c.ImageName,
                    Title = c.Title
                }).Count()/take;

            var query = result.Include(c => c.BlogType).Include(c=>c.BlogGroup)
                .Select(c => new ShowCourseBlogViewModel()
            {
                BlogId=c.BlogId,
                BlogType=c.BlogType.TypeTitle,
                BlogGroup=c.BlogGroup.GroupName,
                CreateDate=c.CreateDate,
                ImageName=c.ImageName,
                Title=c.Title
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        List<BlogsViewModels> IBlogServices.FilterBlog(string filter, int getType, List<int> selectedGroups = null)
        {
            IQueryable<Blog> result = _context.Blogs;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => c.Title.Contains(filter)||c.BlogId.ToString().Contains(filter));
            }

            switch (getType)
            {
                case 0:
                    break;
                case 1:
                    {
                        result = result.Where(c => c.TypeId == 1);
                        break;
                    }
                case 2:
                    {
                        result = result.Where(c => c.TypeId == 2);
                        break;
                    }
            }

            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(c => c.GroupId == groupId);
                }
            }
            var query = result.Include(c=>c.BlogType).Select(c => new BlogsViewModels()
            {
                BlogId = c.BlogId,
                GroupId = c.GroupId,
                ImageName = c.ImageName,
                TypeId = c.TypeId,
                Title = c.Title,
                ShortDescription=c.ShortDescription,
                CreateDate = c.CreateDate,
                BlogType=c.BlogType.TypeTitle
            }).ToList();

            return query;
        }
    }
}
