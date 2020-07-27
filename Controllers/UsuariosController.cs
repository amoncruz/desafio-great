using System.Collections.Generic;
using AutoMapper;
using GreatDesafio.Dtos;
using GreatDesafio.Models;
using GreatDesafio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GreatDesafio.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //private readonly MockUsuarioRepository _repository = new MockUsuarioRepository();

        [HttpGet]
        public ActionResult <IEnumerable<UsuarioReadDto>> GetAllUsuarios()
        {
            var users = _repository.GetAllUsuarios();

            return Ok(_mapper.Map<IEnumerable<UsuarioReadDto>>(users));
        }

        [HttpGet("consulta/{name}")]
        public ActionResult <IEnumerable<UsuarioReadDto>> GetAllByName(string name)
        {
            var users = _repository.GetAllByName(name);

            return Ok(_mapper.Map<IEnumerable<UsuarioReadDto>>(users));
        }

        [HttpGet("{document}",Name="GetUsuarioByCpfOrRg")]
        public ActionResult <UsuarioReadDto> GetUsuarioByCpfOrRg(string document)
        
        {

            Usuario usuarioItem = null;

            if(document.Length==11){
                usuarioItem = _repository.GetUserByCpf(document);
            }else{
                usuarioItem = _repository.GetUserByRg(document);
            }

            if(usuarioItem!=null)
            {
                return Ok(_mapper.Map<UsuarioReadDto>(usuarioItem));
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult <UsuarioReadDto> CreateUser(UsuarioCreateDto usuarioDto)
        {
            var userModel = _mapper.Map<Usuario>(usuarioDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var usuarioReadDto = _mapper.Map<UsuarioReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUsuarioByCpfOrRg),new {document = usuarioReadDto.Id},usuarioReadDto);
            //return Ok(usuarioReadDto);
        }

        [HttpDelete("{document}")]
        public ActionResult DeleteByCpfOrRg(string document)
        {

            Usuario usuarioItem = null;

            if(document.Length==11){
                usuarioItem = _repository.GetUserByCpf(document);

                  if(usuarioItem == null)
                    {
                        return NotFound();
                    }

                _repository.DeleteUserByCpf(usuarioItem);
                _repository.SaveChanges();

            }else{
                usuarioItem = _repository.GetUserByRg(document);

                    if(usuarioItem == null)
                    {
                        return NotFound();
                    }

                _repository.DeleteUserByRg(usuarioItem);
                _repository.SaveChanges();
            }

            return NoContent();
        }
    }
}