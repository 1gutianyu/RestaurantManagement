using IRestaurantManageBLL;
using Microsoft.AspNetCore.Mvc;
using RestaurantManageEntity;
using RestaurantManagement.Models;
using RestaurantManagement.Models.UserInfoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class UserInfoController : Controller
    {
        public IUserInfoBll _userInfoBll;
        public UserInfoController(IUserInfoBll userInfoBll)
        {
            _userInfoBll = userInfoBll;
        }

        CustomActionResult res = new CustomActionResult();

        /// <summary>
        /// 添加用户视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUserInfoView()
        {
            return View();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserInfo(AddUserInfoViewModel model)
        {
            if (string.IsNullOrEmpty(model.Account))
            {
                res.Msg = "账号不能为空";
                return Json(res);
            }
            else if (string.IsNullOrEmpty(model.PassWord))
            {
                res.Msg = "密码不能为空";
                return Json(res);
            }
            else if (string.IsNullOrEmpty(model.UserName))
            {
                res.Msg = "用户名不能为空";
                return Json(res);
            }

            UserInfo entity = new UserInfo()
            {
                ID = Guid.NewGuid().ToString(),
                Account = model.Account,
                UserName = model.UserName,
                PhoneNum = model.PhoneNum,
                Email = model.Email,
                Sex = model.Sex,
                PassWord = model.PassWord,
                CreateTime = DateTime.Now,
                IsDelete = false
            };

            bool isSuccess = _userInfoBll.AddSingleData(entity);
            if (isSuccess)
            {
                res.IsSuccess = true;
                res.Msg = "添加成功";
                res.Status = 1;
                return Json(res);
            }
            else
            {
                return Json(res);
            }
         
        }

        /// <summary>
        /// 修改用户视图
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateUserInfoView()
        {
            return View();
        }


        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUpdateUserInfo(string userInfoId)
        {
            //获取用户信息
            UserInfo userInfo = _userInfoBll.GetSingleEntityData(userInfoId);
            res.IsSuccess = true;
            res.Status = 1;
            res.Msg = "成功";
            res.Datas = userInfo;
            return Json(res);
        }


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateUserInfo(UpdateUserInfoViewModel model)
        {
          
            if (_userInfoBll.UpdateUserInfo(model.ID, model.UserName, model.Sex, model.PhoneNum))
            {
                res.IsSuccess = true;
                res.Msg = "成功";
                res.Status = 1;
                return Json(res);
            }
            else
            {
                return Json(res);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteUserInfo(string userInfoId)
        {
           
            if (_userInfoBll.SoftDeleteSingleData(userInfoId))
            {
                res.Status = 1;
                res.Msg = "成功";
                res.IsSuccess = true;
                return Json(res);
            }
            else
            {
                return Json(res);
            }
        }


        /// <summary>
        /// 软删除多个用户
        /// </summary>
        /// <param name="userInfoIds"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteUserInfos(List<string> userInfoIds)
        {
           
            if (userInfoIds == null || userInfoIds.Count == 0)
            {
                res.Msg = "请选择要删除的数据";
            }
            else
            {
                _userInfoBll.SoftDeleteDatas(userInfoIds);
                res.Status = 1;
                res.Msg = "成功";
                res.IsSuccess = true;
            }

            return Json(res);
        }

        /// <summary>
        /// 根据Id获取用户
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUserInfo(string userInfoId)
        {
            UserInfo userInfo = _userInfoBll.GetSingleEntityData(userInfoId);
            if (userInfo == null)
            {
                return Json(res);
            }
            else
            {
                res.Status = 1;
                res.Msg = "成功";
                res.IsSuccess = true;
                res.Datas = userInfo;
                return Json(res);
            }
        }

        /// <summary>
        /// 获取用户列表视图
        /// </summary>
        /// <returns></returns>
        public IActionResult UserInfoListView()
        {
            return View();
        }

      /// <summary>
      /// 获取用户列表(分页)
      /// </summary>
      /// <param name="page"></param>
      /// <param name="limit"></param>
      /// <param name="userName"></param>
      /// <param name="phoneNum"></param>
      /// <returns></returns>
        public IActionResult GetUserInfoList(int page, int limit, string userName, string phoneNum)
        {
            int count;

            object userInfos = _userInfoBll.GetUserInfoListByPage(page, limit, out count, userName, phoneNum);

            return Json(new
            {
                code = 0,
                msg = "成功",
                count = count,
                data = userInfos
            });
        }
    }
}


     