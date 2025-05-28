using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dtos;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Presentation.Properties.Contracts;

namespace Presentation
{
    public class CreateTask
    {
        public record CreateTaskRequest(string Title, string Description, DateTime DueDate);

        public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
        {
            public CreateTaskValidator()
            {
                RuleFor(x => x.Title)
                    .NotEmpty()
                    .WithMessage("عنوان نباید خالی باشد.")
                    .MaximumLength(100)
                    .WithMessage("عنوان نباید بیشتر از 100 کاراکتر باشد.");

                RuleFor(x => x.Description)
                    .MaximumLength(1000)
                    .WithMessage("توضیحات نباید بیشتر از 1000 کاراکتر باشد.");

                RuleFor(x => x.DueDate)
                    .NotNull()
                    .WithMessage("تاریخ پایان الزامی است.")
                    .Must(date => date > DateTime.Now)
                    .WithMessage("تاریخ پایان باید بعد از تاریخ امروز باشد.");
            }
        }

        public record CreateTaskResponse(Guid TaskId);

        public class CreateTaskEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapPost("api/tasks", CreateTaskHandler);
            }
        }

        public static async Task<IResult> CreateTaskHandler(
            [FromServices] ITaskTypeManager TaskManager,
            [FromBody] CreateTaskRequest request,
            IValidator<CreateTaskRequest> validator
        )
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var dto = request.Adapt<CreateTaskDto>();
            var createTaskResult = await TaskManager.CreateTaskAsync(dto);

            if (createTaskResult.IsSuccess)
                return TypedResults.Ok(new CreateTaskResponse(createTaskResult.Value));
            else
                return TypedResults.BadRequest(createTaskResult.Error);
        }
    }
}
