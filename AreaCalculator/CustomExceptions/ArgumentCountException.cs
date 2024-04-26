using AreaCalculator.CustomExceptions.Abstractions;

namespace AreaCalculator.CustomExceptions;

public class ArgumentCountException : ShapeException
{
    public ArgumentCountException(string message) : base(message)
    {
    }
}