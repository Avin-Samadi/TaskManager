using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ResultPattern;

namespace Domain
{
    public class TaskType : Entity<Guid>
    {
        private TaskType(Guid id)
            : base(id) { }

        public string Title { get; private set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; private set; }
        public DateTime DueDate { get; private set; }

        public static Result<TaskType> CreateTask(
            Guid taskId,
            string title,
            DateTime dueDate,
            string? description = default
        )
        {
            if (!ValidateTitle(title))
            {
                return Result.Failure<TaskType>(
                    Error.Failure("TaskType:CreateTask", "title is null")
                );
            }

            if (ValidateDueDate(dueDate))
            {
                return Result.Failure<TaskType>(
                    Error.Failure("TaskType:CreateTask", "dueDate is invalid")
                );
            }

            return new TaskType(taskId)
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
            };
        }

        private static bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;
            else
                return true;
        }

        private static bool ValidateDueDate(DateTime dueDate)
        {
            if (dueDate == DateTime.MinValue || dueDate < DateTime.Today)
                return false;
            else
                return true;
        }

        public Result ChangeTitle(string title)
        {
            if (IsCompleted || !ValidateTitle(title))
                return Result.Failure(Error.Failure("TaskType:ChangeTitle", "title is invalid"));
            else
            {
                Title = title;
                return Result.Success();
            }
        }

        public Result ChangeIsCompleted(bool isCompleted)
        {
            if (DueDate < DateTime.Today)
                return Result.Failure(Error.Failure("TaskType:ChangeIsCompleted", "time is over"));
            else
            {
                IsCompleted = isCompleted;
                return Result.Success();
            }
        }

        public Result ChangeDueDate(DateTime dueDate)
        {
            if (IsCompleted || !ValidateDueDate(dueDate))
                return Result.Failure(Error.Failure("TaskType:ChangeIsCompleted", "time is over"));
            else
            {
                DueDate = dueDate;
                return Result.Success();
            }
        }
    }
}
