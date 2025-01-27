using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;



public interface IAlbumService
{
    Task<BaseMessage<Album>> GetList();
    Task<BaseMessage<Album>> AddAlbum();
    Task<BaseMessage<Album>> FindById(int id);
    Task<BaseMessage<Album>> FindByName(string name);
    Task<BaseMessage<Album>> EditAlbum(int id, Album updatedAlbum); 
    Task<BaseMessage<Album>> DeleteAlbum(int id); 
    Task<BaseMessage<Album>> FindByArtist(int artistId); 
}