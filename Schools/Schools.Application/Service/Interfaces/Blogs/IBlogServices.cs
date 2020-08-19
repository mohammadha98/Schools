using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Service.Interfaces.Blogs
{
    public interface IBlogServices
    {
        List<BlogsViewModels> FilterBlog(string filter = "", int getType = 0, List<int> selectedGroups = null);
        Tuple<List<ShowCourseBlogViewModel>,int> GetCourse(int pageId = 1, string filter="",int typeId=0, int groupId=0,int take=0);
    }
}
