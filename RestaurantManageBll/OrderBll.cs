using IRestaurantManageBLL;
using IRestaurantManageDAL;
using RestaurantManageBll;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
   public class OrderBll:BaseBll<OrderInfo>, IOrderBll
    {
        private IOrderDal _orderDal;

        private IMealDal _mealDal;

        public OrderBll(IOrderDal orderDal, IMealDal mealDal) :base(orderDal)
        {
            _orderDal = orderDal;
            _mealDal = mealDal;
        }

        public object GetOrderInfoListByPage(string jobId, string tableNumber, int page, int limit, out int count)
        {
            //获取当前表数据
            var Order = _orderDal.GetEntityListDb().AsQueryable();

            //当前数据条数
            count = Order.Count();

            //搜索功能
            if (!string.IsNullOrEmpty(jobId)||!string.IsNullOrEmpty(tableNumber))
            {
                Order = Order.Where(u => u.JobId == jobId);
            }

            //后期这里需要修改获取当前登录员工以及菜品名优化
            var temp = from or in Order
                       join m in _mealDal.GetEntityListDb()
                       on or.TableNumber equals m.ID

                       select new
                       {
                           or.ID,
                           or.TotalMoney,
                           or.PayMethod,
                           or.CreateTime,
                           or.JobId,
                           m.TableName
                       };


            //分页
            temp = temp.OrderBy(u => u.CreateTime).Skip((page - 1) * limit).Take(limit);

            //返回前端数据
            var list = temp.ToList().Select(u =>
            {
                string Method = u.TotalMoney.ToString();
                return new
                {
                    u.ID,
                    //当前这里没有返回菜名，这里前端要显示菜名
                    u.TotalMoney,
                    Method,
                    CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    u.JobId,
                    u.TableName
                };
            });

            return list;
        }

        public object GetStatusSelectOption3()
        {
            List<object> options = new List<object>();

            //获取枚举中所有的名字
            var names = Enum.GetNames(typeof(OrderPayMethodEnum));

            foreach (var namesItem in names)
            {
                var value = (int)Enum.Parse(typeof(OrderPayMethodEnum), namesItem);
                options.Add(new
                {
                    Key = namesItem,
                    Value = value
                });
            }

            return options;
        }




        public bool UpdateOrderInfo(string iD, string dishesId, double money, OrderPayMethodEnum method, string tableNumber)
        {
            OrderInfo orderInfo = _orderDal.GetSingleEntityData(iD);
            if (orderInfo!=null)
            {
                orderInfo.DishesId = dishesId;
                orderInfo.TotalMoney = money;
                orderInfo.PayMethod = method;
                orderInfo.TableNumber = tableNumber;
               return _orderDal.UpdateSingleData(orderInfo);
            }
            else
            {
                return false;
            }
        }
    }
}
