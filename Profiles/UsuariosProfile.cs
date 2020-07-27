using AutoMapper;
using GreatDesafio.Dtos;
using GreatDesafio.Models;

namespace GreatDesafio.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario,UsuarioReadDto>();
            CreateMap<UsuarioCreateDto,Usuario>();
        }
    }
}