using System.ComponentModel;
using eShop.Models.Common;

namespace eShop.Models.EntInfo.Reference
{
    public class Position : Base
    {

    }

    public enum StatusWork
    {
        [Description("Работает")]
        Work = 1,
        [Description("Отпуск")]
        Holiday = 2,
        [Description("Болеет")]
        Ill = 3,
        [Description("Уволен")]
        Fired = 4
    }
}