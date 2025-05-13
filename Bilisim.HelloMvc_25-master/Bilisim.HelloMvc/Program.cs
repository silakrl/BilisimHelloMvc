using Bilisim.HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilisim.HelloMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // OkulDbContext'i Dependency Injection ile kaydediyoruz
            builder.Services.AddDbContext<OkulDbContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-HLFQRGU\\SQLEXPRESS; Initial Catalog=OkulDbBilisim; Integrated Security=true; TrustServerCertificate=true"));

            // Controller ve View'lar� ekliyoruz
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // HTTP pipeline'� yap�land�r�yoruz
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Varsay�lan route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
