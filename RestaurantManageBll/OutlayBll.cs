using IRestaurantManageBLL;
using IRestaurantManageDAL;
using RestaurantManageBll;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageBll
{
   public class OutlayBll : BaseBll<OutlayInfo>, IOutlayBll 
    {
        private IOutlayDal  _outlayInfoDal;

        public OutlayBll(IOutlayDal outlayInfoDal) : base(outlayInfoDal)
        {
            _outlayInfoDal = outlayInfoDal;
        }

        public object GetOutlayInfoListByPage(int page, int limit, out int count)
        {
            //获取当前表数据
            var outlay = _outlayInfoDal.GetEntityListDb().AsQueryable();

            //当前数据条数
            count = outlay.Count();

            //分页
            outlay = outlay.Skip((page - 1) * limit).Take(limit);

            //返回前端数据
            var list = outlay.ToList().Select(u =>
            {
              string  Status = u.Status.ToString();
                return new
                {
                    u.ID,
                    u.CheckPerson,
                    u.Reason,
                    Status
                };
            });

            return list;
        }

        public bool UpdateOutlayInfo(string iD, string reason, OutlayReviewStatusEnum status)
        {
            OutlayInfo outlayInfo = _outlayInfoDal.GetSingleEntityData(iD);
            if (outlayInfo != null)
            {
                outlayInfo.Reason = reason;
                outlayInfo.Status = status;
                return _outlayInfoDal.UpdateSingleData(outlayInfo);
            }
            else
            {
                return false;
            }
        }
    }
}
