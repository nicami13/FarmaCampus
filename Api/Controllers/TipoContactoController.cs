using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoContactoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoContacto>>> Get()
        {
            var entidades = await _unitOfWork.TiposContactos.GetAllAsync();
            return _mapper.Map<List<TipoContacto>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoContactoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.TiposContactos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoContactoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoContacto>> Post(TipoContactoDto TipoContactoDto)
        {
            var entidad = _mapper.Map<TipoContacto>(TipoContactoDto);
            this._unitOfWork.TiposContactos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            TipoContactoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoContactoDto.Id}, TipoContactoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoContactoDto>> Put(int id, [FromBody] TipoContactoDto TipoContactoDto)
        {
            if(TipoContactoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<TipoContacto>(TipoContactoDto);
            _unitOfWork.TiposContactos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return TipoContactoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.TiposContactos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.TiposContactos.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }