namespace CleanCQRS.Application.Exceptions;

public class ForbiddenException : Exception

{
    public ForbiddenException() : base("You are not allowed to perform this operation")
    {
    }

    public ForbiddenException(string message) : base(message)
    {
    }

    public ForbiddenException(string message, Exception innerException) : base(message, innerException)
    {
    }
}