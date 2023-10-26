using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class MarcaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarcaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Marca>>> Get()
        {
            var entidades = await _unitOfWork.Marcas.GetAllAsync();
            return _mapper.Map<List<Marca>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MarcaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Marcas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<MarcaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Marca>> Post(MarcaDto MarcaDto)
        {
            var entidad = _mapper.Map<Marca>(MarcaDto);
            this._unitOfWork.Marcas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            MarcaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = MarcaDto.Id}, MarcaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MarcaDto>> Put(int id, [FromBody] MarcaDto MarcaDto)
        {
            if(MarcaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Marca>(MarcaDto);
            _unitOfWork.Marcas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return MarcaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Marcas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Marcas.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }