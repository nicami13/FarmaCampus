using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoMovimientoInventarioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoMovimientoInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoMovimientoInventario>>> Get()
        {
            var entidades = await _unitOfWork.TipoMovimiento.GetAllAsync();
            return _mapper.Map<List<TipoMovimientoInventario>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoMovimientoInventarioDto>> Get(int id)
        {
            var entidad = await _unitOfWork.TipoMovimiento.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoMovimientoInventarioDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMovimientoInventario>> Post(TipoMovimientoInventarioDto TipoMovimientoInventarioDto)
        {
            var entidad = _mapper.Map<TipoMovimientoInventario>(TipoMovimientoInventarioDto);
            this._unitOfWork.TipoMovimiento.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            TipoMovimientoInventarioDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoMovimientoInventarioDto.Id}, TipoMovimientoInventarioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoMovimientoInventarioDto>> Put(int id, [FromBody] TipoMovimientoInventarioDto TipoMovimientoInventarioDto)
        {
            if(TipoMovimientoInventarioDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<TipoMovimientoInventario>(TipoMovimientoInventarioDto);
            _unitOfWork.TipoMovimiento.Update(entidades);
            await _unitOfWork.SaveAsync();
            return TipoMovimientoInventarioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.TipoMovimiento.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.TipoMovimiento.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }