using BlazorProject.Common;
using BlazorProject.Client.Service.Implements;
using BlazorProject.Client.Service.Contracts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace BlazorProject.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseOrderInfoService, CourseOrderInfoService>();
            builder.Services.AddScoped<IStripePaymentService, StripePaymentService>();
            await builder.Build().RunAsync();
        }
    }
}
