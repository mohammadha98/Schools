﻿using Microsoft.Extensions.DependencyInjection;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Service.Interfaces.Schools.Teacher;
using Schools.Application.Service.Services.Locations;
using Schools.Application.Service.Services.Schools;
using Schools.Application.Service.Services.Schools.Teacher;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Repository.ServiceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Domain.Repository.InterfaceRepository.Locations;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Repository.ServiceRepository.BlogRepositoris;
using Schools.Infra.Data.Repository.ServiceRepository.Locations;
using Schools.Infra.Data.Repository.ServiceRepository.Users;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Service.Services.Users;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Service.Services.Blogs;

namespace Schools.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //From Application Layer
            #region Locations

            service.AddScoped<ILocationService, LocationService>();

            #endregion

            #region School
            service.AddScoped<ISchoolService, SchoolService>();
            service.AddScoped<ISchoolGroupsService, SchoolGroupsService>();
            service.AddScoped<ISchoolGalleryService, SchoolGalleryService>();
            service.AddScoped<ISchoolTeacherService, SchoolTeacherService>();
            service.AddScoped<ISchoolTrainingTypeService, SchoolTrainingTypeService>();
            service.AddScoped<ISchoolCommentService, SchoolCommentService>();
            #endregion

            #region Blog

            service.AddScoped<IBlogServices, BlogServices>();
            service.AddScoped<IBlogGroupsServices, BlogGroupsServices>();

            #endregion

            #region Users

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserTicketService, UserTicketService>();
            service.AddScoped<IUserNotificationService, UserNotificationService>();
            service.AddScoped<IUserMessageService, UserMessageService>();

            #endregion
            //From Infra Data Layer

            #region Locations
            service.AddScoped<ILocationRepository, LocationRepository>();
            #endregion

            #region Schools
            service.AddScoped<ISchoolGroupsRepository, SchoolGroupsRepository>();
            service.AddScoped<ISchoolRepository, SchoolRepository>();
            service.AddScoped<ISchoolGalleryRepository, SchoolGalleryRepository>();
            service.AddScoped<ISchoolTeacherRepository, SchoolTeacherRepository>();
            service.AddScoped<ITeacherRateRepository, TeacherRateRepository>();
            service.AddScoped<ISchoolTrainingTypeRepository, SchoolTrainingTypeRepository>();
            service.AddScoped<ISchoolCommentRepository, SchoolCommentRepository>();
            service.AddScoped<ISchoolRateRepository, SchoolRateRepository>();
            #endregion

            #region Blogs
            service.AddScoped<IBlogRepository, BlogRepository>();
            service.AddScoped<IBlogGroupsRepository, BlogGroupRepositoy>();
         
            #endregion

            #region Users

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserTicketRepository, UserTicketRepository>();
            service.AddScoped<IUserMessageRepository, UserMessageRepository>();
            service.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
            service.AddScoped<IUserLikeRepository, UserLikeRepository>();

            #endregion
        }
    }
}
