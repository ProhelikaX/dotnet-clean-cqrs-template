using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CleanCQRS.API.Extensions;

public static class ProblemDetailsToJsonStringExtension
{
    public static string ToJson(this ProblemDetails problemDetails)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Serialize(problemDetails, options);
    }
}