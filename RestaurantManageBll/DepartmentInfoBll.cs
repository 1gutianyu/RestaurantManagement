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
    public class DepartmentInfoBll : BaseDeleteBll<DepartmentInfo>, IDepartmentInfoBll
    {
        private IDepartmentInfoDal _departmentInfoDal;
        public DepartmentInfoBll(IDepartmentInfoDal departmentInfoDal) : base(departmentInfoDal)
        {
            _departmentInfoDal = departmentInfoDal;
        }

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
            var userInfos = "";


            //查询部门所有未删除的信息
            var allDepartmentInfos = _departmentInfoDal.GetEntityListDb().Where(u => !u.IsDelete);

            //连表  未完成
            var tempList = "";
            

            //分页  未完成
            //var res=tempList.OrderBy()
        }
    }
}
