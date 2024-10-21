using esAPI2;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("testAPI"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/studenti", () => "Studenti");
app.MapPost("/studenti", () => "Studenti");
app.MapPut("/studenti", () => "Studenti");
app.MapDelete("/studenti", () => "Studenti");
app.MapPost("/todoitems",async(Todo todo, TodoDb db) =>
{

});
app.Run();