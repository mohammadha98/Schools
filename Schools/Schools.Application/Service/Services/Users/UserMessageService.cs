using System;
using System.Globalization;
using System.Linq;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Convertors;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Service.Services.Users
{
    public class UserMessageService:IUserMessageService
    {
        private IUserMessageRepository _message;

        public UserMessageService(IUserMessageRepository message)
        {
            _message = message;
        }

        public MessagesViewModel GetUserMessages(int pageId, int take, int userId,string startDate,string endDate)
        {
            var result = _message.GetUserMessages(userId);
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
                result = result.Where(r => r.CreateDate.Date >= startDateTime);
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
                result = result.Where(r => r.CreateDate.Date <= endDateTime);
            }


            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);
            var messagesModel = new MessagesViewModel()
            {
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                UserMessages = result.OrderByDescending(c=>c.CreateDate).Skip(skip).Take(take).ToList(),
                EndDate = endDate,
                StartDate = startDate
            };
            return messagesModel;
        }

        public void SeenMessages(int messageId,int userId)
        {
            var message = _message.GetUserMessage(messageId);
            foreach (var item in message.MessageContents.Where(c=>c.UserId != userId))
            {
                if (item.IsSeen) continue;

                item.IsSeen = true;
                _message.UpdateMessageContent(item);
            }
            _message.SaveChange();
        }

        public void AddMessage(UserMessage message)
        {
         
            _message.AddMessage(message);
        }
    }
}