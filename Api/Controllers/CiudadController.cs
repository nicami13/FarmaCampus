using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class CiudadController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Ciudad>>> Get()
        {
            var entidades = await _unitOfWork.Ciudades.GetAllAsync();
            return _mapper.Map<List<Ciudad>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<CiudadDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ciudad>> Post(CiudadDto CiudadDto)
        {
            var entidad = _mapper.Map<Ciudad>(CiudadDto);
            this._unitOfWork.Ciudades.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            CiudadDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = CiudadDto.Id}, CiudadDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto CiudadDto)
        {
            if(CiudadDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Ciudad>(CiudadDto);
            _unitOfWork.Ciudades.Update(entidades);
            await _unitOfWork.SaveAsync();
            return CiudadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Ciudades.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }