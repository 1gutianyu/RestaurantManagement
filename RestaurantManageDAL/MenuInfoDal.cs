using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageDAL
{
    public class MenuInfoDal : BaseDal<MenuInfo>, IMenuInfoDal
    {
        ManegeDbContext _DbContext;
        public MenuInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
