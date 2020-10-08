using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity) where T : class;
    }
}
