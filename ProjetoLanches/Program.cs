using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories;
using ProjetoLanches.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetoLanchesContext>(options=>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Projetolanches"))
        
    );

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add cache 
builder.Services.AddMemoryCache();
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

// usando session
app.UseSession();


app.UseAuthorization();


app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern: "Lanche/{action}/{categoria?}",
    defaults: new { Controller = "Lanche", action = "List" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
