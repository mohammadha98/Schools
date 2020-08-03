using Schools.Application.Interfaces;
using Schools.Application.ViewModels;
using Schools.Domain.Interfaces;
using Schools.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Services
{
    public class TestService : ITestService
    {
        private ITestRepository _testRepository;


        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }



        public TestVM GetTests()
        {
            return new TestVM
            {
                AllTest = _testRepository.GetTests()
            };
        }
    }
}
