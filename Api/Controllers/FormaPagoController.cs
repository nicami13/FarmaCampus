using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class FormaPagoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FormaPagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormaPago>>> Get()
        {
            var entidades = await _unitOfWork.FormasPagos.GetAllAsync();
            return _mapper.Map<List<FormaPago>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormaPagoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.FormasPagos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<FormaPagoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FormaPago>> Post(FormaPagoDto FormaPagoDto)
        {
            var entidad = _mapper.Map<FormaPago>(FormaPagoDto);
            this._unitOfWork.FormasPagos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            FormaPagoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = FormaPagoDto.Id}, FormaPagoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormaPagoDto>> Put(int id, [FromBody] FormaPagoDto FormaPagoDto)
        {
            if(FormaPagoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<FormaPago>(FormaPagoDto);
            _unitOfWork.FormasPagos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return FormaPagoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.FormasPagos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.FormasPagos.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }