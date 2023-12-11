using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class CategoriaPersonaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriaPersonaDto>>> Get()
    {
        var results = await _unitOfWork.CategoriasPersonas.GetAllAsync();
        return _mapper.Map<List<CategoriaPersonaDto>>(results);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaPersonaDto>> Get(int id)
    {
        var result = await _unitOfWork.CategoriasPersonas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return _mapper.Map<CategoriaPersonaDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaPersonaDto>> Post(CategoriaPersonaDto resultDto)
    {
        var result = _mapper.Map<Categoriapersona>(resultDto);
        _unitOfWork.CategoriasPersonas.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaPersonaDto>> Put(int id, [FromBody] CategoriaPersonaDto resultDto)
    {
        var result = await _unitOfWork.CategoriasPersonas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        if (resultDto.Id == 0)
        {
            resultDto.Id = id;
        }
        if (resultDto.Id != id)
        {
            return BadRequest();
        }
        // Update the properties of the existing entity with values from auditoriaDto
        _mapper.Map(resultDto, result);
        // The context is already tracking result, so no need to attach it
        await _unitOfWork.SaveAsync();
        // Return the updated entity
        return _mapper.Map<CategoriaPersonaDto>(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.CategoriasPersonas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.CategoriasPersonas.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
