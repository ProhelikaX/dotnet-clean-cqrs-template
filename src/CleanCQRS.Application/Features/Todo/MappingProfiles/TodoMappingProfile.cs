using AutoMapper;
using CleanCQRS.Application.Features.Todo.Commands;
using CleanCQRS.Application.Features.Todo.Responses;

namespace CleanCQRS.Application.Features.Todo.MappingProfiles;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile()
    {
        CreateMap<CreateTodoCommand, Domain.Entities.Todo>();
        CreateMap<UpdateTodoCommand, Domain.Entities.Todo>();

        CreateMap<Domain.Entities.Todo, TodoResponse>();
    }
}