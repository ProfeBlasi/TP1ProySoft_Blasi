using AccesData.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AccesData.Commands
{
    public class GenericsRepository : IGenericRepository
    {
        private readonly Contexto _context;
        public GenericsRepository(Contexto _context)
        {
            this._context = _context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}