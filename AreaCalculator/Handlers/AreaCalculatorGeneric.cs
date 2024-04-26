using AreaCalculator.Interfaces;
using AreaCalculator.Shapes;

namespace AreaCalculator.Handlers;

/// <inheritdoc cref="IAreaCalculatorGeneric"/> 
public class AreaCalculatorGeneric : IAreaCalculatorGeneric
{
    public double CalculateArea(IShape shape)
    {
        return shape.CalculateArea();
    }
}