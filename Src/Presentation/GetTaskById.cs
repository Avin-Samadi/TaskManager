using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Presentation.Properties.Contracts;

namespace Presentation
{
    public class GetTaskById
    {
        public record GetTaskByIdResponse(
            Guid Id,
            string Title,
            string Description,
            DateTime DueDate,
            bool IsCompleted
        );

        public class GetTaskByIdEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapGet("api/tasks/{TaskId}", GetTaskByIdHandler);
            }
        }

        public static async Task<IResult> GetTaskByIdHandler(
            [FromServices] ITaskTypeManager taskManager,
            [FromRoute] Guid TaskId
        )
        {
            var result = await taskManager.GetTaskByIdAsync(TaskId);

            if (!result.IsSuccess)
                return TypedResults.NotFound(result.Error);

            var getTaskDto = result.Value;

            var response = getTaskDto.Adapt<GetTaskByIdResponse>();
            return TypedResults.Ok(response);
        }
    }
}
