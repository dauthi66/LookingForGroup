using LookingForGroup.Areas.Identity.Data;
using LookingForGroup.Data;
using LookingForGroup.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LookingForGroupDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<TagsDBHelper>();

builder.Services.AddDefaultIdentity<LookingForGroupUser>(options => options.SignIn.RequireConfirmedAccount = true)
    //add role support (this is for admins)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LookingForGroupDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

//create service provider to access built in services
IServiceScope? serviceProvider = app.Services.GetRequiredService<IServiceProvider>().CreateScope();

//Create default roles
await IdentityHelper.CreateRoles
    (serviceProvider.ServiceProvider, IdentityHelper.Member, IdentityHelper.Moderator, IdentityHelper.Admin);

//create default admin
await IdentityHelper.CreateDefaultMember(serviceProvider.ServiceProvider, IdentityHelper.Admin);

// allow use of TagsDBhelper
TagsDBHelper tagHelper = serviceProvider.ServiceProvider.GetService<TagsDBHelper>();

//create some default tags
tagHelper.addTag("Adventure");
tagHelper.addTag("FPS");
tagHelper.addTag("RPG");
tagHelper.addTag("Racing");

app.Run();


