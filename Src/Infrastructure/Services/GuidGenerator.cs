using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Application.Contracts;

namespace Infrastructure.Services
{
    public class GuidGenerator : IIdGenerator<Guid>
    {
        public Guid Next() => Guid.NewGuid();
    }
}