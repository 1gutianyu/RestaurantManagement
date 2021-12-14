using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantManageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Extensions
{
    /// <summary>
    /// 拓展ControllerBase
    /// </summary>
    public static class ControllerBaseExtension
    {
        /// <summary>
        /// 拓展方法：获取当前登录用户的信息
        /// </summary>
        /// <param name="controllerBase"></param>
        /// <returns></returns>
        public static UserInfo GetSessionUserInfo(this ControllerBase controllerBase)
        {
            var userInfoJson = controllerBase.HttpContext.Session.GetString("UserInfo");
            if (string.IsNullOrEmpty(userInfoJson))
            {
                return null;
            }
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(userInfoJson);
            return userInfo;
        }
    }
}
