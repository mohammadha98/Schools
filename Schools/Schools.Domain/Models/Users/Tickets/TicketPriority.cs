using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Users.Tickets
{
    public class TicketPriority
    {
        [Key]
        public int PriorityId { get; set; }
        [Required]
        public string PriorityTitle { get; set; }
        public bool IsDelete { get; set; }


        #region Relations

        public List<UserTicket> UserTickets { get; set; }

        #endregion
    }
}