using Microsoft.EntityFrameworkCore;
using OrdersAPI.Model;
using OrdersAPI.Model.Entity;
using OrdersAPI.Service.ClientService;
using OrdersAPI.Service.OrderProductService;
using OrdersAPI.Service.OrderService;
using OrdersAPI.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoProduct, DbDaoProduct>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();
builder.Services.AddTransient<IDaoOrderProduct, DbDaoOrderProduct>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


//Client table

app.MapGet("/client/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});
app.MapGet("/client/get", async (HttpContext context, IDaoClient dao,int id) =>
{
    return await dao.GetClientById(id);
});

app.MapPost("/client/add", async (HttpContext context,ClientModel client ,IDaoClient dao) =>
{
    return await dao.AddClient(client);
});
app.MapPost("/client/update", async (HttpContext context,ClientModel client ,IDaoClient dao) =>
{
    return await dao.UpdateClient(client);
});
app.MapPost("/client/delete", async (HttpContext context,IDaoClient dao, int id) =>
{
    return await dao.DeleteClient(id);
});



//Product table
app.MapGet("/product/all", async (HttpContext context, IDaoProduct dao) =>
{
    return await dao.GetAllProducts();
});
app.MapGet("/product/get", async (HttpContext context, IDaoProduct dao,int id) =>
{
    return await dao.GetProductById(id);
});

app.MapPost("/product/add", async (HttpContext context,ProductModel product , IDaoProduct dao) =>
{
    return await dao.AddProduct(product);
});
app.MapPost("/product/update", async (HttpContext context, ProductModel product , IDaoProduct dao) =>
{
    return await dao.UpdateProduct(product);
});
app.MapPost("/product/delete", async (HttpContext context, IDaoProduct dao, int id) =>
{
    return await dao.DeleteProduct(id);
});



//Order table
app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAllOrders();
});
app.MapGet("/order/fullAll", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetFullAllOrders();
});
app.MapGet("/order/get", async (HttpContext context, IDaoOrder dao,int id) =>
{
    return await dao.GetOrderById(id);
});

app.MapPost("/order/add", async (HttpContext context,OrderModel order, IDaoOrder dao) =>
{
    return await dao.AddOrder(order);
});
app.MapPost("/order/update", async (HttpContext context, OrderModel order, IDaoOrder dao) =>
{
    return await dao.UpdateOrder(order);
});
app.MapPost("/order/delete", async (HttpContext context, IDaoOrder dao, int id) =>
{
    return await dao.DeleteOrder(id);
});



//OrderProduct table
app.MapGet("/order_product/all", async (HttpContext context, IDaoOrderProduct dao) =>
{
    return await dao.GetAllOrderProducts();
});
app.MapGet("/order_product/get", async (HttpContext context, IDaoOrderProduct dao,int id) =>
{
    return await dao.GetOrderProductById(id);
});

app.MapPost("/order_product/add", async (HttpContext context,OrderProductModel order, IDaoOrderProduct dao) =>
{
    return await dao.AddOrderProduct(order);
});
app.MapPost("/order_product/update", async (HttpContext context, OrderProductModel order, IDaoOrderProduct dao) =>
{
    return await dao.UpdateOrderProduct(order);
});
app.MapPost("/order_product/delete", async (HttpContext context, IDaoOrderProduct dao, int id) =>
{
    return await dao.DeleteOrderProduct(id);
});


app.MapGet("/check", async (HttpContext context, IDaoOrderProduct dao, int OrderId) =>
{
    List<OrderProductModel> product = await dao.GetProductByOrderId(OrderId);
    return new { Products = product,Count = product.Sum(pr=>pr.Count) };
});



app.Run();
