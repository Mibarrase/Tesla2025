using Microsoft.VisualBasic;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace TeslaACDC.Business.Services;

public class AlbumService : IAlbumService
{
    private List<Album> _listaAlbum = new();

    public AlbumService()
    {
        _listaAlbum.Add(new (){Name = "The Heist", Genre = Genre.Rap, Year = 2012, Id = 1, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "Thriller", Genre = Genre.Pop, Year = 1982, Id = 2, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "Encore", Genre = Genre.Rap, Year = 2004, Id = 3, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "All Eyez on Me", Genre = Genre.Rap, Year = 1996, Id = 4, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "2001", Genre = Genre.Rap, Year = 1999, Id = 5, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "Bad", Genre = Genre.Pop, Year = 1987, Id = 6, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "The Chronic", Genre = Genre.Rap, Year = 1992, Id = 0, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "The Marshall Mathers LP", Genre = Genre.Rap, Year = 2000, Id = 0, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "The Eminem Show", Genre = Genre.Rap, Year = 2002, Id = 0, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "Doggystyle", Genre = Genre.GFunk, Year = 1993, Id = 0, ArtistId = 0});
        _listaAlbum.Add(new (){Name = "Ready to Die", Genre = Genre.Rap, Year = 1994, Id = 0, ArtistId = 0});        
    }

    public async Task<BaseMessage<Album>> AddAlbum()
    {
        try{
            _listaAlbum.Add(new (){Name = "Encore", Genre = Genre.Rap, Year = 2044, Id = 3});
        }catch{
            return new BaseMessage<Album>() {
                Message = "",
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                TotalElements = 0,
                ResponseElements = new ()
            };
        }
        
        
        return new BaseMessage<Album>() {
            Message = "",
            StatusCode = System.Net.HttpStatusCode.OK,
            TotalElements = _listaAlbum.Count,
            ResponseElements = _listaAlbum
        };
        
    }

    public async Task<BaseMessage<Album>> FindById(int id)
    {

        var lista = _listaAlbum.Where(x => x.Id == id).ToList();
        
        return lista.Any() ?  BuildResponse(lista, "", HttpStatusCode.OK, lista.Count) : 
            BuildResponse(lista, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> FindByName(string name)
    {
        var lista = _listaAlbum.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
        // x.Name.Include(name.ToLower())
        
        return lista.Any() ?  BuildResponse(lista, "", HttpStatusCode.OK, lista.Count) : 
            BuildResponse(lista, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> GetList()
    {
        return new BaseMessage<Album>() {
            Message = "",
            StatusCode = System.Net.HttpStatusCode.OK,
            TotalElements = _listaAlbum.Count,
            ResponseElements = _listaAlbum
        };
    }

    private BaseMessage<Album> BuildResponse(List<Album> lista, string message = "", HttpStatusCode status = HttpStatusCode.OK, 
        int totalElements = 0)
    {
        return new BaseMessage<Album>(){
            Message = message,
            StatusCode = status,
            TotalElements = totalElements,
            ResponseElements = lista
        };
    }

   public async Task<BaseMessage<Album>> EditAlbum(int id, Album updatedAlbum)
{
    var album = _listaAlbum.FirstOrDefault(x => x.Id == id);
    if (album == null)
    {
        return BuildResponse(new List<Album>(), "Álbum no encontrado", HttpStatusCode.NotFound, 0);
    }

    album.Name = updatedAlbum.Name;
    album.Genre = updatedAlbum.Genre;
    album.Year = updatedAlbum.Year;
    album.ArtistId = updatedAlbum.ArtistId;

    return BuildResponse(new List<Album> { album }, "Álbum actualizado correctamente", HttpStatusCode.OK, 1);
}

public async Task<BaseMessage<Album>> DeleteAlbum(int id)
{
    var album = _listaAlbum.FirstOrDefault(x => x.Id == id);
    if (album == null)
    {
        return BuildResponse(new List<Album>(), "Álbum no encontrado", HttpStatusCode.NotFound, 0);
    }

    _listaAlbum.Remove(album);

    return BuildResponse(new List<Album>(), "Álbum eliminado correctamente", HttpStatusCode.OK, 0);
}

public async Task<BaseMessage<Album>> FindByArtist(int artistId)
{
    var lista = _listaAlbum.Where(x => x.ArtistId == artistId).ToList();

    return lista.Any()
        ? BuildResponse(lista, "Álbumes encontrados", HttpStatusCode.OK, lista.Count)
        : BuildResponse(new List<Album>(), "No se encontraron álbumes para el artista", HttpStatusCode.NotFound, 0);
}

}