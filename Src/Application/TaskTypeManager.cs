using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dtos;
using Domain.Contracts.Data;
using Domain.ResultPattern;

namespace Application
{
    public class TaskTypeManager : ITaskTypeManager 
    {
        public Task<Result<Guid>> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteTaskAsync(Guid TaskId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<GetTaskDto>> GetTaskByIdAsync(Guid TaskId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PagedList<TaskDto>>> SearchTaskAsync(SearchTaskDto searchTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateTaskAsync(UpdateTaskDto updateTaskDto)
        {
            throw new NotImplementedException();
        }
    }
}