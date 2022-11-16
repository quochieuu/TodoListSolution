using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoListSolution.DataContext;
using TodoListSolution.Models;
using TodoListSolution.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(
                            builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddTransient<DataDbContext>();
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<DataDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
