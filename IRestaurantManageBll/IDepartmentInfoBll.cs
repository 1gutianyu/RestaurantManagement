using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurantManageBLL
{
    public interface IDepartmentInfoBll:IBaseDeleteBll<DepartmentInfo>
    {
        /// <summary>
        /// 分页，连表，模糊查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="departmentName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public object GetDepartmentInfoListPage(int page, int limit, out int count, string departmentName, string description);

        /// <summary>
        /// 获取部门下拉数据
        /// </summary>
        /// <returns></returns>
        object GetDeparmentSelectOptions();
    }
}
