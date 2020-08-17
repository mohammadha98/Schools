using Microsoft.AspNetCore.Mvc;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.WebApp.Components.BlogComponents
{
    public class ShowLatesBlogComponent:ViewComponent
    {
        private IBlogRepository _blogRepository;
        public ShowLatesBlogComponent(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowLatesBlogComponent",
                _blogRepository.GetLatesBlog()));
        }
    }
}
