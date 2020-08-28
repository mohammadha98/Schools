using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Convertors;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Service.Services.Users
{
    public class UserTicketService : IUserTicketService
    {
        private IUserTicketRepository _ticket;

        public UserTicketService(IUserTicketRepository ticket)
        {
            _ticket = ticket;
        }
        public TicketsViewModel GetUserTicketsWithFilter(int userId, int pageId, int take, string startDate, string endDate)
        {
            var result = _ticket.GetUserTickets(userId);
            if (!string.IsNullOrEmpty(startDate))
            {
                // عضو اول سال ، عضو دوم ماه ، عضو سوم روز
                //std[0]=سال | std[1]= ماه | std[2]=روز
                string[] std = startDate.Split("/");

                //تبدیل تاریخ شمسی به میلادی
                var startDateTime = new DateTime(
                    int.Parse(std[0].PersianToEnglish()),//سال
                    int.Parse(std[1].PersianToEnglish()),//ماه
                    int.Parse(std[2].PersianToEnglish()),//روز
                    new PersianCalendar()//نوع تاریخ
                );
                result = result.Where(r => r.CreateDate.Date >= startDateTime.Date);
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                // عضو اول سال ، عضو دوم ماه ، عضو سوم روز
                //std[0]=سال | std[1]= ماه | std[2]=روز
                string[] std = endDate.Split("/");

                //تبدیل تاریخ شمسی به میلادی
                var endDateTime = new DateTime(
                    int.Parse(std[0].PersianToEnglish()),//سال
                    int.Parse(std[1].PersianToEnglish()),//ماه
                    int.Parse(std[2].PersianToEnglish()),//روز
                    new PersianCalendar()//نوع تاریخ
                );
                result = result.Where(r => r.CreateDate.Date <= endDateTime.Date);
            }

            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var ticketsModel = new TicketsViewModel()
            {
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                EndDate = endDate,
                StartDate = startDate,
                UserTickets = result.OrderByDescending(t => t.CreateDate).Skip(skip).Take(take).ToList()
            };
            return ticketsModel;
        }

        public GetTicketsViewModel GetTicketsForAdmin(int pageId, int take,string title,string status, int? priorityId, int? categoryId)
        {
            var result = _ticket.GetAllTickets();
            if (!string.IsNullOrEmpty(title))
            {
                result = result.Where(r => r.TicketTitle.Contains(title));
            }

            if (priorityId != null)
            {
                result = result.Where(r => r.PriorityId == priorityId);

            }
            if (categoryId != null)
            {
                result = result.Where(r => r.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(status))
            {
                switch (status)
                {
                    case "all":
                        break;
                    case "open":
                        result = result.Where(r => r.IsOpen);
                        break;
                    case "close":
                        result = result.Where(r => r.IsOpen == false);
                        break;
                }
            }
           
            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var ticketsModel = new GetTicketsViewModel()
            {
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                UserTickets = result.Skip(skip).Take(take).ToList(),
                Status = status,
                Title = title
            };
            return ticketsModel;
        }

        public UserTicket GetTicketById(int ticketId)
        {
            return _ticket.GetUserTicket(ticketId);
        }

        public int AddTicket(UserTicket ticket)
        {
            ticket.IsOpen = true;
            ticket.IsDelete = false;
            ticket.CreateDate=DateTime.Now;
            _ticket.AddTicket(ticket);
            return ticket.TicketId;
        }

        public List<TicketCategory> GetTicketCategories()
        {
            return _ticket.GetTicketCategories();
        }

        public List<TicketPriority> GetTicketPriority()
        {
            return _ticket.GetTicketPriorities();
        }

        public void AddTicketToMessage(int ticketId, string message, int userId)
        {
            var messageModel=new TicketMessage()
            {
                IsDelete = false,
                IsSeen = true,
                MessageText = message,
                SendDate = DateTime.Now,
                TicketId = ticketId,
                UserId = userId
            };
            _ticket.AddMessageToTicket(messageModel);
        }
    }

}