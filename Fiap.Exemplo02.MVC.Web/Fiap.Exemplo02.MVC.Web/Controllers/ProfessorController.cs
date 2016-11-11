using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Professor

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Professor professor)
        {
            _unit.ProfessorRepository.Cadastrar(professor);
            _unit.Salvar();

            TempData["mensagem"] = "Cadastrado com sucesso!";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.ProfessorRepository.Listar();
            return View(lista);
        }
    }
}