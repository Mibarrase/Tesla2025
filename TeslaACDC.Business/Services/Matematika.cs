using System;
using TeslaACDC.Business.Interfaces;

public class Matematika : IMatematika
{
    public async Task<float> SquareArea(float sideLength)
    {
        // Lógica para calcular el área del cuadrado
        return await Task.FromResult(sideLength * sideLength);
    }

    public async Task<float> SumarValores(float valor1, float valor2)
    {
        // Lógica para sumar valores
        return await Task.FromResult(valor1 + valor2);
    }
}
