using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Domain;
using Domain.Contracts.Data;
using Domain.ResultPattern;

namespace Application.Contracts
{
    public interface ITaskTypeManager
    {
        Task<Result<Guid>> CreateTaskAsync(CreateTaskDto createTaskDto);
        Task<Result> UpdateTaskAsync(UpdateTaskDto updateTaskDto);
        Task<Result> DeleteTaskAsync(Guid TaskId);
        Task<Result<GetTaskDto>> GetTaskByIdAsync(Guid TaskId);
        Task<Result<List<GetTaskDto>>> GetAllTasksAsync();
    }
}
