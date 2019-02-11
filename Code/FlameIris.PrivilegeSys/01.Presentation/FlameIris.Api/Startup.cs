using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Consul;
using FlameIris.Application;
using FlameIris.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;

namespace FlameIris.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                     //注意：下方加载了autofac.json配置后，就相当于重置了所有默认的配置加载，appsetting也要在这里手动加载
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     //加载配置文件，项目中的autofac.json 文件需要手动设置编译复制到输出目录，否则以下路径找不到文件
                     .AddJsonFile("StaticConfig/autofac.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            //初始化AutoMapper的映射关系
            FlameIrisMapper.Initialize();
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            var sqlConnectionString = Configuration.GetConnectionString("SqlServerConnection");
            //添加数据上下文
            services.AddDbContext<FlameIrisDBContext>(options => options.UseSqlServer(sqlConnectionString));

            services.AddMvc();

            //添加Logging
            services.AddLogging();

            #region Autofac 配置
            var containerBuilder = new ContainerBuilder();
            //将原本注册在内置 DI 组件中的依赖迁移入 Autofac 中
            containerBuilder.Populate(services);
            //从autofac.json文件中读取依赖配置为 ConfigurationModule
            var module = new ConfigurationModule(Configuration);
            //注册 ConfigurationModule 中的依赖关系
            containerBuilder.RegisterModule(module);
            var container = containerBuilder.Build();
            #endregion
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            #region NLog
            loggerFactory.AddNLog();//添加NLog
            env.ConfigureNLog("StaticConfig/nlog.config");//读取Nlog配置文件
            #endregion


            #region 注册到Consul服务中心
            RegisterServiceToServiceCenter();
            #endregion

        }



        /// <summary>
        /// 注册到Consul服务中心
        /// </summary>
        private void RegisterServiceToServiceCenter()
        {
            //资源 Api IP
            var ip = Configuration["ConsulSettings:ServiceIP"];
            //资源 Api 端口
            var port = int.Parse(Configuration["ConsulSettings:ServicePort"]);
            //服务客户端
            var client = new ConsulClient(obj =>
            {
                obj.Address = new Uri(Configuration["ConsulSettings:ServiceCenterUrl"]);
                obj.Datacenter = "dc1";
            });
            //资源 Api 封装成 服务客户端， 注册到 Consul服务中心 
            var result = client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "api" + Guid.NewGuid(),//服务编号，不能重复，用 Guid 最简单
                Name = "api",//服务的名字
                Address = ip,//我的 ip 地址(可以被其他应用访问的地址，本地测试可以用 127.0.0.1，机房环境中一定要写自己的内网 ip 地址)
                Port = port,//我的端口
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务停止多久后反注册
                    Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                    HTTP = $"http://{ip}:{port}/api/home/index",//健康检查地址
                    Timeout = TimeSpan.FromSeconds(5)
                }
            });
        }

    }

}
