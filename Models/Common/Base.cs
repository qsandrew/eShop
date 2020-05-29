using System;

namespace eShop.Models.Common
{
    public class Base
    {
        public int Id {get;set;}
        public DateTime CreatedDate {get;set;}
        public bool IsDeleted {get;set;}
        public Base(){
            CreatedDate = DateTime.Now;
        }
        public string Name {get;set;}
    }
}