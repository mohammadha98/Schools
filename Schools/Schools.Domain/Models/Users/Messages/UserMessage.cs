using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Users.Messages
{
    public class UserMessage
    {
        [Key]
        public int Um_Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }

        #region Relations
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
        #endregion

    }
}