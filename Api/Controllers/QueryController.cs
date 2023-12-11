using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dto;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace Api.Controllers
{
    public class QueryController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ContextSecuritydb _context;

        public QueryController(IUnitOfWork unitOfWork, IMapper mapper, ContextSecuritydb context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        //1. Listar Todos Los Empleados de la empresa de seguridad 
        [HttpGet("GetOne")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QueryOneDto>> GetPrimera(){
            var ct =  from cat in _context.Categoriaspersonas
            join emp in _context.Personas on cat.Id equals emp.IdCategoriaP
            join tp in _context.Tipospersonas on emp.IdTpPersonaFk equals tp.Id
            where cat.NombreCategoria.ToLower() == "seguridad" && tp.Descripcion.ToLower() == "empleado"
            select new QueryOneDto{
                Id = emp.Id,
                NombreEmpleado = emp.NombrePersona
            };
            return  Task.FromResult(ct);
        }

        //2. Listar Todos los empleados que son vigilantes 
        [HttpGet("GetTwo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QueryTwoDto>> GetSegundo(){
            var ct =  from cat in _context.Categoriaspersonas
            join emp in _context.Personas on cat.Id equals emp.IdCategoriaP
            join tp in _context.Tipospersonas on emp.IdTpPersonaFk equals tp.Id
            where cat.NombreCategoria.ToLower() == "vigilante" && tp.Descripcion.ToLower() == "empleado"
            select new QueryTwoDto{
                Id = emp.Id,
                NombreEmpleado = emp.NombrePersona
            };
            return  Task.FromResult(ct);
        }

        //3. listar los numeros de contacto de un empleado que sea vigilante
        [HttpGet("GetThree")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QueryThreeDto>> GetThree(){
            var ct =  from cat in _context.Categoriaspersonas
            join emp in _context.Personas on cat.Id equals emp.IdCategoriaP
            join cp in _context.Contactospersonas on emp.Id equals cp.IdPersonaFk
            join tp in _context.Tipospersonas on emp.IdTpPersonaFk equals tp.Id
            where cat.NombreCategoria.ToLower() == "vigilante" && tp.Descripcion.ToLower() == "empleado"
            select new QueryThreeDto{
                Numero = cp.Descripcion
            };
            return  Task.FromResult(ct);
        } 

        //4. Listar Todos clientes que vivan en la ciudad de bucaramanga
        [HttpGet("GetFour")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QueryFourDto>> GetCuatro(){
            var ct =  from cat in _context.Categoriaspersonas
            join emp in _context.Personas on cat.Id equals emp.IdCategoriaP
            join tp in _context.Tipospersonas on emp.IdTpPersonaFk equals tp.Id
            where cat.NombreCategoria.ToLower() == "bucaramanga" && tp.Descripcion.ToLower() == "cliente"
            select new QueryFourDto{
                Id = emp.Id,
                NombreCliente = emp.NombrePersona
            };
            return  Task.FromResult(ct);
        }

        //5. Listar todos los empleados que vivan en giron y piedecuesta
        [HttpGet("GetFive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QueryFourDto>> GetQuinto(){
            var ct =  from cat in _context.Categoriaspersonas
            join emp in _context.Personas on cat.Id equals emp.IdCategoriaP
            join tp in _context.Tipospersonas on emp.IdTpPersonaFk equals tp.Id
            where cat.NombreCategoria.ToLower() == "piedecuesta" && cat.NombreCategoria.ToLower() == "giron" && tp.Descripcion.ToLower() == "empleado"
            select new QueryFourDto{
                Id = emp.Id,
                NombreCliente = emp.NombrePersona
            };
            return  Task.FromResult(ct);
        }

        //6. Listar todos los clientes que tengan mas de 5 años de antiguedad
        [HttpGet("GetSix")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QuerySixDto>> GetSeis(){
            var emple = from cli in _context.Personas
            join con in _context.Contratos on cli.Id equals con.IdClienteFk
            join tp in _context.Tipospersonas on cli.IdTpPersonaFk equals tp.Id
            where con.FechaContrato.Year - cli.FechaReg.Year > 5 && tp.Descripcion.ToLower() == "cliente"
            select new QuerySixDto{
                Id = cli.Id,
                Nombre = cli.NombrePersona
            };
            return  Task.FromResult(emple);
        }

        //7. Listar todos los contrartos cuyo estado es activo
        [HttpGet("GetSeven")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IQueryable<QuerySevenDto>> GetSiete(){
            var emple = from cli in _context.Personas
            join con in _context.Contratos on cli.Id equals con.IdClienteFk
            join tp in _context.Tipospersonas on cli.IdTpPersonaFk equals tp.Id
            join es in _context.Estados on con.IdEstadoFk equals es.Id
            where es.Descripcion.ToLower() == "activo" && tp.Descripcion.ToLower() == "cliente"
            select new QuerySevenDto{
                Nombre = cli.NombrePersona
            };
            return  Task.FromResult(emple);
        }
    }
}