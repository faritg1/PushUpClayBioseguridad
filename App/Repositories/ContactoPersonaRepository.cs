using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class ContactoPersonaRepository : GenericRepository<Contactopersona>, IContactoPersona
    {
        private readonly ContextSecuritydb _context;

        public ContactoPersonaRepository(ContextSecuritydb context) : base(context)
        {
            _context = context;
        }
    }
}