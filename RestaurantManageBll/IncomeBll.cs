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
   public class IncomeBll : BaseBll<IncomeInfo>, IIncomeBll 
    {
        private IIncomeDal  _incomeInfoDal;

        public IncomeBll(IIncomeDal incomeInfoDal) : base(incomeInfoDal)
        {
            _incomeInfoDal = incomeInfoDal;
        }

        public object GetIncomeInfoListByPage(int page, int limit, out int count)
        {
            //获取当前表数据
            var Payway = _incomeInfoDal.GetEntityListDb().AsQueryable();

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
                    u.OrderId,
                    u.PutMoney,
                    u.JobId,
                    CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                };
            });

            return list;
        }

        public bool UpdateIncomeInfo(string iD, double putMoney)
        {
            IncomeInfo incomeInfo = _incomeInfoDal.GetSingleEntityData(iD);
            if (incomeInfo != null)
            {
                incomeInfo.PutMoney = putMoney;
                return _incomeInfoDal.UpdateSingleData(incomeInfo);
            }
            else
            {
                return false;
            }
        }


    }
}
