using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WebApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Running framework: {RuntimeInformation.FrameworkDescription}");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            await builder.Build().RunAsync();
        }
    }
}
