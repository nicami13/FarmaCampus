using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoPersonaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoPersona>>> Get()
        {
            var entidades = await _unitOfWork.TiposPersonas.GetAllAsync();
            return _mapper.Map<List<TipoPersona>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.TiposPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoPersonaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var entidad = _mapper.Map<TipoPersona>(TipoPersonaDto);
            this._unitOfWork.TiposPersonas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            TipoPersonaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoPersonaDto.Id}, TipoPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto TipoPersonaDto)
        {
            if(TipoPersonaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TiposPersonas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.TiposPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.TiposPersonas.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }