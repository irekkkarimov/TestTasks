using System.Collections.Immutable;
using AreaCalculator.CustomExceptions;
using AreaCalculator.Interfaces;

namespace AreaCalculator.Shapes;

/// <summary>
/// Triangle shape
/// </summary>
/// <inheritdoc cref="IShape"/>
public class Triangle : IShape
{
    private readonly double[] _sides;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="side1">First side of the triangle</param>
    /// <param name="side2">Second side of the triangle</param>
    /// <param name="side3">Third side of the triangle</param>
    /// <exception cref="ArgumentValidationException">
    /// Arguments were not validated successfully when creating instance</exception>
    public Triangle(double side1, double side2, double side3)
    {
        var sides = new[] { side1, side2, side3 };
        
        // Checking if the sides lengths meet the requirements for being triangle
        if (ValidateTriangle(sides) is (false, var errorMessage))
            throw new ArgumentValidationException(errorMessage);

        _sides = sides;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sides">Sides of the triangle (Length = 3)</param>
    /// <exception cref="ArgumentCountException">Arguments count were not correct (Must be 3)</exception>
    /// <exception cref="ArgumentValidationException">
    /// Arguments were not validated successfully when creating instance</exception>
    public Triangle(double[] sides)
    {
        // Checking if it's triangle
        if (sides.Length != 3)
            throw new ArgumentCountException("Triangle should have 3 sides!");

        // Checking if the sides lengths meet the requirements for being triangle
        if (ValidateTriangle(sides) is (false, var errorMessage))
            throw new ArgumentValidationException(errorMessage);

        _sides = sides;
    }

    /// <summary>
    /// Sides of the triangle (Immutable)
    /// </summary>
    public ImmutableArray<double> Sides => _sides.ToImmutableArray();

    private static (bool, string) ValidateTriangle(double[] sides)
    {
        // Making sure that all sides are greater than zero
        if (sides.Any(i => i <= 0))
            return (false, "All sides should be greater than zero");
        
        foreach (var side in sides)
        {
            var sumOfOtherSides = sides.Sum() - side;
            
            // If the current side's length is greater or equal than other sides in sum, then returning false
            if (side >= sumOfOtherSides)
                return (false, "One side's length is greater than the sum of others");
        }
        
        // Otherwise returning true
        return (true, "");
    }
    
    public double CalculateArea()
    {
        // Naming all sides for convenience
        var a = Sides[0];
        var b = Sides[1];
        var c = Sides[2];
        
        // Calculating half perimeter
        var halfPerimeter = Sides.Sum() / 2;
        
        // Calculating the area using Heron's formula
        var result = Math.Sqrt(
            halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

        // Returning result
        return result;
    }

    /// <summary>
    /// Checks if the triangle is right (Has 90 degree angle)
    /// </summary>
    /// <returns>Is triangle right</returns>
    public bool CheckIfTriangleIsRight()
    {
        var area = CalculateArea();

        foreach (var side in Sides)
        {
            var multiplication = Sides.Aggregate((i, e) => i * e);
            
            // To calculate area in right triangle you should multiply lengths of two sides laying next to right angle
            var mightBeArea = multiplication / (side * 2);
            if (Math.Sqrt(area - mightBeArea) < 0.01)
                return true;
        }

        return false;
    }
}