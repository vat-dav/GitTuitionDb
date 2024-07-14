using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TuitionDbContextConnection") ?? throw new InvalidOperationException("Connection string 'TuitionDbContextConnection' not found.");

builder.Services.AddDbContext<TuitionDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TuitionDbUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    // Other default identity options can be configured here
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TuitionDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

TuitionDbStartup.AddData(app);

app.Run();
