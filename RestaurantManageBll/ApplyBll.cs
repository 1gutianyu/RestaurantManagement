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
    public class ApplyBll : BaseBll<ApplyInfo>, IApplyBll
    {
        private IApplyDal _iApplyInfoDal;

        public ApplyBll(IApplyDal iApplyInfoDal) : base(iApplyInfoDal)
        {
            _iApplyInfoDal = iApplyInfoDal;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object GetapplyInfoListByPage(int page, int limit, out int count)
        {
            //获取当前表数据
            var iapply = _iApplyInfoDal.GetEntityListDb().AsQueryable();

            //当前数据条数
            count = iapply.Count();

            //分页
            iapply = iapply.Skip((page - 1) * limit).Take(limit);

            //返回前端数据
            var list = iapply.ToList().Select(u =>
            {
                return new
                {
                    u.ID,
                    u.ApplyMoney,
                    u.JobPerson,
                    u.Reason,
                    CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                };
            });

            return list;
        }

        public bool UpdateapplyInfo(string iD, double putMoney, string reason)
        {
            ApplyInfo applyIn = _iApplyInfoDal.GetSingleEntityData(iD);
            if (applyIn != null)
            {
                applyIn.ApplyMoney = putMoney;
                applyIn.Reason = reason;
                return _iApplyInfoDal.UpdateSingleData(applyIn);
            }
            else
            {
                return false;
            }
        }
    }
}
