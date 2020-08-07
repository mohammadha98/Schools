using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Users.Messages
{
    public class MessageContent
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MessageId { get; set; }
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsSeen { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("MessageId")]
        public UserMessage UserMessage { get; set; }

        #endregion

    }
}