using Schools.Domain.Interfaces;
using Schools.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository
{
    public class TestRepository : ITestRepository
    {
        Schools.Infra.Data.Context.SchoolsDbContext _context;


        public TestRepository(Schools.Infra.Data.Context.SchoolsDbContext context)
        {
            this._context = context;
        }


        public void SepehrisCool()
        {
            throw new NotImplementedException();
        }

        public void test()
        {
            throw new NotImplementedException();
        }

        public string TestGitHubPullAction()
        {
            throw new NotImplementedException();
        }
    }
}
