using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WebApplication1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication1Context") ?? throw new InvalidOperationException("Connection string 'WebApplication1Context' not found.")));


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "MyCookieAuth"; // Domyœlny schemat autentykacji
})
.AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/A ccount/Login"; // Œcie¿ka do strony logowania
    options.AccessDeniedPath = "/Account/AccessDenied"; // Œcie¿ka do strony odrzuconego dostêpu
    // Inne konfiguracje...
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeAdmin", policy =>
    {
        policy.RequireClaim("Admin"); // Wymaga, aby u¿ytkownik mia³ rolê "Admin"
    });

    options.AddPolicy("MustBeUser", policy =>
    {
        policy.RequireClaim("User"); // Wymaga, aby u¿ytkownik mia³ rolê "Admin"
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
