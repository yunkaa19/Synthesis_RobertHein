using DataAccessLayer.Production;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using RealizationProvider;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var services = RealizationProvider.ServiceProvider.Get();
IServiceProvider provider = services.BuildServiceProvider();

var bonusRepository = provider.GetService<IBonusRepository>();
var bonusCardRepository = provider.GetService<IBonusCardRepository>();
var categoryRepository = provider.GetService<ICategoryRepository>();
var customerRepository = provider.GetService<ICustomerRepository>();
var orderRepository = provider.GetService<IOrderRepository>();
var productRepository = provider.GetService<IProductRepository>();

if (productRepository != null && categoryRepository != null && bonusRepository != null && bonusCardRepository != null &&
    customerRepository != null && orderRepository != null)
{
    builder.Services.AddSingleton<IBonusRepository>(bonusRepository);
    builder.Services.AddSingleton<IBonusCardRepository>(bonusCardRepository);
    builder.Services.AddSingleton<ICategoryRepository>(categoryRepository);
    builder.Services.AddSingleton<ICustomerRepository>(customerRepository);
    builder.Services.AddSingleton<IOrderRepository>(orderRepository);
    builder.Services.AddSingleton<IProductRepository>(productRepository);
}

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/LogIn");
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


app.UseSession();
app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
