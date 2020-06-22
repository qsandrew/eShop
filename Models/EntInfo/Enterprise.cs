using System.ComponentModel.DataAnnotations;
using eShop.Models.Common;

namespace eShop.Models.EntInfo
{
    public class Enterprise: Base
    {
        [MaxLength(12), MinLength(12)]
        public string BIN { get; set; }
    }
}