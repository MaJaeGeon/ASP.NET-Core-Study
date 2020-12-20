using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Unity
{
    public class Program
    {
        /*
        
        Program : HTTP ����, IIS ��� ���ο� ���� ���� �ٲ����ʴ� �������� �Ž����̴�.
        Startup : �̵����, DI �� ���� ���� �ٲ� �� �ִ� �������� �������̴�.

        */
        public static void Main(string[] args)
        {
            // 3) IHost �� ����
            // 4) ���� (Run) < �̶����� Listen�� ����
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            // 1) ���� �ɼ� ������ ����
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // 2) Startup Ŭ���� ����
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
