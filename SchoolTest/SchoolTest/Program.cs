using Microsoft.EntityFrameworkCore;
using SchoolTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

var app = builder.Build();

using (IServiceScope scoped = app.Services.CreateScope())
{
    IServiceProvider service = scoped.ServiceProvider;

    try
    {
        var context = service.GetRequiredService<SchoolContext>();
        await SeedData.Seed(context);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StudentGrade}/{action=Index}/{id?}");

app.Run();
