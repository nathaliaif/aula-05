﻿using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo02.MVC.Web.UnitsOfWork
{
    class UnitOfWork : IDisposable
    {
        private PortalContext _context = new PortalContext();


        private IAlunoRepository _alunoRepository;

        public IAlunoRepository AlunoRepository
        {
            get
            {
                if (_alunoRepository == null)
                {
                    _alunoRepository = new AlunoRepository(_context);
                }
                return _alunoRepository;
            }
        }

        private IGrupoRepository _grupoRepository;

        public IGrupoRepository GrupoRepository
        {
            get
            {
                if (_grupoRepository == null)
                {
                    _grupoRepository = new GrupoRepository(_context);
                }
                return _grupoRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

    }
}
