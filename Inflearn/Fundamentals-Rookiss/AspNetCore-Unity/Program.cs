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
        
        Program : HTTP 서버, IIS 사용 여부와 같이 거의 바뀌지않는 설정으로 거시적이다.
        Startup : 미들웨어, DI 와 같이 쉽게 바뀔 수 있는 설정으로 세부적이다.

        */
        public static void Main(string[] args)
        {
            // 3) IHost 를 생성
            // 4) 구동 (Run) < 이때부터 Listen을 시작
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            // 1) 각종 옵션 설정을 세팅
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // 2) Startup 클래스 지정
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
