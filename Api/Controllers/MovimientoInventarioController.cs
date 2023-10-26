using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class MovimientoInventarioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovimientoInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MovimientoInventario>>> Get()
        {
            var entidades = await _unitOfWork.MovimientosInventarios.GetAllAsync();
            return _mapper.Map<List<MovimientoInventario>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovimientoInventarioDto>> Get(int id)
        {
            var entidad = await _unitOfWork.MovimientosInventarios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<MovimientoInventarioDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovimientoInventario>> Post(MovimientoInventarioDto MovimientoInventarioDto)
        {
            var entidad = _mapper.Map<MovimientoInventario>(MovimientoInventarioDto);
            this._unitOfWork.MovimientosInventarios.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            MovimientoInventarioDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = MovimientoInventarioDto.Id}, MovimientoInventarioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovimientoInventarioDto>> Put(int id, [FromBody] MovimientoInventarioDto MovimientoInventarioDto)
        {
            if(MovimientoInventarioDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<MovimientoInventario>(MovimientoInventarioDto);
            _unitOfWork.MovimientosInventarios.Update(entidades);
            await _unitOfWork.SaveAsync();
            return MovimientoInventarioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.MovimientosInventarios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.MovimientosInventarios.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }