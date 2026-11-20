using BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DAL -> BLL -> PL ServiceCollection
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


// Özel rotalar
// /about/ -> /home/about/
app.MapControllerRoute("about_us", "about", new { Controller = "home", Action = "about" }).WithStaticAssets();

// /privacy/ -> /home/privacy/
app.MapControllerRoute("privacy", "privacy", new { Controller = "home", Action = "privacy" }).WithStaticAssets();

// /contact/ -> /home/contact/
app.MapControllerRoute("contact_us", "contact", new { Controller = "home", Action = "contact" }).WithStaticAssets();

// Varsayılan rota şablonu
// / -> "{controller=Home}/{action=Index}/"
// /dashboard -> "{controller=dashboard}/{action=Index}/"
// /dashboard/category -> "{controller=Dashboard}/{action=Category}/"
// /dashboard/category/25 -> "{controller=Dashboard}/{action=Category}/{id=25}"
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
