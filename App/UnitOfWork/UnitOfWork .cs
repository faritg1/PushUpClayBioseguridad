using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Repositories;
using Domain.Interfaces;
using Persistence.Data;

namespace App.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ContextSecuritydb _context;

        public UnitOfWork(ContextSecuritydb context)
        {
            _context = context;
        }

        private ICategoriaPersona _categoriaspersonas ;

        private ICiudad _ciudades ;

        private IContactoPersona _contactospersonas ;

        private IDepartamento _departamentos ;

        private IDireccionPersona _direccionespersonas ;

        private IEstado _estados ;

        private IPais _paises ;

        private IPersona _personas ;

        private IProgramacion _programaciones ;

        private ITipoContacto _tiposcontactos ;

        private ITipoDireccion _tiposdirecciones ;

        private ITipoPersona _tipospersonas ;

        private ITurno _turnos ;

        private IContrato _contratos ;

        public ICategoriaPersona CategoriasPersonas
        {
        get
            {
                if (_categoriaspersonas == null)
                {
                    _categoriaspersonas = new CategoriaPersonaRepository(_context);
                }
                return _categoriaspersonas;
            }
        }
        public ICiudad Ciudades
        {
        get
            {
                if (_ciudades == null)
                {
                    _ciudades = new CiudadRepository(_context);
                }
                return _ciudades;
            }
        }
        public IContactoPersona ContactosPersonas
        {
        get
            {
                if (_contactospersonas == null)
                {
                    _contactospersonas = new ContactoPersonaRepository(_context);
                }
                return _contactospersonas;
            }
        }
        public IDepartamento Departamentos
        {
        get
            {
                if (_departamentos == null)
                {
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }
        public IDireccionPersona DireccionesPersonas
        {
        get
            {
                if (_direccionespersonas == null)
                {
                    _direccionespersonas = new DireccionPersonaRepository(_context);
                }
                return _direccionespersonas;
            }
        }
        public IEstado Estados
        {
        get
            {
                if (_estados == null)
                {
                    _estados = new EstadoRepository(_context);
                }
                return _estados;
            }
        }
        public IPais Paises
        {
        get
            {
                if (_paises == null)
                {
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IPersona Personas
        {
        get
            {
                if (_personas == null)
                {
                    _personas = new PersonaRepository(_context);
                }
                return _personas;
            }
        }
        public IProgramacion Programaciones
        {
        get
            {
                if (_programaciones == null)
                {
                    _programaciones = new ProgramacionRepository(_context);
                }
                return _programaciones;
            }
        }
        public ITipoContacto TiposContactos
        {
        get
            {
                if (_tiposcontactos == null)
                {
                    _tiposcontactos = new TipoContactoRepository(_context);
                }
                return _tiposcontactos;
            }
        }
        public ITipoDireccion TiposDirecciones
        {
        get
            {
                if (_tiposdirecciones == null)
                {
                    _tiposdirecciones = new TipoDireccionRepository(_context);
                }
                return _tiposdirecciones;
            }
        }
        public ITipoPersona TiposPersonas
        {
        get
            {
                if (_tipospersonas == null)
                {
                    _tipospersonas = new TipoPersonaRepository(_context);
                }
                return _tipospersonas;
            }
        }
        public ITurno Turnos
        {
        get
            {
                if (_turnos == null)
                {
                    _turnos = new TurnoRepository(_context);
                }
                return _turnos;
            }
        }
        public IContrato Contratos
        {
        get
            {
                if (_contratos == null)
                {
                    _contratos = new ContratoRepository(_context);
                }
                return _contratos;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}