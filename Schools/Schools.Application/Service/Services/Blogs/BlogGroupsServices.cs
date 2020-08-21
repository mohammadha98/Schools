﻿using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Schools.Application.Service.Services.Blogs
{
    public class BlogGroupsServices : IBlogGroupsServices
    {
        private SchoolsDbContext _context;
        public BlogGroupsServices(SchoolsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ShowGroupsViewModels> GetListGroups()
        {
            return _context.BlogGroups.Select(g => new ShowGroupsViewModels()
            {
                GroupId = g.GroupId,
                GroupName = g.GroupName
            }).ToList();
        }
    }
}
