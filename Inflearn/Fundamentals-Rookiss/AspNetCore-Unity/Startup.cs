using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Unity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*
        
        1) IIS, Apache 등과 같은 HTTP 서버로부터 HTTP 요청 받음
        2) HTTP 요청을 ASP.NET Core 서버 (Kestrel)로 전달
        3) 미들웨어가 적용
        4) Controller 로 요청을 전달
        5) Controller 에처 처리한 데이터를 View 로 전달

        =======================================================================

        미들웨어 : HTTP Reqeust / Response 를 처리하기위한 중간 로직/부품
        모든 요청마다 처리해야되는 로직을 모든 요청 처리코드에 넣는것은 비효율적이기때문에 미들웨어를 통해 일괄적으로 처리한다.

        파이프라인을 통해 각 미들웨어를 거치며 내려간뒤 최종 미들웨어에서 반대로 올라간다.

        [Request]                        [Response]
        [파이프라인-미들웨어]    [파이프라인-미들웨어]
                    [EndPoint 미들웨어]

        미들웨어에서 처리한 결과물을 다음 미들웨어로 넘겨주기전에 커팅을 하여 다른 미들웨어로 넘겨줄 수 있다.


        */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
