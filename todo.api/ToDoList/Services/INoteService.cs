using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface INoteService
    {
        Task<Note> Get(Guid id);

        Task<Note> Add(Note note);

        Task Edit(EditNoteViewModel note);

        Task Delete(Guid id);

        Task<List<NoteViewModel>> Get();

    }
}
