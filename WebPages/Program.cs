namespace WebPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseWebRoot("wwwroot")
                           .UseStaticWebAssets();

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run();
        }
    }
}
