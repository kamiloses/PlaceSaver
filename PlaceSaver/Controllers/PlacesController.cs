using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("preview")]
    public async Task<ActionResult<List<PlacePreviewResponse>>> GetPreviewPlaces()
    {
        var places = await _externalApiService.getPreviewPlacesAsync();
        return Ok(places);
    }
}