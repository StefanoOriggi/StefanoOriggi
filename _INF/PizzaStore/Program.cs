using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Model;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PizzaDb>(options =>
options.UseInMemoryDatabase("items"));

builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "PizzaStore";
    config.Title = "PizzaStore";
    config.Version = "v1";
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "PizzaStore";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}
app.MapGet("/", () => "Hello World!");
app.MapGet("/pizze", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.MapPost("/pizza0", async (PizzaDb db, Pizza pizza) =>
{
    db.Pizzas.Add(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});
app.MapGet("/pizza1/{id}", async (PizzaDb db, int id) => await
db.Pizzas.FindAsync(id));
app.MapGet("/pizza2/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    else
        return Results.Ok(pizza);
});
app.MapPut("/pizza3/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
    var pizza_search = await db.Pizzas.FindAsync(id);
    if (pizza_search is null) return Results.NotFound();
    pizza_search.Name = updatepizza.Name;
    pizza_search.Description = updatepizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.Run();
