using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageDAL
{
    public class InventoryInfoDal : BaseDal<InventoryInfo>, IInventoryInfoDal
    {
        ManegeDbContext _DbContext;

        public InventoryInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
