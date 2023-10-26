using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class DetalleMovimientoInventarioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleMovimientoInventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleMovimientoInventario>>> Get()
        {
            var entidades = await _unitOfWork.DetallesMovimientosInventarios.GetAllAsync();
            return _mapper.Map<List<DetalleMovimientoInventario>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleMovimientoInventarioDto>> Get(int id)
        {
            var entidad = await _unitOfWork.DetallesMovimientosInventarios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetalleMovimientoInventarioDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleMovimientoInventario>> Post(DetalleMovimientoInventarioDto DetalleMovimientoInventarioDto)
        {
            var entidad = _mapper.Map<DetalleMovimientoInventario>(DetalleMovimientoInventarioDto);
            this._unitOfWork.DetallesMovimientosInventarios.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            DetalleMovimientoInventarioDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleMovimientoInventarioDto.Id}, DetalleMovimientoInventarioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleMovimientoInventarioDto>> Put(int id, [FromBody] DetalleMovimientoInventarioDto DetalleMovimientoInventarioDto)
        {
            if(DetalleMovimientoInventarioDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<DetalleMovimientoInventario>(DetalleMovimientoInventarioDto);
            _unitOfWork.DetallesMovimientosInventarios.Update(entidades);
            await _unitOfWork.SaveAsync();
            return DetalleMovimientoInventarioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.DetallesMovimientosInventarios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.DetallesMovimientosInventarios.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }