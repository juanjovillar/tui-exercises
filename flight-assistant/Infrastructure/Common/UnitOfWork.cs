using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;

namespace Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomContext _context;

        public UnitOfWork(CustomContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
