using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Domain
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region 第二种写法：获取程序集来自动注册 Repository 到 IRepository注入关系【类名必须以Service结尾，不遵守规范的可以拉出去斩了...】

            builder.RegisterAssemblyTypes(this.ThisAssembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
            #endregion

        }
    }
}
