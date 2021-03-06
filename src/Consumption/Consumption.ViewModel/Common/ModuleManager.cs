﻿/*
*
* 文件名    ：ModuleManager                             
* 程序说明  : 定义分组模块的数据管理器结构
* 更新时间  : 2020-05-12 21:10
* 联系作者  : QQ:779149549 
* 开发者群  : QQ群:874752819
* 邮件联系  : zhouhaogg789@outlook.com
* 视频教程  : https://space.bilibili.com/32497462
* 博客地址  : https://www.cnblogs.com/zh7791/
* 项目地址  : https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples
* 项目说明  : 以上所有代码均属开源免费使用,禁止个人行为出售本项目源代码
*/

namespace Consumption.ViewModel.Common
{
    using Consumption.Core.Common;
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 模块管理器
    /// </summary>
    public class ModuleManager : ViewModelBase
    {
        public ModuleManager()
        {
            //ModuleGroups = new ObservableCollection<ModuleGroup>();
            //moduleGroups.Add(new ModuleGroup()
            //{
            //    GroupName = "我的应用",
            //    Modules = new ObservableCollection<Module>()
            //     {
            //         new Module(){ Name="仪表板   ",Code="Atom" },
            //         new Module(){ Name="消费数据",Code="CurrencyUsd" },
            //         new Module(){ Name="我的账单",Code="Counter" },
            //         new Module(){ Name="我的账户" ,Code="CreditCard"},
            //         new Module(){ Name="个性化   ",Code="Palette" },
            //     }
            //});
            //moduleGroups.Add(new ModuleGroup()
            //{
            //    GroupName = "数据管理",
            //    Modules = new ObservableCollection<Module>()
            //     {
            //         new Module(){ Name="账户资料",Code="Certificate" },
            //         new Module(){ Name="基础数据" ,Code="SettingsBox"},
            //         new Module(){ Name="消费报表" ,Code="ChartDonut"},
            //         new Module(){ Name="消费提醒" ,Code="BellRingOutline"},
            //         new Module(){ Name="计划管理" ,Code="SettingsBox"},
            //         new Module(){ Name="系统设置" ,Code="Settings"},
            //     }
            //});

        }

        private ObservableCollection<Module> modules;
        /// <summary>
        /// 已加载模块
        /// </summary>
        public ObservableCollection<Module> Modules
        {
            get { return modules; }
            set { modules = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 加载程序集模块
        /// </summary>
        /// <returns></returns>
        public async Task LoadAssemblyModule()
        {
            try
            {
                Modules = new ObservableCollection<Module>();
                ModuleComponent mc = new ModuleComponent();
                var ms = await mc.GetAssemblyModules();
                foreach (var i in ms)
                {
                    var desc = EnumHelper.GetEnumDescription(i.ModuleType);
                    Modules.Add(new Module() { Name = i.Desc, Code = i.Icon, TypeName = i.TypeName, });
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
