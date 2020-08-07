using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Users.Tickets
{
    public class UserTicket
    {
        [Key]
        public int TicketId { get; set; }
        public int PriorityId { get; set; }
        public int BuilderId { get; set; }
        public int CategoryId { get; set; }
        public string TicketTitle { get; set; }
        public bool IsOpen { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsDelete { get; set; }


        #region Relations
        [ForeignKey("BuilderId")]
        public User User { get; set; }
        [ForeignKey("PriorityId")]
        public TicketPriority TicketPriority { get; set; }
        [ForeignKey("CategoryId")]
        public TicketCategory TicketCategory { get; set; }

        public List<TicketMessage> TicketMessages { get; set; }
        #endregion
    }
}