using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;
using OrdersAPI.Service;
using OrdersAPI.Service.ClientService;
using OrdersAPI.Service.OrderProductService;
using OrdersAPI.Service.OrderService;
using OrdersAPI.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoTemplate<ClientModel>, DbDaoClient>();
builder.Services.AddTransient<IDaoTemplate<ProductModel>, DbDaoProduct>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();
builder.Services.AddTransient<IDaoTemplate<OrderProductModel>, DbDaoOrderProduct>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


//Client table

app.MapGet("/client/all", async (HttpContext context, IDaoTemplate<ClientModel> dao) =>
{
    return await dao.GetAll();
});
app.MapGet("/client/get", async (HttpContext context, IDaoTemplate<ClientModel> dao, int id) =>
{
    return await dao.GetById(id);
});

app.MapPost("/client/add", async (HttpContext context, ClientModel client, IDaoTemplate<ClientModel> dao) =>
{
    return await dao.Add(client);
});
app.MapPost("/client/update", async (HttpContext context, ClientModel client, IDaoTemplate<ClientModel> dao) =>
{
    return await dao.Update(client);
});
app.MapPost("/client/delete", async (HttpContext context, IDaoTemplate<ClientModel> dao, int id) =>
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

app.MapPost("/product/add", async (HttpContext context, ProductModel product, IDaoTemplate<ProductModel> dao) =>
{
    return await dao.Add(product);
});
app.MapPost("/product/update", async (HttpContext context, ProductModel product, IDaoTemplate<ProductModel> dao) =>
{
    return await dao.Update(product);
});
app.MapPost("/product/delete", async (HttpContext context, IDaoTemplate<ProductModel> dao, int id) =>
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

app.MapPost("/order/add", async (HttpContext context, OrderModel order, IDaoOrder dao) =>
{
    return await dao.Add(order);
});
app.MapPost("/order/update", async (HttpContext context, OrderModel order, IDaoOrder dao) =>
{
    return await dao.Update(order);
});
app.MapPost("/order/delete", async (HttpContext context, IDaoOrder dao, int id) =>
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

app.MapPost("/order_product/add", async (HttpContext context, OrderProductModel order, IDaoTemplate<OrderProductModel> dao) =>
{
    return await dao.Add(order);
});
app.MapPost("/order_product/update", async (HttpContext context, OrderProductModel order, IDaoTemplate<OrderProductModel> dao) =>
{
    return await dao.Update(order);
});
app.MapPost("/order_product/delete", async (HttpContext context, IDaoTemplate<OrderProductModel> dao, int id) =>
{
    return await dao.Delete(id);
});


//Other method
app.MapGet("/check", async (HttpContext context, IDaoOrder dao, int OrderId) =>
{
    OrderModel order = await dao.GetFullOrderById(OrderId);

    //Версия, выводящая именно Product
    return new
    {
        Products = order.OrderProducts.Select(ordPr => ordPr.Product),
        FullPrice = order.OrderProducts.Sum(ordPr => ordPr.Count * ordPr.Product.Price)
    };

    //Понял

    //Версия, выводящая OrderProduct
    //return new
    //{
    //    OrderProducts = order.OrderProducts,
    //    FullPrice = order.OrderProducts.Sum(ordPr => ordPr.Count * ordPr.Product.Price)
    //};
});







app.MapGet("/fullOrderInfo", async (HttpContext context, IDaoOrder dao, int OrderId) =>
{
    OrderModel order = await dao.GetFullOrderById(OrderId);

    return new
    {
        OrderProducts = order.OrderProducts,
        CountProducts = order.OrderProducts.Sum(ordPr => ordPr.Count)
    };
});



app.Run();
