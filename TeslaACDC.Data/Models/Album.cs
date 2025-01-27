using System;

namespace TeslaACDC.Data.Models;

public class Album : BaseEntity<int>
{
    public string Name{get; set;} = String.Empty;
    public int Year{get;set;}
    public Genre Genre{get;set;} = Genre.Unknown;
    public int ArtistId{get;set;}
    

}

public enum Genre
{
    Pop,
    Rock,
    Metal,
    Salsa,
    Urban,
    Folklore,
    Indie,
    Electronica,
    Vallenato,
    Tropipop,
    World,
    Rap,
    GFunk,
    Unknown    
}