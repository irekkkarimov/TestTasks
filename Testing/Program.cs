using AreaCalculator.Shapes;

namespace Testing;

public static class Program
{
    public static void Main(string[] args)
    {
        var triangle = new Triangle(40, 41, 9);

        Console.WriteLine(triangle.CalculateArea());
    }
}