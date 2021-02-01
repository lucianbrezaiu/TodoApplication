using System;
using AutoMapper;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.Data.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => Ok(await _noteService.Get());

        [HttpGet("{id}", Name="GetNote")]
        public async Task<IActionResult> Get(Guid id) => Ok(_mapper.Map<NoteViewModel>(await _noteService.Get(id)));

        [HttpPost]
        public async Task<IActionResult> Add(Note note)
        {
            var newNote = await _noteService.Add(note);
            return await Get(newNote.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {

            await _noteService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditNoteViewModel note)
        {
            await _noteService.Edit(note);
            return await Get(note.Id);
        }
    }
}
