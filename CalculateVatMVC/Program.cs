using CalculateVatMVC.Services;
using CalculateVatMVC.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("CalculaVatAPI", a =>
{
    a.BaseAddress = new Uri(builder.Configuration["ServiceUri:CalculaVatAPI"]);
});

builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<ICountriesVatsService, CountriesVatsService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
