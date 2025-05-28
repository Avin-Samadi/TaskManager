using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Presentation.Properties.Contracts;

namespace Presentation
{
    public class DeleteTask
    {
        public record DeleteTaskResponse(bool IsSuccess);

        public class DeleteTaskEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapDelete("api/tasks/{TaskId}", DeleteTaskHandlerAsync);
            }
        }

        public static async Task<IResult> DeleteTaskHandlerAsync(
            [FromServices] ITaskTypeManager manager,
            [FromRoute] Guid TaskId
        )
        {
            var result = await manager.DeleteTaskAsync(TaskId);

            if (result.IsSuccess)
                return TypedResults.Ok();
            else
                return TypedResults.NotFound(result.Error);
        }
    }
}
