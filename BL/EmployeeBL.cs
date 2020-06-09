using System.Collections.Generic;
using System.Linq;
using eShop.Models;
using eShop.Models.Enterprise;
using eShop.Models.Enterprise.Reference;

namespace eShop.BL
{
    public class EmployeeBL
    {
        public static IEnumerable<Position> GetPositions(IasContext _db){
            var lstPosition = _db.Positions.OrderBy(p=>p.Name);
            return lstPosition;
        }
    }
}