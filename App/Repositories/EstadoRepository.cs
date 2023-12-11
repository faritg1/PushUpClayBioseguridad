using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        private readonly ContextSecuritydb _context;

        public EstadoRepository(ContextSecuritydb context) : base(context)
        {
            _context = context;
        }
    }
}