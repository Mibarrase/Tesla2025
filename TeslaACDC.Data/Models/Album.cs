using System;

namespace TeslaACDC.Data.Models;

public class Album
{
    int _longitud = 0;
    public string Nombre{get; set;} = String.Empty;
    public int Anio{get;set;}
    public string Genero{get;set;} = String.Empty;

}
