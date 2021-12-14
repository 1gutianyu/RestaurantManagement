using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageDAL
{
   public class OrderDal:BaseDal<OrderInfo>, IOrderDal
    {
        //数据库上下文
        ManegeDbContext _DbContext;

        public OrderDal(ManegeDbContext DbContext):base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
