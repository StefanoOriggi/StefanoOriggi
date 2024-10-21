var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Map("/", () => "Hello World");
app.Run();
