namespace WebPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
            {
                WebRootPath = "docs"
            });
            builder.WebHost.UseStaticWebAssets();

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run();
        }
    }
}