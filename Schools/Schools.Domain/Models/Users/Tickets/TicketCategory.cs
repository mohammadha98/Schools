using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Users.Tickets
{
    public class TicketCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
        public string CategoryTitle { get; set; }
        public bool IsDelete { get; set; }
        #region Relations

        public List<UserTicket> UserTickets { get; set; }
        #endregion
    }
}