using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriaPersona CategoriasPersonas {get;}
        ICiudad Ciudades {get;}
        IContactoPersona ContactosPersonas {get;}
        IDepartamento Departamentos {get;}
        IDireccionPersona DireccionesPersonas {get;}
        IEstado Estados {get;}
        IPais Paises {get;}
        IPersona Personas {get;}
        IProgramacion Programaciones {get;}
        ITipoContacto TiposContactos {get;}
        ITipoDireccion TiposDirecciones {get;}
        ITipoPersona TiposPersonas {get;}
        ITurno Turnos {get;}
        IContrato Contratos {get;}
        Task<int> SaveAsync();
    }
}