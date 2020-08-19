using System.Collections.Generic;
using Schools.Domain.Models.Schools;

namespace Schools.Application.ViewModels.SchoolsViewModels
{
    public class SchoolCommentsViewModel
    {
        public List<SchoolComment> SchoolComments { get; set; }
        public List<SchoolComment> AnswerComments { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}