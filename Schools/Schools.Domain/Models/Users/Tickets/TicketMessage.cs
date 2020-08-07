using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Users.Tickets
{
    public class TicketMessage
    {
        [Key]
        public int MessageId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "متن تیکت را وارد کنید")]
        public string MessageText { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
        [Required]
        public bool IsSeen { get; set; }
        [Required]
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("TicketId")]
        public UserTicket UserTicket { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}