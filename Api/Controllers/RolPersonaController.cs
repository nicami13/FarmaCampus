using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class RolPersonaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolPersona>>> Get()
        {
            var entidades = await _unitOfWork.RolesPersonas.GetAllAsync();
            return _mapper.Map<List<RolPersona>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolPersonaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.RolesPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<RolPersonaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolPersona>> Post(RolPersonaDto RolPersonaDto)
        {
            var entidad = _mapper.Map<RolPersona>(RolPersonaDto);
            this._unitOfWork.RolesPersonas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            RolPersonaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = RolPersonaDto.Id}, RolPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolPersonaDto>> Put(int id, [FromBody] RolPersonaDto RolPersonaDto)
        {
            if(RolPersonaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<RolPersona>(RolPersonaDto);
            _unitOfWork.RolesPersonas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return RolPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.RolesPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.RolesPersonas.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }