using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;



public interface IAlbumService
{
    Task<List<Album>> GetList();
    Task<List<Album>> AddAlbum();
}