using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Persistence.Data;
using Persistence.Entities;

namespace App.Repositories
{
    public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
    {
        private readonly ContextSecuritydb _context;

        public ProgramacionRepository(ContextSecuritydb context) : base(context)
        {
            _context = context;
        }
    }
}