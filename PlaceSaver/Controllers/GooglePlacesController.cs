using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PlaceSaver.Dto;
using PlaceSaver.Services;
using PlaceSaver.Services.Impl;

namespace PlaceSaver.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GooglePlacesController : ControllerBase
{
    private readonly IGooglePlacesService _googlePlacesService;

//todo dodać sockety że ktoś w danym momencie własnie dodał do swojej listy zyczen dany zabytek itp
public GooglePlacesController(IGooglePlacesService googlePlacesService)
{
    _googlePlacesService = googlePlacesService;
}


[HttpGet("search")]
    public async Task<ActionResult<List<PlaceDetailsResponse>>> SearchPlacesAsync(
        [FromQuery][Range(-90,90)] double latitude,
        [FromQuery][Range(-180, 180)]  double longitude,
        [FromQuery][Range(1, 50000)] int  radius,
        [FromQuery] string? type,
        [FromQuery] string? keyword,
        [FromQuery] bool? openNow)
    {
        
        
        var parameters = new PlaceSearchParameters { Latitude = latitude, Longitude = longitude, Radius = radius, Type = type, Keyword = keyword, OpenNow = openNow };
         
        var places = await _googlePlacesService.GetPlacesAsync(parameters);
        return Ok(places);
    }
}