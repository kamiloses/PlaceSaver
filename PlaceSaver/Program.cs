using PlaceSaver.Services;
using PlaceSaver.Services.GoogleApi.Impl;
using PlaceSaver.Services.Impl;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<IGooglePlacesApiClient, GooglePlacesApiClient>();
builder.Services.AddScoped<IGooglePlacesUrlBuilder, GooglePlacesUrlBuilder>();
builder.Services.AddScoped<IGooglePlacesService, GooglePlacesService>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();