using System.Runtime.InteropServices;
using WebServer.Components;

namespace WebServer
{
    public class Program
    {
        private static uint port;

        public static void Main(string[] args)
        {
            Console.WriteLine($"Running framework: {RuntimeInformation.FrameworkDescription}");
            ReadParameters(args);

            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.WebHost.UseUrls($"http://+:{port}")
                           .UseStaticWebAssets();
            builder.Logging.ClearProviders();
            builder.Services.AddControllers();
            builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

            WebApplication app = builder.Build();
            app.UseWebAssemblyDebugging();

#if NET9_0_OR_GREATER
            app.MapStaticAssets();
#endif
            app.MapControllers();
            app.UseStaticFiles();
            app.UseAntiforgery();
            app.MapRazorComponents<App>()
               .AddInteractiveWebAssemblyRenderMode()
               .AddAdditionalAssemblies(typeof(WebApp._Imports).Assembly);
            app.Run();
        }

        private static void ReadParameters(string[] args)
        {
            if (args is null)
                return;

            if (args.Length == 0)
                return;

            string comand = null;

            foreach (string arg in args)
            {
                if (string.IsNullOrWhiteSpace(arg))
                {
                    comand = null;
                    continue;
                }

                if (arg.StartsWith('-'))
                    comand = arg.TrimStart('-').ToLower();
                else
                {
                    switch (comand)
                    {
                        case nameof(port):
                            uint.TryParse(arg, out port);
                            comand = null;
                            break;
                    }
                }
            }
        }
    }
}
