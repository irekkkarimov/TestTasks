namespace AreaCalculatorTests.Utils;

public static class ExceptionMessages
{
    public const string NoShapeImplemented = "No shape was implemented";
    public const string NoParameters = "No parameters were received!";
    public const string OneSideLengthGreaterThanSumOfOthers = "One side's length is greater than the sum of others";
    public const string SideLengthIsLessThanOrEqualZero = "All sides should be greater than zero";
    public const string RadiusIsLessThanOrEqualZero = "Radius must be greater than zero";
    public const string TriangleCreationWithNotThreeArguments = "Triangle should have 3 sides!";
    public const string CircleCreationWithNotOneArgument = "Circle should have only radius";
}