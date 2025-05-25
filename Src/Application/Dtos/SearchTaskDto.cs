using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record SearchTaskDto(string? SearchText, string? Sort, int PageIndex, int PageSize);
}
