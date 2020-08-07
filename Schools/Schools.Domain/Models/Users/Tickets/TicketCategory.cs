using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Users.Tickets
{
    public class TicketCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public bool IsDelete { get; set; }
        #region Relations

        public List<UserTicket> UserTickets { get; set; }
        #endregion
    }
}