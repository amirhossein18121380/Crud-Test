using Mc2.CrudTest.Presentation.Client.Services;
using Mc2.CrudTest.Presentation.Client.Services.Customer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Mc2.CrudTest.Presentation.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IHttpService, HttpService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5247") });
            builder.Services.AddScoped<CustomerService>();

            //builder.Services.AddScoped(x =>
            //{
            //    var apiUrl = new Uri("https://localhost:7096");
            //    return new HttpClient() { BaseAddress = apiUrl };
            //});

            builder.Services.AddSingleton<PageHistoryState>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}