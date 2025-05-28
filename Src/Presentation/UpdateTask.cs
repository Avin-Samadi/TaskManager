using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dtos;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Presentation.Properties.Contracts;

namespace Presentation
{
    public class UpdateTask
    {
        public record UpdateTaskRequest(
            string Title,
            string Description,
            DateTime DueDate,
            bool IsCompleted
        );

        public class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
        {
            public UpdateTaskValidator()
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
                    .WithMessage("تاریخ پایان باید بعد از امروز باشد.");
            }
        }

        public record UpdateTaskResponse(bool IsSuccess);

        public class UpdateTaskEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapPut("api/tasks/{TaskId}", UpdateTaskHandler);
            }
        }

        public static async Task<IResult> UpdateTaskHandler(
            IValidator<UpdateTaskRequest> validator,
            [FromServices] ITaskTypeManager manager,
            [FromBody] UpdateTaskRequest request,
            [FromRoute] Guid TaskId
        )
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var dto = request.Adapt<UpdateTaskDto>() with { TaskId = TaskId };

            var result = await manager.UpdateTaskAsync(dto);

            if (result.IsSuccess)
                return TypedResults.Ok();
            else
                return TypedResults.BadRequest(result.Error);
        }
    }
}
