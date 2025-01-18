namespace TeslaACDC.Controllers;

using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class TeslaController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public TeslaController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    [Route("GetAlbum")]
    public async Task<IActionResult> GetAlbum()
    {
        var lista = await _albumService.GetList();
        return Ok(lista);
    }

    [HttpPost]
    [Route("ReciboValor")]
    public async Task<IActionResult> ReciboValor(Album album)
    {
        return Ok($"Mi nombre es: {album.Nombre}");
    }

    [HttpPost]
    [Route("ReciboUnValor")]
    public async Task<IActionResult> ReciboUnValor([FromBody] string album)
    {
        return Ok(album);
    }

    [HttpGet]
    [Route("ListAlbums")]
    public async Task<IActionResult> GetStaticAlbumList()
    {
        var listaAlbums = new List<Album>
        {
            new Album {Nombre = "The Heist", Anio = 2012, Genero = "Rap"},
            new Album {Nombre = "Thriller", Anio = 1982, Genero = "Pop"},
            new Album {Nombre = "Encore", Anio = 2004, Genero = "Rap"}
        };

        return Ok(listaAlbums);
    }

    [HttpPost]
    [Route("Sum")]
    public async Task<IActionResult> SumarValores([FromBody] SumaRequest request)
    {
        var resultado = request.Valor1 + request.Valor2;
        return Ok($"El resultado de la suma es: {resultado}");
    }

    [HttpPost]
    [Route("AreaCuadrado")]
    public async Task<IActionResult> SquareArea([FromBody] float sideLength)
    {
        if (sideLength <= 0)
        {
            return BadRequest("El lado del cuadrado debe ser mayor que cero.");
        }

        var area = Math.Pow(sideLength, 2);
        return Ok($"El área del cuadrado es: {area}");
    }

    [HttpPost]
    [Route("AreaTriangulo")]
    public async Task<IActionResult> TriangleArea([FromBody] TriangleRequest request)
    {
        if (request.Base <= 0 || request.Height <= 0)
        {
        return BadRequest("La base y la altura deben ser mayores que cero.");
        }

        var area = (request.Base * request.Height) / 2;
        return Ok($"El área del triángulo es: {area}");
    }

    [HttpPost]
    [Route("AreaCuadradoLados")]
    public async Task<IActionResult> SquareAreaAllSides([FromBody] SquareRequest request)
    {
        if (request.Side1 <= 0 || request.Side2 <= 0 || request.Side3 <= 0 || request.Side4 <= 0)
            {
            return BadRequest("Todos los lados deben ser mayores que cero.");
            }

        if (request.Side1 != request.Side2 || request.Side1 != request.Side3 || request.Side1 != request.Side4)
            {
            return BadRequest("Todos los lados deben ser iguales para calcular el área de un cuadrado.");
            }

    var area = Math.Pow(request.Side1, 2);
    return Ok($"El área del cuadrado es: {area}");
}
}
