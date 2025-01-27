using System;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;
public interface IMatematika
{
    Task<float> Sum(float sumando, float sumando_2);
    Task<BaseMessage<string>> Divide(float sideLenght);
    Task<float> SquareArea(float sideLenghtA, float sideLenghtB, float sideLenghtC, float sideLenghtD);
    Task<float> Multiply(float factora, float factorb);
}
