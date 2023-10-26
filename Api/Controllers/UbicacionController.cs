using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class UbicacionController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UbicacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UbicacionPersona>>> Get()
        {
            var entidades = await _unitOfWork.UbicacionesPersonas.GetAllAsync();
            return _mapper.Map<List<UbicacionPersona>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UbicacionPersonaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.UbicacionesPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<UbicacionPersonaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UbicacionPersona>> Post(UbicacionPersonaDto UbicacionPersonaDto)
        {
            var entidad = _mapper.Map<UbicacionPersona>(UbicacionPersonaDto);
            this._unitOfWork.UbicacionesPersonas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            UbicacionPersonaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = UbicacionPersonaDto.Id}, UbicacionPersonaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UbicacionPersonaDto>> Put(int id, [FromBody] UbicacionPersonaDto UbicacionPersonaDto)
        {
            if(UbicacionPersonaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<UbicacionPersona>(UbicacionPersonaDto);
            _unitOfWork.UbicacionesPersonas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return UbicacionPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.UbicacionesPersonas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.UbicacionesPersonas.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }