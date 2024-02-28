using Hacker.News.AppService.IService;
using Hacker.News.AppService.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.AppService.Extension
{
    public static class ServiceExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            //Service
            services.AddScoped<INewsAppService, NewsAppService>();
        }
    }
}
