using System;

namespace eShop.Models.Common
{
    public class Base
    {
        public int Id {get;set;}
        public bool IsDeleted {get;set;}
        public Base(){
        }
        public string Name {get;set;}
    }
}