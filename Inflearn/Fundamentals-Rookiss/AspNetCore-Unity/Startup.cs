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
        
        1) IIS, Apache ��� ���� HTTP �����κ��� HTTP ��û ����
        2) HTTP ��û�� ASP.NET Core ���� (Kestrel)�� ����
        3) �̵��� ����
        4) Controller �� ��û�� ����
        5) Controller ��ó ó���� �����͸� View �� ����

        =======================================================================

        �̵���� : HTTP Reqeust / Response �� ó���ϱ����� �߰� ����/��ǰ
        ��� ��û���� ó���ؾߵǴ� ������ ��� ��û ó���ڵ忡 �ִ°��� ��ȿ�����̱⶧���� �̵��� ���� �ϰ������� ó���Ѵ�.

        ������������ ���� �� �̵��� ��ġ�� �������� ���� �̵����� �ݴ�� �ö󰣴�.

        [Request]                        [Response]
        [����������-�̵����]    [����������-�̵����]
                    [EndPoint �̵����]

        �̵����� ó���� ������� ���� �̵����� �Ѱ��ֱ����� Ŀ���� �Ͽ� �ٸ� �̵����� �Ѱ��� �� �ִ�.


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
