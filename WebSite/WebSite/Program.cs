using WebServer.Components;

namespace WebServer
{
    public class Program
    {
        private static uint Port;

        public static void Main(string[] args)
        {
            ReadParameters(args);

            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.WebHost.UseWebRoot("wwwroot")
                           .UseUrls($"http://+:{Port}")
                           .UseStaticWebAssets();
            builder.Logging.ClearProviders();
            builder.Services.AddControllers();
            builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();

            WebApplication app = builder.Build();
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
                        case "port":
                            uint.TryParse(arg, out Port);
                            comand = null;
                            break;
                    }
                }
            }
        }
    }
}
