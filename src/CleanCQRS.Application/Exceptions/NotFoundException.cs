namespace CleanCQRS.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base($"Requested resource not found.")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public NotFoundException(string resource, Guid id) : base($"{resource} with id {id} not found.")
    {
    }
}