using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class PaisRepository : GenericRepository<Pai>, IPais
    {
        private readonly ContextSecuritydb _context;

        public PaisRepository(ContextSecuritydb context) : base(context)
        {
            _context = context;
        }
    }
}