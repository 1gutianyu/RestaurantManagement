using IRestaurantManageBLL;
using IRestaurantManageDAL;
using Microsoft.EntityFrameworkCore;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageBLL
{
    public class StaffInfoBll : BaseDeleteBll<StaffInfo>, IStaffInfoBll
    {
        private IStaffInfoDal  _staffInfoDal;
        private IDepartmentInfoDal _departmentInfoDal ;

        public StaffInfoBll(IStaffInfoDal staffInfoDal, IDepartmentInfoDal departmentInfoDal) : base(staffInfoDal)
        {
            _staffInfoDal = staffInfoDal;
            _departmentInfoDal = departmentInfoDal;
        }


        /// <summary>
        /// 获取员工下拉列表数据
        /// </summary>
        /// <returns></returns>
        public object GetStaffSelectOptions()
        {
            var datas = _staffInfoDal.GetEntityListDb().Where(s => !s.IsDelete).Select(s => new
            {
                s.ID,
                s.StaffName
            }).ToList();

            return datas;
        }


        /// <summary>
        /// 获取员工数据列表（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public object GetStaffInfoListByPage(int page, int limit, out int count, string name, string phone)
        {
            //获取数据库中用户全部没删除的数据（未真实查询）
            var staffInfos = _staffInfoDal.GetEntityListDb().Where(u => u.IsDelete == false);

            if (!string.IsNullOrEmpty(name))
            {
                staffInfos = staffInfos.Where(u => u.StaffName.Contains(name));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                staffInfos = staffInfos.Where(u => u.Phone.Contains(phone));
            }

            //查询出来数据的数量
            count = staffInfos.Count();

            DbSet<DepartmentInfo> departmentInfos = _departmentInfoDal.GetEntityListDb();

            var temp = from u in staffInfos
                       join d in departmentInfos
                       on u.DepartmentID equals d.ID into udTemp
                       from ud in udTemp.DefaultIfEmpty()
                       select new
                       {
                           u.StaffName,
                           u.ID,
                           u.JobID,
                           u.Phone,
                           u.Health,
                           u.Address,
                           u.CreateTime,
                           u.Sex,
                           ud.DepartmentName
                       };

            //分页
            temp = temp.OrderBy(u => u.CreateTime).Skip((page - 1) * limit).Take(limit);

            var list = temp.ToList().Select(u =>
            {
                string sexStr;
                if (u.Sex == 1)
                {
                    sexStr = "男";
                }
                else
                {
                    sexStr = "女";
                }

                string healthStr;
                if (u.Health == 1)
                {
                    healthStr = "健康";
                }
                else
                {
                    healthStr = "不健康";
                }

                return new
                {
                    u.StaffName,
                    u.ID,
                    u.JobID,
                    u.Phone,
                    u.Address,
                    CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sex = sexStr,
                    Health= healthStr,
                    u.DepartmentName
                };
            });

            return list;
        }



        public void DeleteDatas(string Ids)
        {
            throw new NotImplementedException();
        }

  
        public void SoftDeleteDatas(List<StaffInfo> Ids)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="staffInfoId"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool UpdateStaffInfo(string staffInfoId, string name, int sex, string phone, string address)
        {
            StaffInfo staffInfo = _staffInfoDal.GetSingleEntityData(staffInfoId);
            if (staffInfo != null)
            {
                staffInfo.StaffName = name;
                staffInfo.Sex = sex;
                staffInfo.Phone = phone;
                staffInfo.Address = address;
                return _staffInfoDal.UpdateSingleData(staffInfo);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断员工工号是否重复
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public bool IsHadStaffInfo(string jobId)
        {
            int count = _staffInfoDal.GetEntityListDb().Where(u => u.JobID == jobId && u.IsDelete == false).Count();
            return count > 0;
        }
    }
}
