using AutoMapper;
using ToDoList.Models;
using ToDoList.Data.Entities;

namespace ToDoList.Services
{
    public class NoteMapper : Profile
    {
        public NoteMapper()
        {
            CreateMap<Note, NoteViewModel>()
                .ForMember(dest => dest.CreatedAt, src => src.MapFrom(opt => opt.CreatedAt.ToString("dd-MM-yyyy")));
        }
    }
}
