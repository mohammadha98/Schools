using Schools.Domain.Interfaces;
using Schools.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository
{
    public class TestRepository : ITestRepository
    {
        Schools.Infra.Data.Context.SchoolsDbContext _context;


        public TestRepository(Schools.Infra.Data.Context.SchoolsDbContext context)
        {
            this._context = context;
        }

        public List<Test> GetTests()
        {
            return _context.Tests.ToList();
        }

        public string TestGitHubPullAction()
        {
            throw new NotImplementedException();
        }
    }
}
