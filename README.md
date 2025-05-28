🧠 Task Manager (Domain-Driven Backend)

A clean, backend-only task management system built using **ASP.NET Core** and **Entity Framework Core**, following **Domain-Driven Design (DDD)** principles.

Currently supports creating, updating, and managing tasks through a rich domain model, without a frontend interface.

---

🚀 Features

- Domain-driven task creation with validation rules
- Full encapsulation using rich domain model
- Task state transitions: update title, due date, and completion status
- Strict control via `Result<T>` pattern for success/failure logic
- Pure backend (no UI layer yet)

---

🛠 Tech Stack

- ASP.NET Core
- Entity Framework Core (Code-First)
- C#
- Clean/DDD Architecture

---

📁 Project Structure

```
TaskManager/
├── Domain/                 # Task entity and core domain logic
├── Application/            # Application services (use cases)
├── Infrastructure/         # Persistence layer (DbContext, repositories)
├── Presentation/           # Optional entry point for testing
└── README.md
```

---

🧱 Domain Model

`TaskType.cs`

```csharp
public class TaskType : Entity<Guid>
{
    public string Title { get; private set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; private set; }
    public DateTime DueDate { get; private set; }

    public static Result<TaskType> CreateTask(Guid taskId, string title, DateTime dueDate, string? description)
    { ... }

    public Result ChangeTitle(string? title) { ... }
    public Result ChangeIsCompleted(bool isCompleted) { ... }
    public Result ChangeDueDate(DateTime dueDate) { ... }
}
```

---

🧪 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/TaskManager.git
   ```

2. Apply the initial migration and create the database:
   ```bash
   dotnet ef database update
   ```

3. Run the project:
   ```bash
   dotnet run --project YourEntryPoint
   ```

> If you're using a test runner, you can invoke use-case tests directly instead of HTTP calls.

---

🎯 TODO / Future Enhancements

- Add API endpoints (REST or gRPC)
- Add user authentication
- Unit tests and integration tests
- Build a frontend (Blazor / React / MVC)

---

👤 Author

- Avin ([@Avin-Samadi](https://github.com/Avin-Samadi))
