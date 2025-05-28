using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Properties.Contracts
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder builder);
    }
}