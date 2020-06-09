using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eShop.Models.Common;
using eShop.Models.Enterprise.Reference;

namespace eShop.Models.Enterprise
{
    public class Employee : Base
    {
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

        [NotMapped]
        public string FullName {get{
            return this.SurName+" "+ this.Name+ " " + this.MiddleName;
        }}
    }
}