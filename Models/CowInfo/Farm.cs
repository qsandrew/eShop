using System.ComponentModel;
using eShop.Models.Common;
using eShop.Models.EntInfo;

namespace eShop.Models.CowInfo
{
    public class Farm : Base
    {
        public FarmType FarmType { get; set; }

        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }

    }

    public enum FarmType
    {
        [Description("Молочная")]
        Milk = 1,
        [Description("Мясная")]
        Meat = 2
    }
}