using AreaCalculatorTests.Utils;

namespace AreaCalculator.Shapes;

public class Circle : IShape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (ValidateCircle(radius) is (false, var errorMessage))
            throw new Exception(errorMessage);
        
        _radius = radius;
    }

    // Encapsulating field. Not necessary for double, but I wanted to make some standard
    public double Radius => _radius;

    private static (bool, string) ValidateCircle(double r)
    {
        return r <= 0 
            ? (false, ExceptionMessages.RadiusIsLessThanOrEqualZero)
            : (true, "");
    }
    
    public double CalculateArea()
    {
        var result = (Radius * Radius) * Math.PI;
        return result;
    }
}