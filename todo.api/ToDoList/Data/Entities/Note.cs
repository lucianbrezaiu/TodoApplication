using System;
using ToDoList.Enum;

namespace ToDoList.Data.Entities
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;

        public Status Status { get; set; } = Status.Unchecked;
    }
}
