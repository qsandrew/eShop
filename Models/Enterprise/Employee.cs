using System;
using eShop.Models.Common;
using eShop.Models.Enterprise.Reference;

namespace eShop.Models.Enterprise
{
    public class Employee : Base
    {
        public string SurName {get;set;}
        public string MiddleName {get;set;}
        public string IIN {get;set;}
        public int PositionId {get;set;}
        public Position Position {get;set;}
        public DateTime FromDate {get;set;}
        public StatusWork StatusWork {get;set;}
    }
}