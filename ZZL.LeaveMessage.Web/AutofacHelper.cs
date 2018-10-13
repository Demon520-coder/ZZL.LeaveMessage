using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Reflection;
using ZZL.LeaveMessage.Service;
using ZZL.LeaveMessage.IService;

namespace ZZL.LeaveMessage.Web
{
    /// <summary>
    /// autofac帮助类：1.类型注册方法; 2.字段:containerBuilder
    /// </summary>
    public class AutofacHelper
    {
        private readonly ContainerBuilder _builder;

        public AutofacHelper()
        {
            _builder = new ContainerBuilder();
        }

        public void Register()
        {
            //注册所有的控制器类型:
            _builder.RegisterControllers(typeof(AutofacHelper).Assembly);
            //注册业务层
            ////告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例ZZL.LeaveMessage.Service
            Assembly services = Assembly.Load("ZZL.LeaveMessage.Service");
            //创建services中的所有类的instance以此类的实现接口存储
            _builder.RegisterTypes(services.GetTypes()).AsImplementedInterfaces();
            //_builder.RegisterType<MessageService>().As<IMessageService>();
            var container = _builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}