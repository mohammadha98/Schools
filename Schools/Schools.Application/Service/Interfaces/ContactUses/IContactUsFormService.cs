using Schools.Application.ViewModels;
using Schools.Domain.Models.ContactUs;

namespace Schools.Application.Service.Interfaces.ContactUses
{
    public interface IContactUsFormService
    {
        ContactUsFormViewModel GetContactUses(int pageId, int take, bool isPosted);
        void SendAnswerForContactUs(ContactUsForm contactUs,string answer);
    }
}