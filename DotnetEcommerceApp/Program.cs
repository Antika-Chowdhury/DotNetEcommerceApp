using DotnetEcommerceApp.Data;
using DotnetEcommerceApp.DataLayer.Repositories;
using DotnetEcommerceApp.DataLayer.Repositors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register MVC (Views & Controllers) and API
builder.Services.AddControllersWithViews();  // Supports both MVC and API

// ✅ Enable Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// ✅ Register AppDbContext with Dependency Injection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// ✅ Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Needed for serving CSS, JS, images, etc.

app.UseRouting();

app.UseAuthentication();  // ✅ Authentication before Authorization
app.UseAuthorization();

// ✅ Map API Controllers
app.MapControllers();

// ✅ Map MVC Routes (Default Route for Views)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
