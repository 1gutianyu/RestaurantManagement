using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageDAL
{
    public class DepartmentInfoDal : BaseDal<DepartmentInfo>, IDepartmentInfoDal
    {
        ManegeDbContext _DbContext;
        public DepartmentInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
