using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.WebApp.Components
{
    public class ShowBlogGroupsComponent:ViewComponent
    {
        private IBlogGroupsServices _groupServices;
        public ShowBlogGroupsComponent(IBlogGroupsServices groupsServices)
        {
            _groupServices = groupsServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowBlogGroupsComponent",
                _groupServices.GetListGroups()));
        }
    }
}
