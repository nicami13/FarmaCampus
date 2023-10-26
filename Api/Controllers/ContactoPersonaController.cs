using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class ContactoPersonaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoPersona>>> Get()
        {
            var entidades = await _unitOfWork.ContactosPersonas.GetAllAsync();
            return _mapper.Map<List<ContactoPersona>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPersonaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.ContactosPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactoPersonaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoPersona>> Post(ContactoPersonaDto ContactoPersonaDto)
        {
            var entidad = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
            this._unitOfWork.ContactosPersonas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ContactoPersonaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ContactoPersonaDto.Id}, ContactoPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoPersonaDto>> Put(int id, [FromBody] ContactoPersonaDto ContactoPersonaDto)
        {
            if(ContactoPersonaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<ContactoPersona>(ContactoPersonaDto);
            _unitOfWork.ContactosPersonas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ContactoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.ContactosPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.ContactosPersonas.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }