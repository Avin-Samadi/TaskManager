using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record UpdateTaskDto(
        Guid TaskId,
        string? Title,
        string? Description,
        string IsCompleted,
        DateTime DueDate
    );
}
