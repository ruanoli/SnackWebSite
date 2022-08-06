using Microsoft.EntityFrameworkCore;
using SnackWebSite.Data;
using SnackWebSite.Models;
using SnackWebSite.Repositories;
using SnackWebSite.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
builder.Services.AddTransient<ISnackRepository, SnackRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

//Obtendo informações do request e do response, autenticação e outras informações da requisição.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Cria uma instancia do carrinho a cada request. 
//Assim se dois clientes solicitarem o obj carrinho ao mesmo tempo, eles terão instancias diferentes.
//Criando carrinho de compras.
builder.Services.AddScoped(x => ShoppingCart.GetCart(x));

//Session configurado para usar na aplicação
builder.Services.AddMemoryCache(); //Implementação padrão
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession(); //Session configurado para usar na aplicação

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name:"categoryFilter",
    pattern: "Snack/{action}/{category?}",
    defaults: new {controller = "Snack", Action = "List"});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
