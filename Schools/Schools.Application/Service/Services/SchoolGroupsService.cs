using Schools.Application.Service.Interfaces;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Schools.Application.Service.Services
{
    public class SchoolGroupsService : ISchoolGroupsService
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;

        public SchoolGroupsService(ISchoolGroupsRepository schoolGroupsRepository)
        {
            this._schoolGroupsRepository = schoolGroupsRepository;
        }

       

        
    }
}
