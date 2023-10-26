using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class PresentacionController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PresentacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Presentacion>>> Get()
        {
            var entidades = await _unitOfWork.Presentaciones.GetAllAsync();
            return _mapper.Map<List<Presentacion>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PresentacionDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Presentaciones.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<PresentacionDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Presentacion>> Post(PresentacionDto PresentacionDto)
        {
            var entidad = _mapper.Map<Presentacion>(PresentacionDto);
            this._unitOfWork.Presentaciones.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            PresentacionDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = PresentacionDto.Id}, PresentacionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PresentacionDto>> Put(int id, [FromBody] PresentacionDto PresentacionDto)
        {
            if(PresentacionDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Presentacion>(PresentacionDto);
            _unitOfWork.Presentaciones.Update(entidades);
            await _unitOfWork.SaveAsync();
            return PresentacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Presentaciones.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Presentaciones.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }