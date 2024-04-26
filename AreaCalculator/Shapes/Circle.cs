using AreaCalculator.CustomExceptions;
using AreaCalculator.CustomExceptions.Messages;
using AreaCalculator.Interfaces;

namespace AreaCalculator.Shapes;

/// <summary>
/// Circle shape
/// </summary>
/// <inheritdoc cref="IShape"/>
public class Circle : IShape
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="radius">The radius of the circle</param>
    /// <exception cref="ArgumentValidationException">
    /// Arguments were not validated successfully when creating instance</exception>
    public Circle(double radius)
    {
        // Checking if the radius meets the requirements for being circle
        if (ValidateCircle(radius) is (false, var errorMessage))
            throw new ArgumentValidationException(errorMessage);
        
        Radius = radius;
    }

    /// <summary>
    /// Radius of the circle
    /// </summary>
    public double Radius { get; }
    
    
    private static (bool, string) ValidateCircle(double r)
    {
        return r <= 0 
            ? (false, ShapeExceptionMessages.RadiusIsLessThanOrEqualZero)
            : (true, "");
    }
    
    public double CalculateArea()
    {
        var result = (Radius * Radius) * Math.PI;
        return result;
    }
}