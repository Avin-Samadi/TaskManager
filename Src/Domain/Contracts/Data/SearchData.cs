using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contracts.Data
{
    public record SearchData(string? SearchText, string? sort, int PageSiza, int PageIndex);
}
