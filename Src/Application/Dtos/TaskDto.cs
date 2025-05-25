using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record TaskDto(string Title, bool IsCompleted, DateTime DueDate);
}
