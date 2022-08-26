using IndependentProj.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(mvcOptions =>
{
    mvcOptions.EnableEndpointRouting = false;
});
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddTransient<IProjectRepository, EFProjectRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseRouting();

app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
    routes.MapRoute(
        name: null,
        template: "{controller=Employee}/{action=Index}/{id?}"
        );
    routes.MapRoute(
        name: null,
        template: "{controller=Project}/{action=Index}/{id?}"
        );
   
});

app.Run();
