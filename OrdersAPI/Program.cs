using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;
using OrdersAPI.Service;
using OrdersAPI.Service.ClientService;
using OrdersAPI.Service.OrderProductService;
using OrdersAPI.Service.OrderService;
using OrdersAPI.Service.ProductService;
using OrdersAPI.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    }); 

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoTemplate<ClientModel>, DbDaoClient>();
builder.Services.AddTransient<IDaoTemplate<ProductModel>, DbDaoProduct>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();
builder.Services.AddTransient<IDaoTemplate<OrderProductModel>, DbDaoOrderProduct>();

var app = builder.Build();




app.MapGet("/", () => "Hello World!");

app.Map("/login/{username}", (string username) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
    // создаем JWT-токен
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    return new JwtSecurityTokenHandler().WriteToken(jwt);
});

//Client table

app.MapGet("/client/all",  async (HttpContext context, IDaoTemplate<ClientModel> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/client/get", async (HttpContext context, IDaoTemplate<ClientModel> dao, int id) =>
{
    return await dao.GetById(id);
});

app.MapPost("/client/add", [Authorize] async (HttpContext context, ClientModel client, IDaoTemplate<ClientModel> dao) =>
{
    return await dao.Add(client);
});
app.MapPost("/client/update", [Authorize] async (HttpContext context, ClientModel client, IDaoTemplate<ClientModel> dao) =>
{
    return await dao.Update(client);
});
app.MapPost("/client/delete", [Authorize] async (HttpContext context, IDaoTemplate<ClientModel> dao, int id) =>
{
    return await dao.Delete(id);
});



//Product table
app.MapGet("/product/all", async (HttpContext context, IDaoTemplate<ProductModel> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/product/get", async (HttpContext context, IDaoTemplate<ProductModel> dao, int id) =>
{
    return await dao.GetById(id);
});

app.MapPost("/product/add", [Authorize] async (HttpContext context, ProductModel product, IDaoTemplate<ProductModel> dao) =>
{
    return await dao.Add(product);
});
app.MapPost("/product/update", [Authorize] async (HttpContext context, ProductModel product, IDaoTemplate<ProductModel> dao) =>
{
    return await dao.Update(product);
});
app.MapPost("/product/delete", [Authorize] async (HttpContext context, IDaoTemplate<ProductModel> dao, int id) =>
{
    return await dao.Delete(id);
});



//Order table
app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/order/fullAll", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetFullAllOrders();
});
app.MapGet("/order/get", async (HttpContext context, IDaoOrder dao, int id) =>
{
    return await dao.GetById(id);
});

app.MapPost("/order/add", [Authorize] async (HttpContext context, OrderModel order, IDaoOrder dao) =>
{
    return await dao.Add(order);
});
app.MapPost("/order/update", [Authorize] async (HttpContext context, OrderModel order, IDaoOrder dao) =>
{
    return await dao.Update(order);
});
app.MapPost("/order/delete", [Authorize] async (HttpContext context, IDaoOrder dao, int id) =>
{
    return await dao.Delete(id);
});



//OrderProduct table
app.MapGet("/order_product/all", async (HttpContext context, IDaoTemplate<OrderProductModel> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/order_product/get", async (HttpContext context, IDaoTemplate<OrderProductModel> dao, int id) =>
{
    return await dao.GetById(id);
});

app.MapPost("/order_product/add", [Authorize] async (HttpContext context, OrderProductModel order, IDaoTemplate<OrderProductModel> dao) =>
{
    return await dao.Add(order);
});
app.MapPost("/order_product/update", [Authorize] async (HttpContext context, OrderProductModel order, IDaoTemplate<OrderProductModel> dao) =>
{
    return await dao.Update(order);
});
app.MapPost("/order_product/delete", [Authorize] async (HttpContext context, IDaoTemplate<OrderProductModel> dao, int id) =>
{
    return await dao.Delete(id);
});


//Other methods
app.MapGet("/check", async (HttpContext context, IDaoOrder dao, int OrderId) =>
{
    return await dao.Bill(OrderId);
});


app.MapGet("/fullOrderInfo", async (HttpContext context, IDaoOrder dao, int OrderId) =>
{
    return await dao.FullOrderInfo(OrderId);
});



app.Run();
