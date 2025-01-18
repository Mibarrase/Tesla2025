using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

public class AlbumService : IAlbumService
{
    public async Task<List<Album>> AddAlbum()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Album>> GetList()
    {
        Album album = new () 
        {
            Nombre = "All Eyez on Me",
            Genero = "Rap",
            Anio = 1996
        };
        return new List<Album>{album};
    }
}

    