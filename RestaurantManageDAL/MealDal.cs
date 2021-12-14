using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageDAL
{
    public class MealDal:BaseDal<MealInfo>, IMealDal
    {
        //数据库上下文
        ManegeDbContext _DbContext;

        public MealDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
