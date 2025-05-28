using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace Infrastructure.Data
{
    public class TaskTypeRepository(TaskManagerContext context)
        : SqlRepository<TaskType, Guid>(context),
            ITaskTypeRepository { }
}
