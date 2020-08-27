using System;
using System.Collections.Generic;
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
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string SenderText { get; set; }
        [Required(ErrorMessage = "عنوان پیام را وارد کنید")]
        public string MessageTitle { get; set; }
        public DateTime CreateDate { get; set; }

        #region Relations
        public List<MessageContent> MessageContents { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }
        #endregion

    }
}