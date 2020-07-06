using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eShop.Models.Common;
using eShop.Models.EntInfo.Reference;

namespace eShop.Models.EntInfo
{
    public class Employee : Base
    {
        [Required]
        [MinLength(5), MaxLength(8)]
        public string Login { get; set; }
        [Required]
        [MinLength(5), MaxLength(10)]
        public string Password { get; set; }
        [Required]
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(12), MinLength(12)]
        public string IIN { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public DateTime FromDate { get; set; }
        public StatusWork StatusWork { get; set; }

        public Enterprise Enterprise{get;set;}
        public int EnterpriseId{get;set;}

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.SurName + " " + this.Name + " " + this.MiddleName;
            }
        }
    }
}