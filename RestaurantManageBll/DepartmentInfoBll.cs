using IRestaurantManageBLL;
using IRestaurantManageDAL;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageBLL
{
    /// <summary>
    /// 部门业务访问层
    /// </summary>
    public class DepartmentInfoBll : BaseDeleteBll<DepartmentInfo>, IDepartmentInfoBll
    {
        private IDepartmentInfoDal _departmentInfoDal;
        private IUserInfoDal _userInfoDal;

        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal, IUserInfoDal userInfoDal) : base(departmentInfoDal)
        {
            _departmentInfoDal = departmentInfoDal;
            _userInfoDal = userInfoDal;
        }


        /// <summary>
        /// 获取部门下拉数据
        /// </summary>
        /// <returns></returns>
        public object GetDeparmentSelectOptions()
        {
            var datas = _departmentInfoDal.GetEntityListDb().Where(d => !d.IsDelete).Select(s => new
            {
                s.ID,
                s.DepartmentName
            }).ToList();
            return datas;
        }

        /// <summary>
        /// 分页，连表，模糊查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="departmentName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public object GetDepartmentInfoListPage(int page, int limit, out int count, string departmentName, string description)
        {
            //查询部门未删除数据(不放入缓存中)
            var departmentInfos = _departmentInfoDal.GetEntityListDb().Where(d => !d.IsDelete);
            //根据部门名称、部门描述模糊查询
            if (!string.IsNullOrEmpty(departmentName) || !string.IsNullOrEmpty(description))
            {
                departmentInfos = departmentInfos.Where(d => d.DepartmentName.Contains(departmentName) || d.Description.Contains(description));
            }

            //数据数量
            count = departmentInfos.Count();

            //获取用户数据集  未完成
            var userInfos = _userInfoDal.GetEntityListDb();


            //查询部门所有未删除的信息
            var allDepartmentInfos = _departmentInfoDal.GetEntityListDb().Where(u => !u.IsDelete);

            //连表  未完成
            var tempList = from d in departmentInfos
                           join u in userInfos
                           on d.LeaderID equals u.ID into duTemp
                           from du in duTemp.DefaultIfEmpty()

                           join pd in allDepartmentInfos
                           on d.ParentID equals pd.ID into dpdTemp
                           from dpd in dpdTemp.DefaultIfEmpty()
                           select new
                           {
                               d.ID,
                               DepartmentName = d.DepartmentName,
                               d.Description,
                               d.CreateTime,
                               UserName = du.UserName,
                               ParentDeparmentName = dpd.DepartmentName
                           };


            //分页  未完成
            var res = tempList.OrderBy(d => d.CreateTime).Skip((page - 1) * limit).Take(limit).ToList().Select(u =>
                  {
                      return new
                      {
                          u.ID,
                          u.DepartmentName,
                          u.Description,
                          CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                          u.UserName,
                          u.ParentDeparmentName
                      };
                  });

            return res;

        }


    }
}
