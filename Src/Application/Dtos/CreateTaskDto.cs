using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record CreateTaskDto(string Title, string? Description, DateTime DueDate);
}
