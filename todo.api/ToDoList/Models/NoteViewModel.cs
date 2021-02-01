using System;
using ToDoList.Enum;

namespace ToDoList.Models
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatedAt { get; set; }

        public Status Status { get; set; }
    }
}
