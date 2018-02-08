using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlameIris.Api
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region 第一种写法：手动注册每一个 Service 到 IService 的注入关系

            //builder.RegisterType<UserService>().As<IUserService>();

            #endregion

            #region 第二种写法：获取程序集来自动注册 Service 到 IService的注入关系【类名必须以Service结尾，不遵守规范的可以拉出去斩了...】

            var a = builder.RegisterAssemblyTypes(this.ThisAssembly);
            var b = a.Where(t => t.Name.EndsWith("Service"));
            var c = b.AsImplementedInterfaces();
            var d = c.InstancePerLifetimeScope();

            #endregion

        }
    }
}
