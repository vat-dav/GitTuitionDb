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

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TuitionDbUser>>();

    var roles = new[] { "Admin", "Cleaner", "Teacher" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    string email = "admin1@admin.com";
    string password = "password";

    var adminUser = await userManager.FindByEmailAsync(email);
    if (adminUser == null)
    {
        var user = new TuitionDbUser { UserName = email, Email = email, EmailConfirmed = true };

        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
       
    }
}

app.Run();
