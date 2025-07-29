using PlaceSaver.Services;
using PlaceSaver.Services.Impl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IGooglePlacesService, GooglePlacesService>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();