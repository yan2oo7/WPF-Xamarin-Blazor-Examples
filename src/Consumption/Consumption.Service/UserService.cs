﻿/*
*
* 文件名    ：UserService                             
* 程序说明  : 用户服务
* 更新时间  : 2020-05-30 20：35
* 联系作者  : QQ:779149549 
* 开发者群  : QQ群:874752819
* 邮件联系  : zhouhaogg789@outlook.com
* 视频教程  : https://space.bilibili.com/32497462
* 博客地址  : https://www.cnblogs.com/zh7791/
* 项目地址  : https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples
* 项目说明  : 以上所有代码均属开源免费使用,禁止个人行为出售本项目源代码
*/

namespace Consumption.Service
{
    using Consumption.Core.IService;
    using Consumption.Core.Request;
    using Consumption.Core.Response;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RestSharp;
    using Consumption.Core.Query;
    using Consumption.Core.Entity;
    using Consumption.Core.Collections;

    /// <summary>
    /// 用户服务
    /// </summary>
    public partial class ConsumptionService
    {
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<BaseResponse<PagedList<User>>> GetUserListAsync(UserParameters parameters)
        {
            BaseServiceRequest<BaseResponse<PagedList<User>>> baseService =
                new BaseServiceRequest<BaseResponse<PagedList<User>>>();
            var r = await baseService.GetRequest(new UserQueryRequest()
            {
                parameters = parameters
            }, Method.GET);
            return r;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public async Task<BaseResponse<User>> LoginAsync(string account, string passWord)
        {
            BaseServiceRequest<BaseResponse<User>> baseService = new BaseServiceRequest<BaseResponse<User>>();
            var r = await baseService.GetRequest(new UserLoginRequest()
            {
                account = account,
                passWord = passWord
            }, Method.GET);
            return r;
        }
    }
}
