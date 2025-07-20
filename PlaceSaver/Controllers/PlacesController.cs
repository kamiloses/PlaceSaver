using Microsoft.AspNetCore.Mvc;
using PlaceSaver.Dto;
using PlaceSaver.Dtos;
using PlaceSaver.Services.Impl;

namespace PlaceSaver.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlacesController : ControllerBase
{
    private readonly ExternalApiService _externalApiService;


    public PlacesController(ExternalApiService externalApiService)
    {
        _externalApiService = externalApiService;
    }

    [HttpGet("preview")]//handler ktory wskazuje ze parametry niepoprawne czy cos
    public async Task<ActionResult<List<PlacePreviewResponse>>> GetPreviewPlaces(
        [FromQuery] double latitude,
        [FromQuery] double longitude,
        [FromQuery] int  radius,
        [FromQuery] string? type,
        [FromQuery] string? keyword,
        [FromQuery] bool? openNow)
    {
        
        Console.Write("a " +type );
        
        var parameters = new PlaceSearchParameters { Latitude = latitude, Longitude = longitude, Radius = radius, Type = type, Keyword = keyword, OpenNow = openNow };
         
        var places = await _externalApiService.getPreviewPlacesAsync(parameters);
        return Ok(places);
    }
}