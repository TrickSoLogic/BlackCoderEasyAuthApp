using AspNetCoreAuth.Data;
using AspNetCoreAuth.Data.Repositories;
using AspNetCoreAuth.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Register repository 
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IConferenceRepository, ConferenceRepository>();
builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
//Register DBContext
builder.Services.AddDbContext<ConfDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
) ;

//For Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.Cookie.Name = "Auth.Cookie";
    })
    .AddCookie(ExternalAuthenticationDefaults.AuthenticationScheme)
    .AddGoogle(o => 
    {
        o.SignInScheme= ExternalAuthenticationDefaults.AuthenticationScheme;
        o.ClientId = builder.Configuration["Google:ClientId"];
        o.ClientSecret = builder.Configuration["Google:ClientSecret"];   
    });

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
