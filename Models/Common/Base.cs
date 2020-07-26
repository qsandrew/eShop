using System;
using System.ComponentModel.DataAnnotations;

namespace eShop.Models.Common
{
    public class Base
    {
        public int Id {get;set;}
        public bool IsDeleted {get;set;}
        public Base(){
        }
        [Required]
        public string Name {get;set;}
    }
}