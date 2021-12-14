using IRestaurantManageBLL;
using IRestaurantManageDAL;
using RepositoryEntity.DTO;
using RestaurantManageEntity;
using RestaurantManagement.ResultModel.MenuInfoResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageBLL
{
    /// <summary>
    /// 菜单业务逻辑层
    /// </summary>
    public class MenuInfoBll : BaseDeleteBll<MenuInfo>, IMenuInfoBll
    {
        private IMenuInfoDal _menuInfoDal;
        private IDepartmentInfoDal _departmentInfoDal;


        public MenuInfoBll(IMenuInfoDal menuInfoDal, IDepartmentInfoDal departmentInfoDal) : base(menuInfoDal)
        {
            _menuInfoDal = menuInfoDal;
            _departmentInfoDal = departmentInfoDal;
        }

        /// <summary>
        /// 判断是否存在同名菜单
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsHadMenuInfo(string title)
        {
            int count = _menuInfoDal.GetEntityListDb().Where(m => m.Title == title && !m.IsDelete).Count();
            return count > 0;
        }


        /// <summary>
        /// 递归赋值菜单集合
        /// </summary>
        /// <param name="pMenus"></param>
        /// <param name="menus"></param>
        public void RecursionMenu(List<MenuInfoResultModel> pMenus, List<MenuInfoDTO> menus)
        {
            foreach (var item in pMenus)
            {
                var childMenus2 = menus.Where(m => m.ParentId == item.ID).Select(m => new MenuInfoResultModel
                {
                    ID = m.ID,
                    href = m.Href,
                    icon = m.Icon,
                    target = m.Target,
                    title = m.Title
                }).ToList();
                //为父级菜单添加子集菜单
                item.child = childMenus2;

                RecursionMenu(item.child, menus);
            }
        }

        /// <summary>
        /// /获取菜单集合信息
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoResultModel> GetInitMenus(UserInfo userInfo)
        {
            //先判断用户信息里有没有isAdmin等于true，并且他有“系统管理员”角色才给他看到所有的菜单
            int count = 0;
            //int count = (from ur in _r_UserInfo_RoleInfoDal.GetEntitiesDb().Where(r => r.UserID == userInfo.ID)
            //             join r in _roleInfoDal.GetEntitiesDb().Where(r => !r.IsDelete && r.RoleName == "系统管理员")
            //             on ur.RoleID equals r.ID
            //             select ur.ID).Count();

            //三目表达式
            bool isHas = count > 0 ? true : false;

            List<MenuInfoDTO> menus = new List<MenuInfoDTO>();

            //超级管理员
            //if (userInfo.IsAdmin == true && isHas == true)
            //{
            //    //获取所有菜单集合信息
            menus = _menuInfoDal.GetEntityListDb().Where(m => !m.IsDelete).OrderBy(m => m.Sort).Select(m => new MenuInfoDTO
            {
                ID = m.ID,
                Title = m.Title,
                Icon = m.Icon,
                Href = m.Href,
                Target = m.Target,
                Level = m.Level,
                ParentId = m.ParentId
            }).ToList();
       // }
            //else //普通用户
            //{
            //    //根据用户id获取用户的角色
            //    var roleInfoIds = _r_UserInfo_RoleInfoDal.GetEntitiesDb().Where(u => u.UserID == userInfo.ID).Select(u => u.RoleID).ToList();

            //获取菜单的id集合
                var menuIds = _departmentInfoDal.GetEntityListDb().Where(r => r.ID.Contains(r.ID)).Select(r => r.ID).ToList();

            //    //去重后的菜单id
                var dMenuIds = menuIds.Distinct().ToList();

            //    menus = (from m in _menuInfoDal.GetEntitiesDb().Where(m => menuIds.Contains(m.ID)).ToList()
            //             join menuId in dMenuIds
            //             on m.ID equals menuId
            //             select new
            //             {
            //                 ID = m.ID,
            //                 m.Sort,
            //                 Title = m.Title,
            //                 Icon = m.Icon,
            //                 Href = m.Href,
            //                 Target = m.Target,
            //                 Level = m.Level,
            //                 ParentId = m.ParentId
            //             }).OrderBy(m => m.Sort).Select(m => new MenuInfoDTO
            //             {
            //                 ID = m.ID,
            //                 Title = m.Title,
            //                 Icon = m.Icon,
            //                 Href = m.Href,
            //                 Target = m.Target,
            //                 Level = m.Level,
            //                 ParentId = m.ParentId
            //             }).ToList();


            //根据角色来获取菜单
            menus = _menuInfoDal.GetEntityListDb().Where(m => menuIds.Contains(m.ID)).Select(m => new
            {
                ID = m.ID,
                m.Sort,
                Title = m.Title,
                Icon = m.Icon,
                Href = m.Href,
                Target = m.Target,
                Level = m.Level,
                ParentId = m.ParentId
            }).OrderBy(m => m.Sort).Select(m => new MenuInfoDTO
            {
                ID = m.ID,
                Title = m.Title,
                Icon = m.Icon,
                Href = m.Href,
                Target = m.Target,
                Level = m.Level,
                ParentId = m.ParentId
            }).ToList();

            menus = (from rm in _departmentInfoDal.GetEntityListDb().Where(d => d.ID.Contains(d.ID))
                     join m in _menuInfoDal.GetEntityListDb().Where(m => !m.IsDelete)
                     on rm.ID equals m.ID
                     select new
                     {
                         ID = m.ID,
                         m.Sort,
                         Title = m.Title,
                         Icon = m.Icon,
                         Href = m.Href,
                         Target = m.Target,
                         Level = m.Level,
                         ParentId = m.ParentId
                     }).OrderBy(m => m.Sort).Select(m => new MenuInfoDTO
                     {
                         ID = m.ID,
                         Title = m.Title,
                         Icon = m.Icon,
                         Href = m.Href,
                         Target = m.Target,
                         Level = m.Level,
                         ParentId = m.ParentId
                     }).ToList();

            //}

            //获取父级菜单集合信息
            List<MenuInfoResultModel> parentMenus = menus.Where(m => m.Level == 0 && m.ParentId == null).Select(m => new MenuInfoResultModel
            {
                ID = m.ID,
                href = m.Href,
                icon = m.Icon,
                target = m.Target,
                title = m.Title
            }).ToList();

            foreach (var parentMenu in parentMenus)
            {
                //查询父级菜单自己的自己菜单
                var childMenus = menus.Where(m => m.ParentId == parentMenu.ID).Select(m => new MenuInfoResultModel
                {
                    ID = m.ID,
                    href = m.Href,
                    icon = m.Icon,
                    target = m.Target,
                    title = m.Title
                }).ToList();
                //为父级菜单添加子集菜单
                parentMenu.child = childMenus;
                //递归赋值子菜单
                RecursionMenu(parentMenu.child, menus);
            }

            return parentMenus;

            //return new List<MenuInfoResultModel>();
        }

        /// <summary>
        /// 获取菜单数据列表，分页，模糊查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public object GetMenuListPage(int page, int limit, out int count, string title)
        {
            //获取数据库中用户全部没删除的数据（未真实查询）
            var menuInfos = _menuInfoDal.GetEntityListDb().Where(u => u.IsDelete == false);

            //搜索
            if (!string.IsNullOrEmpty(title))
            {
                menuInfos = menuInfos.Where(u => u.Title.Contains(title));
            }

            //查询出来数据的数量
            count = menuInfos.Count();

            ////获取用户数据集
            //var userInfos = _userInfoDal.GetEntitiesDb();

            ////查询部门所有未删除的信息
            //var allDepartmentInfos = _menuInfoDal.GetEntitiesDb().Where(u => u.IsDelete == false);

            //var tempList = from d in menuInfos
            //               join u in userInfos
            //               on d.LeaderID equals u.ID into duTemp
            //               from du in duTemp.DefaultIfEmpty()

            //               join pd in allDepartmentInfos
            //               on d.ParentID equals pd.ID into dpdTemp
            //               from dpd in dpdTemp.DefaultIfEmpty()
            //               select new
            //               {
            //                   d.ID,
            //                   d.DepartmentName,
            //                   d.Description,
            //                   d.CreateTime,
            //                   du.UserName,
            //                   ParentDeparmentName = dpd.DepartmentName
            //               };


            //分页
            var res = (from m in menuInfos
                       join m2 in _menuInfoDal.GetEntityListDb()
                       on m.ParentId equals m2.ID into mmTemp
                       from m3 in mmTemp.DefaultIfEmpty()
                       select new
                       {
                           m.ID,
                           m.Title,
                           m.Description,
                           m.Level,
                           m.Sort,
                           m.Href,
                           m.Icon,
                           m.Target,
                           m.CreateTime,
                           ParentTitle = m3.Title
                       }).OrderBy(d => d.Sort).Skip((page - 1) * limit).Take(limit).ToList().Select(u =>
                       {
                           return new
                           {
                               u.ID,
                               u.Title,
                               u.Description,
                               u.Level,
                               u.Sort,
                               u.Href,
                               u.Icon,
                               u.Target,
                               CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                               u.ParentTitle
                           };
                       });

            return res;
        }



        /// <summary>
        /// 获取菜单信息下拉列表数据
        /// </summary>
        /// <returns></returns>
        public object GetMenuSelectOptions()
        {
            var datas = _menuInfoDal.GetEntityListDb().Where(m => !m.IsDelete).Select(m => new
            {
                m.ID,
                m.Title
            }).ToList();
            return datas;
        }


    }
}
