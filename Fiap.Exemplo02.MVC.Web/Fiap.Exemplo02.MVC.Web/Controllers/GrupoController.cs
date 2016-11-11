using Fiap.Exemplo02.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class GrupoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Grupo grupo)
        {
            //var con = new PortalContext();
            //con.Grupo.Add(grupo);
            //con.SaveChanges();

            _unit.GrupoRepository.Cadastrar(grupo);
            _unit.Salvar();

            TempData["mensagem"] = "Cadastrado com sucesso!";
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //var con = new PortalContext();
            //var l = con.Grupo.ToList();

            var lista = _unit.GrupoRepository.Listar();
            return View(lista);
        }

       
    }
}