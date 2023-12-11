using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class TurnoRepository : GenericRepository<Turno>, ITurno
    {
        private readonly ContextSecuritydb _context;

        public TurnoRepository(ContextSecuritydb context) : base(context)
        {
            _context = context;
        }
    }
}