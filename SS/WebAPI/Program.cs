using DAL;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddDbContext<SSDBContext>();

app.MapControllers();

app.Run();
