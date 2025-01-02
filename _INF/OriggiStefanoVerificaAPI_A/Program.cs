using Microsoft.EntityFrameworkCore;
using OriggiStefanoVerificaAPI_A;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VenditeAPIConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<VenditeDbContext>(
dbContextOptions => dbContextOptions
.UseMySql(connectionString, serverVersion)
.LogTo(Console.WriteLine, LogLevel.Information)
.EnableSensitiveDataLogging()
.EnableDetailedErrors()
);
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "VenditeApi";
    config.Title = " Vendite v1";
    config.Version = "v1";
});
var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerUi(config =>
{
    config.DocumentTitle = " VenditeApi ";
    config.Path = "/swagger";
    config.DocumentPath = "/swagger/{documentName}/swagger.json";
    config.DocExpansion = "list";
});

#region fornitori
app.MapGet("/fornitori", async (VenditeDbContext db) =>
{
    return Results.Ok(await db.Fornitore.Select(f => new FornitoreDTO(f)).ToListAsync());
});
app.MapGet("/fornitori/{fornitoreId}", async (VenditeDbContext db, int fornitoreId) =>
{
    var fornitore = await db.Fornitore.FindAsync(fornitoreId);
    if (fornitore is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(fornitore);
});
app.MapPost("/fornitori", async (VenditeDbContext db, FornitoreDTO fornitoreDTO) =>
{
    Fornitore fornitore = new()
    {
        Cognome=fornitoreDTO.Nome,
        Nome=fornitoreDTO.Cognome,
        Indirizzo=fornitoreDTO.Indirizzo,
        Cap=fornitoreDTO.Cap,
    };
    await db.Fornitore.AddAsync(fornitore);
    await db.SaveChangesAsync();
    return Results.Created("/registi/regista.RegistaId", new FornitoreDTO(fornitore));
});
app.MapPut("/fornitori/{fornitoreId}", async (VenditeDbContext db, FornitoreDTO fornitoreDTO, int fornitoreId) =>
{
    var fornitore = await db.Fornitore.FindAsync(fornitoreId);
    if (fornitore is null)
    {
        return Results.NotFound();
    }
    fornitore.Cognome = fornitoreDTO.Cognome;
    fornitore.Nome = fornitoreDTO.Cognome;
    fornitore.Indirizzo = fornitoreDTO.Indirizzo;
    fornitore.Cap = fornitoreDTO.Cap;

    await db.SaveChangesAsync();
    return Results.Ok(fornitore);
});
app.MapDelete("/fornitori/{fornitoreId}", async (VenditeDbContext db, int fornitoreId) =>
{
    var fornitore = await db.Fornitore.FindAsync(fornitoreId);
    if (fornitore is null)
        return Results.NotFound();
    db.Remove(fornitore);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion
#region prodotti
app.MapGet("/fornitori/{fornitoreId}/prodotti", async (VenditeDbContext db, int fornitoreId) =>
{
    var fornitore = await db.Fornitore.FindAsync(fornitoreId);
    if (fornitore is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(await db.Prodotto.Where(p => p.FornitoreId == fornitoreId).Select(p => new ProdottoDTO(p)).ToListAsync());
});
app.MapPost("/fornitori/{fornitoreId}/prodotto", async (VenditeDbContext db, ProdottoDTO prodottoDTO, int fornitoreId) =>
{
    var fornitore = await db.Fornitore.FindAsync(fornitoreId);
    if (fornitore is null)
    {
        return Results.NotFound();
    }
    Prodotto prodotto = new()
    {
        Nome = prodottoDTO.Nome,
        Marca = prodottoDTO.Marca,
        Prezzo = prodottoDTO.Prezzo,
        Quantita = prodottoDTO.Quantita,
        FornitoreId = fornitoreId
    };
    await db.Prodotto.AddAsync(prodotto);
    await db.SaveChangesAsync();
    return Results.Created("/prodotti/prodotto.ProdottoId", new ProdottoDTO(prodotto));
});
app.MapGet("/prodotti", async (VenditeDbContext db) =>
{
    return Results.Ok(await db.Prodotto.Select(p => new ProdottoDTO(p)).ToListAsync());
});
app.MapGet("/prodotti/{prodottoId}", async (VenditeDbContext db, int prodottoId) =>
{
    var prodotto = await db.Prodotto.FindAsync(prodottoId);
    if (prodotto is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(prodotto);
});
app.MapPut("/prodotti/{prodottoId}", async (VenditeDbContext db, ProdottoDTO prodottoDTO, int prodottoId) =>
{
    var prodotto = await db.Prodotto.FindAsync(prodottoId);
    if (prodotto is null)
    {
        return Results.NotFound();
    }
    prodotto.Nome = prodottoDTO.Nome;
    prodotto.Marca = prodottoDTO.Marca;
    prodotto.Prezzo = prodottoDTO.Prezzo;
    prodotto.Quantita = prodottoDTO.Quantita;
    await db.SaveChangesAsync();
    return Results.Ok(prodotto);
});
app.MapDelete("/prodotti/{prodottoId}", async (VenditeDbContext db, int prodottoId) =>
{
    var prodotto = await db.Prodotto.FindAsync(prodottoId);
    if (prodotto is null)
        return Results.NotFound();
    db.Remove(prodotto);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion
#region endpointsAggiuntivi
app.MapGet("/clienti", async (VenditeDbContext db) =>
{
    return Results.Ok(await db.Cliente.Select(c => new ClienteDTO(c)).ToListAsync());
});
app.MapPost("/clienti", async (VenditeDbContext db, ClienteDTO clienteDTO) =>
{
    Cliente cliente = new()
    {
        Nome = clienteDTO.Nome,
        Cognome = clienteDTO.Cognome,
        NumeroCartaDiCredito = clienteDTO.NumeroCartaDiCredito,
        Citta = clienteDTO.Citta
    };
    await db.Cliente.AddAsync(cliente);
    await db.SaveChangesAsync();
    return Results.Created("/clienti/cliente.ClienteId", new ClienteDTO(cliente));
});
app.MapPost("/acquisti/{clienteId}/{prodottoId}", async (VenditeDbContext db, DateOnly dataAcquisto, int clienteId, int prodottoId) =>
{
    var cliente = await db.Cliente.FindAsync(clienteId);
    if (cliente is null)
    {
        return Results.NotFound();
    }
    var prodotto = await db.Prodotto.FindAsync(prodottoId);
    if (prodotto is null)
    {
        return Results.NotFound();
    }
    Acquisti acquisto = new()
    {
        ClienteId = clienteId,
        ProdottoID = prodottoId,
        DataAcquisto = dataAcquisto
    };
    await db.Acquisti.AddAsync(acquisto);
    await db.SaveChangesAsync();
    return Results.Created("/acquisti/acquisto.AcquistoId", acquisto);
});
app.MapDelete("/acquisti/{clienteId}/{prodottoId}", async (VenditeDbContext db, int clienteId, int prodottoId) =>
{
    var acquisto = await db.Acquisti.FindAsync(clienteId, prodottoId);
    if (acquisto is null)
        return Results.NotFound();
    db.Remove(acquisto);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion

app.Run();
