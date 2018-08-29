using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
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
        }
    }
}
