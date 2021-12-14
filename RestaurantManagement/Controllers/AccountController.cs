using IRestaurantManageBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryCommon;
using RestaurantManageEntity;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class AccountController : Controller
    {
        private IUserInfoBll _userInfoBll;

        public AccountController(IUserInfoBll userInfoBll)
        {
            _userInfoBll = userInfoBll;
        }


        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginView()
        {
            return View();
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string account, string password)
        {
            CustomActionResult res = new CustomActionResult();
            //参数认证
            if (string.IsNullOrEmpty(account))
            {
                res.Msg = "账号不能为空";
                return Json(res);
            }
            else if (string.IsNullOrEmpty(password))
            {
                res.Msg = "密码不能为空";
                return Json(res);
            }

            //使用MD5加密
            string pwdMD5 = MD5Helper.MD5Encrypt64(password);

            //判断账号密码是否正确
            UserInfo userInfo = _userInfoBll.GetUserInfoByLogin(account, pwdMD5);
            if (userInfo == null)
            {
                res.Msg = "账号或密码错误";
                return Json(res);
            }
            else
            {
                res.IsSuccess = true;
                res.Status = 1;
                res.Msg = "登录成功";
                res.Datas = new
                {
                    UserName = userInfo.UserName
                };
                //序列化用户对象
                string jsonUserInfo = JsonConvert.SerializeObject(userInfo);

                //保持用户信息到session中
                HttpContext.Session.SetString("UserInfo", jsonUserInfo);

                return Json(res);
            }
            //使用MD5
        }
    }
}
