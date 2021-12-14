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
    public class UserInfoBll : BaseDeleteBll<UserInfo>, IUserInfoBll
    {
        private IUserInfoDal _userInfoDal;

        public UserInfoBll(IUserInfoDal userInfoDal): base(userInfoDal)
        {
            _userInfoDal = userInfoDal;
        }
        public void DeleteDatas(string Ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取客户下拉列表数据
        /// </summary>
        /// <returns></returns>
        public object GetUserSelectOptions()
        {
            var datas = _userInfoDal.GetEntityListDb().Where(u => !u.IsDelete).Select(u => new
            {
                u.ID,
                u.UserName
            }).ToList();
            return datas;
        }

        /// <summary>
        /// 根据账号密码获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByLogin(string account, string password)
        {
            return _userInfoDal.GetEntityListDb().Where(u => u.Account == account && u.PassWord == password && !u.IsDelete).FirstOrDefault();
        }


        public object GetUserInfoListByPage(int page, int limit, out int count, string userName, string phoneNum)
        {
            //获取数据库中用户全部没删除的数据（未真实查询）
            var userInfos = _userInfoDal.GetEntityListDb().Where(u => u.IsDelete == false);

            if (!string.IsNullOrEmpty(userName))
            {
                userInfos = userInfos.Where(u => u.UserName.Contains(userName));
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                userInfos = userInfos.Where(u => u.PhoneNum.Contains(phoneNum));
            }

            //查询出来数据的数量
            count = userInfos.Count();

            //分页
            userInfos = userInfos.Skip((page - 1) * limit).Take(limit);

            var list = userInfos.ToList().Select(u =>
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

                return new
                {
                    u.UserName,
                    u.ID,
                    u.Account,
                    u.PhoneNum,
                    u.Email,
                    CreateTime = u.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Sex = sexStr
                };
            });

            return list;
        }

        public void SoftDeleteDatas(List<UserInfo> Ids)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserInfo(string userInfoId, string userName, int sex, string phoneNum)
        {
            UserInfo userInfo = _userInfoDal.GetSingleEntityData(userInfoId);
            if (userInfo != null)
            {
                userInfo.UserName = userName;
                userInfo.Sex = sex;
                userInfo.PhoneNum = phoneNum;
                return _userInfoDal.UpdateSingleData(userInfo);
            }
            else
            {
                return false;
            }
        }
    }
}
