using AreaCalculator.Handlers;
using AreaCalculator.Shapes;

namespace AreaCalculatorTests.CalculationTests;

public class ShapesCalculationTests
{
    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(40, 41, 9, 180)]
    [InlineData(3.5, 4.5, 2, 3.35)]
    public void TriangleAreaCalculatorWorksCorrectly(double a, double b, double c, double actualArea)
    {
        // Arrange
        var triangle = new Triangle(a, b, c);

        // Act
        var triangleArea = triangle.CalculateArea();
        
        // Assert
        Assert.True(Math.Abs(triangleArea - actualArea) < 0.1);
    }
    
    [Theory]
    [InlineData(5, 78.54)]
    [InlineData(10, 314.16)]
    [InlineData(97, 29559.25)]
    public void CircleAreCalculatorWorksCorrectly(double r, double actualArea)
    {
        // Arrange
        var circle = new Circle(r);
        
        // Act
        var circleArea = circle.CalculateArea();
        
        // Assert
        Assert.True(Math.Abs(circleArea - actualArea) < 0.1);
    }

    [Theory]
    [InlineData(new double[] { 10 }, 314.16)]
    [InlineData(new double[] { 40, 41, 9 }, 180)]
    public void AreaCalculatorGenericWorksCorrectly(double[] args, double actualArea)
    {
        // Arrange, Act
        var area = AreaCalculatorGeneric.CalculateArea(args);

        // Assert
        Assert.True(Math.Abs(area - actualArea) < 0.1);
    }

    [Theory]
    [InlineData(new double[] { 40, 41, 9 }, 180)]
    public void AreaCalculatorGenericIShapeWorksCorrectlyWithTriangle(double[] args, double actualArea)
    {
        // Arrange
        var triangle = new Triangle(args);
        
        // Act
        var area = AreaCalculatorGeneric.CalculateArea(triangle);
        
        // Assert
        Assert.True(Math.Abs(area - actualArea) < 0.1);
    }
    
    [Theory]
    [InlineData(new double[] { 10 }, 314.16)]
    public void AreaCalculatorGenericIShapeWorksCorrectlyWithCircle(double[] args, double actualArea)
    {
        // Arrange
        var circle = new Circle(args);
        
        // Act
        var area = AreaCalculatorGeneric.CalculateArea(circle);
        
        // Assert
        Assert.True(Math.Abs(area - actualArea) < 0.1);
    }
    
}