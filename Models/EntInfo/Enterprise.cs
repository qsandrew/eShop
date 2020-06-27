using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using eShop.Models.Common;

namespace eShop.Models.EntInfo
{
    public class Enterprise : Base
    {
        [MaxLength(12), MinLength(12)]
        public string XIN { get; set; }

        public EnterpriseType EnterpriseType {get;set;}
        
    }

    public enum EnterpriseType
    {
        [Description("Хозяйство")]
        Farm = 1,
        [Description("Палата")]
        Chamber = 2,
        [Description("Племенной центр")]
        BreedingCenter = 3,
        [Description("Администратор")]
        Administ = 4,
        [Description("Классификатор")]
        Boniter = 5,
        [Description("Лаборатория")]
        Laboratory = 6,
        [Description("Акимат")]
        Akimat = 7
    }
}