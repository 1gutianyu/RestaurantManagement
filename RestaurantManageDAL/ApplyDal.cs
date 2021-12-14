using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageDAL
{
   public class ApplyDal : BaseDal<ApplyInfo>, IApplyDal
    {
        //数据库上下文
        ManegeDbContext _DbContext;

        public ApplyDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
