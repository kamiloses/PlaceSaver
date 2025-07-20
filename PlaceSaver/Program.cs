using PlaceSaver.Services.Impl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<ExternalApiService>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();