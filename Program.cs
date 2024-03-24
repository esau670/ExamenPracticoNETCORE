
namespace PruebaEncuesta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // mandamos a llamar startup
            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();
            
           

            startup.Configure(app, app.Environment);

            app.Run();
        }
    }
}
