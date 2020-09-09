using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Users;

namespace Schools.Domain.Models.Schools
{
    public class SchoolRequest
    {
        [Key]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime BuildDate { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public int ShireId { get; set; }
        [Required]
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ImageName { get; set; }
        public string Fax { get; set; }
        [Required]
        public string CellPhone { get; set; }
        [Required]
        public string TelePhone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string TrainingTypes { get; set; }
        public string DocumentsImage { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAccept { get; set; }


        #region Relation

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<RequestGallery> Galleries { get; set; }


        #endregion
    }
}