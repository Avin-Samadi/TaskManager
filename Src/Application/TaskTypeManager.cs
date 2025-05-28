using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dtos;
using Domain;
using Domain.Contracts;
using Domain.Contracts.Data;
using Domain.ResultPattern;
using Mapster;

namespace Application
{
    public class TaskTypeManager(ITaskTypeRepository repository, IIdGenerator<Guid> idGenerator)
        : ITaskTypeManager
    {
        public async Task<Result<Guid>> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            var tasktId = idGenerator.Next();

            var createResult = TaskType.CreateTask(
                tasktId,
                createTaskDto.Title,
                createTaskDto.DueDate,
                createTaskDto.Description
            );
            if (createResult.IsFailure)
                return Result.Failure<Guid>(createResult.Error);

            await repository.InsertAsync(createResult.Value);

            return tasktId;
        }

        public async Task<Result> DeleteTaskAsync(Guid TaskId)
        {
            var task = await repository.GetByIdAsync(TaskId);
            if (task == null)
                return Result.Failure(
                    Error.NotFound("TaskTypeManager: DeleteTaskAsync", "taskId is not valid")
                );

            await repository.DeleteAsync(task);

            return Result.Success();
        }

        public async Task<Result<GetTaskDto>> GetTaskByIdAsync(Guid TaskId)
        {
            var task = await repository.GetByIdAsync(TaskId);
            if (task == null)
                return Result.Failure<GetTaskDto>(
                    Error.NotFound("TaskTypeManager: GetTaskByIdAsync", "taskId is not valid")
                );

            var dto = task.Adapt<GetTaskDto>();
            return Result.Success(dto);
        }

        public async Task<Result<List<GetTaskDto>>> GetAllTasksAsync()
        {
            var tasks = await repository.GetAllAsync();
            var dtos = tasks.Adapt<List<GetTaskDto>>();
            return Result.Success(dtos);
        }

        public async Task<Result> UpdateTaskAsync(UpdateTaskDto updateTaskDto)
        {
            var task = await repository.GetByIdAsync(updateTaskDto.TaskId);
            if (task == null)
                return Result.Failure(Error.NotFound("", ""));

            // به‌روزرسانی مقادیر
            task.ChangeTitle(updateTaskDto.Title);
            task.ChangeDueDate(updateTaskDto.DueDate);
            task.ChangeIsCompleted(Convert.ToBoolean(updateTaskDto.IsCompleted));

            await repository.UpdateAsync(task);

            return Result.Success();
        }
    }
}
