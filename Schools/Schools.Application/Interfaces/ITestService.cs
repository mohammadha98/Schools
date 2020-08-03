using Schools.Application.ViewModels;
using Schools.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Interfaces
{
   public interface ITestService
    {
        List<TestVM> GetTests();
    }
}
