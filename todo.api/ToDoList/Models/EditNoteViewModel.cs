using System;
using ToDoList.Enum;

namespace ToDoList.Models
{
    public class EditNoteViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }
    }
}
