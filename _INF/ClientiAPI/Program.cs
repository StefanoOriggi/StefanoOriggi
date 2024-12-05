using Microsoft.EntityFrameworkCore;
using ClientiAPI.Data;
using ClientiAPI.Model;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("ClienteDb");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<ClienteContext>(options =>
options.UseMySql(connectionString, serverVersion)
.LogTo(Console.WriteLine, LogLevel.Information)
.EnableSensitiveDataLogging()
.EnableDetailedErrors()
);

builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "ClienteAPI";
    config.Title = "Cliente v1";
    config.Version = "v1";
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "ClienteAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}
app.MapGet("/cliente", async (ClienteContext db) =>
{
    return await db.Clienti.ToListAsync();
});
app.MapPost("/cliente", async (ClienteContext db, Cliente cliente) =>
{
    db.Clienti.Add(cliente);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{cliente.IdCliente}", cliente);
});
app.MapGet("/pizza/{id}", async (ClienteContext db, int id) =>
{
    //Devo cercare il cliente  datol'id 
    //Se la trovo la restituisco altrimenti not Found
    var cliente = await db.Clienti.FindAsync(id);
    if (cliente == null)
        return Results.NotFound("Non trovato");
    else
        return Results.Ok(cliente);

});
app.MapPut("/cliente/{id}", async (ClienteContext db, int id, Cliente pizza) =>
{
    var clt = await db.Clienti.FindAsync(id);
    if (clt != null)
    {
        // update
        clt.Nome = pizza.Nome;
        clt.Cognome = pizza.Cognome;
        clt.Citta = pizza.Citta;
        clt.Professione = pizza.Professione;
        await db.SaveChangesAsync();
        await db.SaveChangesAsync();
        return Results.Ok(clt);
    }
    else
        return Results.NotFound("Cliente non trovata");
});
app.MapDelete("/cliente/{id}", async (ClienteContext db, int id) =>
{
    var pizza = await db.Clienti.FindAsync(id);
    if (pizza is null)
        return Results.NotFound();
    
    db.Clienti.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});
app.Run();
