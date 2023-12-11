using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace App.Repositories
{
    public class TipoDireccionRepository : GenericRepository<Tipodireccion>, ITipoDireccion
    {
        private readonly ContextSecuritydb _context;

        public TipoDireccionRepository(ContextSecuritydb context) : base(context)
        {
            _context = context;
        }
    }
}