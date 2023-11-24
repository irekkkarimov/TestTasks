using AreaCalculator.Shapes;

namespace AreaCalculator.Handlers;

public class AreaCalculatorGeneric
{
    public static double CalculateArea(params double[] args)
    {
        switch (args.Length)
        {
            case 0:
            {
                throw new Exception("No parameters were received!");
            }
            case 1:
            {
                var circle = new Circle(args[0]);
                return circle.CalculateArea();
            }
            case 3:
            {
                var triangle = new Triangle(args);
                return triangle.CalculateArea();
            }
            default:
            {
                    throw new Exception("No shape was implemented");
            }
        }
    }

    public static double CalculateArea(IShape shape)
    {
        return shape.CalculateArea();
    }
}