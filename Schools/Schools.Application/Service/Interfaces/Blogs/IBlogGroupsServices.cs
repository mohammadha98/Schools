using Schools.Application.ViewModels.BlogsViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Service.Interfaces.Blogs
{
    public interface IBlogGroupsServices
    {
        IEnumerable<ShowGroupsViewModels> GetListGroups();
    }
}
