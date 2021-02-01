using System;
using ToDoList.Data;
using ToDoList.Data.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using ToDoList.Enum;

namespace ToDoList.Services
{
    public class NoteService : INoteService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public NoteService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Note> Get(Guid id)
        {
            using var scope = TransactionFactory.New();

            var note = await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);

            scope.Complete();

            return note;
        }

        public async Task<Note> Add(Note note)
        {
            using var scope = TransactionFactory.New();

            _context.Notes.Add(note);

            await _context.SaveChangesAsync();

            scope.Complete();

            return note;
        }

        public async Task Delete(Guid id)
        {
            using var scope = TransactionFactory.New();

            var note = await Get(id);
            if(note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }

            scope.Complete();
        }

        public async Task Edit(EditNoteViewModel note)
        {
            using var scope = TransactionFactory.New();

            var noteFromDatabase = await Get(note.Id);
            noteFromDatabase.Title = note.Title;
            noteFromDatabase.Description = note.Description;
            noteFromDatabase.Status = (Status)note.Status;
            noteFromDatabase.UpdatedAt = DateTimeOffset.Now;

            _context.Notes.Update(noteFromDatabase);

            await _context.SaveChangesAsync();

            scope.Complete();
        }

        public async Task<List<NoteViewModel>> Get()
        {
            using var scope = TransactionFactory.New();
            
            var notes = await _context
                .Notes
                .ProjectTo<NoteViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            scope.Complete();

            return notes;
        }

    }
}
