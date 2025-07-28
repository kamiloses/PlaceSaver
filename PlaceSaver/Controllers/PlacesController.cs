using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PlaceSaver.Dto;
using PlaceSaver.Services.Impl;

namespace PlaceSaver.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlacesController : ControllerBase
{
    private readonly ExternalApiService _externalApiService;

//todo dodać sockety że ktoś w danym momencie własnie dodał do swojej listy zyczen dany zabytek itp
    public PlacesController(ExternalApiService externalApiService)
    {
        _externalApiService = externalApiService;
    }

    [HttpGet("search")]//todo zmien nazwe
    public async Task<ActionResult<List<PlaceDetailsResponse>>> GetPreviewPlaces(
        [FromQuery][Range(-90,90)] double latitude,
        [FromQuery][Range(-180, 180)]  double longitude,
        [FromQuery][Range(1, 50000)] int  radius,
        [FromQuery] string? type,
        [FromQuery] string? keyword,
        [FromQuery] bool? openNow)
    {
        
        
        var parameters = new PlaceSearchParameters { Latitude = latitude, Longitude = longitude, Radius = radius, Type = type, Keyword = keyword, OpenNow = openNow };
         
        var places = await _externalApiService.GetPreviewPlacesAsync(parameters);
        return Ok(places);
    }
}