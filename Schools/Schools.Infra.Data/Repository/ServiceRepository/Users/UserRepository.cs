using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserRepository:IUserRepository
    {
        private SchoolsDbContext _context;

        public UserRepository(SchoolsDbContext context)
        {
            _context = context;
        }

        public void AddRolesForUser(List<int> SelectedRoles, int userId)
        {
            foreach(var item in SelectedRoles)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    IsDelete = false,
                    UserId = userId,
                    RoleId = item,
                });
                _context.SaveChanges();
            }
        }

        public void AddRoleUserForRegister(int roleId, int userId)
        {
            _context.UserRoles.Add(new UserRole()
            {
                IsDelete = false,
                UserId = userId,
                RoleId = roleId
            });
            _context.SaveChanges();
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public void EditUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public List<School> GetAllSchoolInUserLikesByUserId(int userId)
        {
            return _context.UserLikes.Where(u => u.UserId == userId).Select(s => s.School).ToList();
        }

        public List<string> GetAllUserRolesByUserId(int userId)
        {
            return _context.UserRoles.Where(u => u.UserId == userId).Select(r => r.Role.RoleTitle).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == userId);
        }

        public User GetUserWithRelations(int userId)
        {
            return _context.Users.Include(u => u.UserLikes)
                .ThenInclude(u => u.School)
                .Include(u => u.ReceiverMessages)
                .ThenInclude(u => u.MessageContents)
                .Include(t=>t.UserTickets)
                .ThenInclude(t=>t.TicketMessages)
                .Include(u=>u.ReceiverMessages)
                .ThenInclude(t=>t.Sender)
                .Include(u=>u.UserNotifications)
                .Include(u=>u.TeacherRates)
                .ThenInclude(u=>u.SchoolTeacher)
                .ThenInclude(t=>t.User)
                .Include(u=>u.SchoolRates)
                .ThenInclude(u=>u.School)
                .SingleOrDefault(u => u.UserId == userId);
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Users;
        }

        public bool IsUserExist(int userId)
        {
            return _context.Users.Any(u => u.UserId == userId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}