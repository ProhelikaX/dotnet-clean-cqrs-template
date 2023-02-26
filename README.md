# Clean CQRS

This is a .NET solution template using Clean Architecture and CQRS.

## What is Clean Architecture?

Clean Architecture is a software design approach that separates the elements of a design into ring levels. Each level has a specific purpose and cannot access the elements in the inner circle. This approach helps to keep the design loosely coupled and thus easier to maintain.

## What is CQRS?

CQRS stands for Command Query Responsibility Segregation. It is a pattern that separates read and write operations for a data store. This pattern helps to keep the design simple and thus easier to maintain.

## How to use this template?

1. Clone this repository
2. cd into the directory
3. Run `dotnet new -i .`
4. Run `dotnet new clean-cqrs -o <your-project-name> --title <your-project-title>`