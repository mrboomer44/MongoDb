using MongoDb.Services.AboutListServices;
using MongoDb.Services.AboutSection1Services;
using MongoDb.Services.AboutSection2Services;
using MongoDb.Services.FaqServices;
using MongoDb.Services.FeatureServices;
using MongoDb.Services.OrderServices;
using MongoDb.Services.ProductServices;
using MongoDb.Services.SocialMediaServices;
using MongoDb.Services.StoryVideoServices;
using MongoDb.Services.SubscribeServices;
using MongoDb.Services.TestimonialServices;
using MongoDb.Services.LoginServices;
using MongoDb.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAboutListServices, AboutListServices>();
builder.Services.AddScoped<IAboutSection1Services, AboutSection1Services>();
builder.Services.AddScoped<IAboutSection2Services, AboutSection2Services>();
builder.Services.AddScoped<IFaqServices, FaqServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<ISocialMediaServices, SocialMediaServices>();
builder.Services.AddScoped<IStoryVideoServices, StoryVideoServices>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<ISubscribeServices, SubscribeServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
// 1. RAM (Haf�za) �zelli�ini a��yoruz
builder.Services.AddMemoryCache();

// 2. Cookie (Bileklik/Kimlik) �zelli�ini a��yoruz
builder.Services.AddAuthentication("AdminCookies")
    .AddCookie("AdminCookies", options =>
    {
        options.LoginPath = "/Admin/Index"; // Bilekli�i olmayan buraya (login'e) at�lacak
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

app.UseAuthentication(); // Cookie kimlik do�rulamas�n� etkinle�tir
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
