using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record GetTaskDto(
        Guid TaskId,
        string Title,
        string Description,
        bool IsCompleted,
        DateTime DueDate
    );
}
