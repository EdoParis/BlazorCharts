using Demo.Components;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.WebHost.UseWebRoot("wwwroot")
                           .UseUrls("http://+:5000")
                           .UseStaticWebAssets();
            builder.Logging.ClearProviders();
            builder.Services.AddControllers();
            builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

            WebApplication app = builder.Build();
            app.UseExceptionHandler("/Error");
            app.MapControllers();
            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(DemoApp._Imports).Assembly);

            app.Run();
        }
    }
}
