namespace AreaCalculator.Interfaces;

/// <summary>
/// Handler for calculating area of generic IShape
/// </summary>
public interface IAreaCalculatorGeneric
{
    /// <summary>
    /// Calculates area of generic IShape
    /// </summary>
    /// <param name="shape">Shape to calculate area</param>
    /// <returns>Area of the shape</returns>
    double CalculateArea(IShape shape);
}