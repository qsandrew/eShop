using System.ComponentModel;
using eShop.Models.Common;
using eShop.Models.EntInfo;

namespace eShop.Models.CowInfo
{

    public enum FarmType
    {
        [Description("Племенные")]
        Plem = 1,
        [Description("Товарные")]
        Product = 2,
    }
    //Ферма коров
    public class Farm : Base
    {
        public FarmType FarmType { get; set; }

        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }

    }
    //отара овец
    public class Flock : Base
    {
        public FarmType FarmType { get; set; }
        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
    }
    //Табун лошадей
    public class Tabun : Base
    {
        public FarmType FarmType { get; set; }
        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
    }
    //Стадо свиней
    public class Herd:Base{
        public FarmType FarmType { get; set; }
        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
    }

    //Караван верблюдов
    public class Caravan:Base{
        public FarmType FarmType { get; set; }
        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
    }


}