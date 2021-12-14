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
    public class RoleInfoBll : BaseDeleteBll<RoleInfo>, IRoleInfoBll
    {
        private IRoleInfoDal _roleInfoDal;
        private IStasff_RoleInfoDal _stasff_RoleInfoDal ;
        private IMenu_RoleInfoDal _menu_RoleInfoDal  ;

        public RoleInfoBll(IRoleInfoDal roleInfoDal, IStasff_RoleInfoDal stasff_RoleInfoDal, IMenu_RoleInfoDal menu_RoleInfoDal) : base(roleInfoDal)
        {
            _roleInfoDal = roleInfoDal;
            _stasff_RoleInfoDal = stasff_RoleInfoDal;
            _menu_RoleInfoDal = menu_RoleInfoDal;
        }

        public void DeleteDatas(string Ids)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取当前角色已绑定的员工id集合
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <returns></returns>
        public List<string> GetBindStaffInfoIds(string roleInfoId)
        {
            //查询当前角色已经绑定的员工ID
            return _stasff_RoleInfoDal.GetEntityListDb().Where(r => r.RoleId == roleInfoId).Select(r => r.StaffId).ToList();
        }



        /// <summary>
        /// 绑定员工
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <param name="userInfoIds"></param>
        public void BindStaffInfo(string roleInfoId, List<string> staffInfoIds)
        {
            DateTime datetime = DateTime.Now;


            //当前角色已绑定的员工信息
            var staffInfo_RoleInfos = _stasff_RoleInfoDal.GetEntityListDb().Where(r => r.RoleId == roleInfoId).ToList();

            //先删除已绑定的
            foreach (var item in staffInfo_RoleInfos)
            {
                if (!staffInfoIds.Contains(item.StaffId))
                {
                    _stasff_RoleInfoDal.DeleteSingleData(item.ID);
                }
            }

            //添加
            foreach (var item in staffInfoIds)
            {
                //如果员工存在就不添加，不存在就添加
                if (!staffInfo_RoleInfos.Any(a => a.StaffId == item))
                {
                    Stasff_RoleInfo stasff_RoleInfo = new  Stasff_RoleInfo()
                    {
                        ID = Guid.NewGuid().ToString(),
                        RoleId = roleInfoId,
                        StaffId = item,
                        CreateTime = datetime
                    };
                    _stasff_RoleInfoDal.AddSingleData(stasff_RoleInfo);
                }
            }

        }





        /// <summary>
        /// 绑定权限
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <param name="menuInfoIds"></param>
        public void BindMenuInfoId(string roleInfoId, List<string> menuInfoIds)
        {
            DateTime datetime = DateTime.Now;

            //当前角色已绑定的菜单信息
            var roleInfo_MenuInfos = _menu_RoleInfoDal.GetEntityListDb().Where(r => r.RoleId == roleInfoId).ToList();

            //删除
            foreach (var item in roleInfo_MenuInfos)
            {
                if (!menuInfoIds.Contains(item.MenuId))
                {
                    _menu_RoleInfoDal.DeleteSingleData(item.ID);
                }
            }

            //添加
            foreach (var item in menuInfoIds)
            {
                if (!roleInfo_MenuInfos.Any(a => a.MenuId == item))
                {
                    Menu_RoleInfo menu_RoleInfo = new  Menu_RoleInfo()
                    {
                        ID = Guid.NewGuid().ToString(),
                        RoleId = roleInfoId,
                        MenuId = item,
                        CreateTime = datetime
                    };
                    _menu_RoleInfoDal.AddSingleData(menu_RoleInfo);
                }
            }

        }




        /// <summary>
        /// 获取当前角色已绑定的菜单id集合
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <returns></returns>
        public List<string> GetBindMenuInfoIds(string roleInfoId)
        {
            return _menu_RoleInfoDal.GetEntityListDb().Where(r => r.RoleId == roleInfoId).Select(r => r.MenuId).ToList();
        }



        /// <summary>
        /// 根据Id获取角色
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <returns></returns>
        public RoleInfo GetRoleInfo(string roleInfoId)
        {
            return _roleInfoDal.GetSingleEntityData(roleInfoId);
        }

        /// <summary>
        /// 获取角色集合
        /// </summary>
        /// <returns></returns>
        public List<RoleInfo> GetRoleInfoList()
        {
            return _roleInfoDal.GetEntityListDb().Where(u => u.IsDelete == false).ToList();
        }

        /// <summary>
        /// 获取角色集合（分页）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="roleName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public object GetRoleInfoListByPage(int page, int limit, out int count, string name)
        {
            var roleInfos = _roleInfoDal.GetEntityListDb().Where(u => u.IsDelete == false);

            //搜索
            if (!string.IsNullOrEmpty(name))
            {
                roleInfos = roleInfos.Where(u => u.RoleName.Contains(name));
            }
            
            count = roleInfos.Count();

            roleInfos = roleInfos.Skip((page - 1) * limit).Take(limit);

            List<object> list = new List<object>();

            foreach (var item in roleInfos)
            {

                list.Add(new
                {
                    item.RoleName,
                    item.ID,
                    item.Description,
                    CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),

                });
            }

            return list;
        }

        /// <summary>
        /// 是否重复
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool IsHadRoleInfo(string roleName)
        {
            int count = _roleInfoDal.GetEntityListDb().Where(u => u.RoleName == roleName && u.IsDelete == false).Count();
            return count > 0;
        }



        public void SoftDeleteDatas(List<RoleInfo> Ids)
        {
            throw new NotImplementedException();
        }



       



        /// <summary>
        /// 更新角色的角色名
        /// </summary>
        /// <param name="roleInfoId"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(string roleInfoId, string name,string description)
        {
            RoleInfo roleInfo = _roleInfoDal.GetSingleEntityData(roleInfoId);
            if (roleInfo != null)
            {
                roleInfo.RoleName = name;
                roleInfo.Description = description;
                return _roleInfoDal.UpdateSingleData(roleInfo);
            }
            else
            {
                return false;
            }
        }
    }
}
