using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Properties.Contracts;

namespace Presentation
{
    public class GetAllTasks
    {
        public record GetAllTasksResponse(List<GetTaskDto> Tasks);

        public class GetAllTasksEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder.MapGet("api/tasks", GetAllTasksHandler);
            }
        }

        public static async Task<IResult> GetAllTasksHandler(
            [FromServices] ITaskTypeManager manager
        )
        {
            var result = await manager.GetAllTasksAsync();

            if (result.IsSuccess)
                return TypedResults.Ok(new GetAllTasksResponse(result.Value));
            else
                return TypedResults.BadRequest(result.Error);
        }
    }
}
