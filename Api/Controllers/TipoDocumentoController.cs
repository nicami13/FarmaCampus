using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class TipoDocumentoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
        {
            var entidades = await _unitOfWork.TiposDocumentos.GetAllAsync();
            return _mapper.Map<List<TipoDocumento>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDocumentoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.TiposDocumentos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoDocumentoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDocumento>> Post(TipoDocumentoDto TipoDocumentoDto)
        {
            var entidad = _mapper.Map<TipoDocumento>(TipoDocumentoDto);
            this._unitOfWork.TiposDocumentos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            TipoDocumentoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = TipoDocumentoDto.Id}, TipoDocumentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDocumentoDto>> Put(int id, [FromBody] TipoDocumentoDto TipoDocumentoDto)
        {
            if(TipoDocumentoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<TipoDocumento>(TipoDocumentoDto);
            _unitOfWork.TiposDocumentos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return TipoDocumentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.TiposDocumentos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.TiposDocumentos.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }