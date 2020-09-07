using System;
using System.Linq;
using Schools.Application.Service.Interfaces.ContactUses;
using Schools.Application.Utilities;
using Schools.Application.ViewModels;
using Schools.Domain.Models.ContactUs;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;

namespace Schools.Application.Service.Services.ContactUses
{
    public class ContactUsFormService:IContactUsFormService
    {
        private IContactUsFormRepository _contact;

        public ContactUsFormService(IContactUsFormRepository contact)
        {
            _contact = contact;
        }
        public ContactUsFormViewModel GetContactUses(int pageId, int take, bool isPosted)
        {
            var result = _contact.GetContactUses();
            if (isPosted)
            {
                result = result.Where(r => r.IsPosted);
            }
            else
            {
                result = result.Where(r => !r.IsPosted);

            }

            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var model =new ContactUsFormViewModel()
            {
                ContactUses = result.OrderByDescending(c=>c.CreateDate).Skip(skip).Take(take).ToList(),
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                IsPosted = isPosted
            };
            return model;
        }

        public void SendAnswerForContactUs(ContactUsForm contactUs, string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                return;
            }
            try
            {
                var emailBody = $"<h3 style='text-align:center'>{contactUs.FullName} عزیز درخواست پشتیبانی شما پاسخ داده شد. </h3><h4>پاسخ پیام پشتیبانی  '{contactUs.Subject} ' :</h3>{answer}";
                SendEmail.Send(contactUs.Email,"پاسخ پیام پشتیبانی",emailBody.BuildView());
            }
            catch (Exception e)
            {
                return;
            }
            contactUs.IsPosted = true;
            contactUs.AgentAnswer = answer;
            contactUs.AnswerDate=DateTime.Now;
            _contact.EditContactUs(contactUs);
        }
    }
}