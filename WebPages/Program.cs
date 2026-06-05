namespace WebPages
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseWebRoot("wwwroot")
                           .UseUrls("http://+:5000")
                           .UseStaticWebAssets();

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run();
        }
    }
}
