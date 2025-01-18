using System;

namespace TeslaACDC.Business.Interfaces
{
    public interface IMatematika
    {
        Task<float> SquareArea(float sideLength);
        Task<float> SumarValores(float valor1, float valor2);
    }
}
