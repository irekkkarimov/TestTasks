using System.Collections.Immutable;

namespace AreaCalculator.Shapes;

public class Triangle : IShape
{
    private readonly double[] _sides;

    // Constructor for initializing using an argument for each side
    public Triangle(double side1, double side2, double side3)
    {
        var sides = new[] { side1, side2, side3 };
        
        // Checking if the sides lengths meet the requirements for being triangle
        if (ValidateTriangle(sides) is (false, var errorMessage))
            throw new ArgumentException(errorMessage);

        _sides = sides;
    }

    // Constructor for initializing using an array of sides
    public Triangle(double[] sides)
    {
        // Checking if it's triangle
        if (sides.Length != 3)
            throw new Exception("Triangle should have 3 sides!");

        // Checking if the sides lengths meet the requirements for being triangle
        if (ValidateTriangle(sides) is (false, var errorMessage))
            throw new Exception(errorMessage);

        _sides = sides;
    }

    // Returning sides array as immutable array not to let it be changed
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