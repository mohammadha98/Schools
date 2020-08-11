using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Service.Interfaces.Blogs
{
    public interface IBlogServices
    {
        List<BlogsViewModels> FilterBlog(string filter = "", int getType = 0);
    }
}
