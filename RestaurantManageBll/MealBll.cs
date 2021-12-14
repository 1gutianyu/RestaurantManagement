using IRestaurantManageBLL;
using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageBll
{
    public class MealBll:BaseBll<MealInfo>, IMealBll
    {
        private IMealDal _mealDal;

        public MealBll(IMealDal mealDal):base(mealDal)
        {
            _mealDal = mealDal;
        }

        public object GetMealInfoListByPage(int page, int limit, out int count)
        {
            //获取当前表数据
            var Payway = _mealDal.GetEntityListDb().AsQueryable();

            //当前数据条数
            count = Payway.Count();

            //分页
            Payway = Payway.Skip((page - 1) * limit).Take(limit);

            //返回前端数据
            var list = Payway.ToList().Select(u =>
            {
                return new
                {
                    u.ID,
                    u.TableName,

                };
            });

            return list;
        }

        /// <summary>
        /// 获取餐桌表下拉数据
        /// </summary>
        /// <returns></returns>
        public object GetStatusSelectOption()
        {
           return  _mealDal.GetEntityListDb().Select(u => new
            {
                u.ID,
                u.TableName
            }).ToList();
        }

        public bool UpdateOrderInfo(string iD, string tableId)
        {
            MealInfo mealInfo = _mealDal.GetSingleEntityData(iD);
            if (mealInfo != null)
            {
                mealInfo.TableName = tableId;
                return _mealDal.UpdateSingleData(mealInfo);
            }
            else
            {
                return false;
            }
        }

    }
}
