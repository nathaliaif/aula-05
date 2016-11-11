using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        //private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();
        private object _context;

        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastrar()
        {
            // Buscar todos os grupos cadastrados
            //var lista = _context.Grupo.ToList();

            var lista = _unit.GrupoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            //_context.Aluno.Add(aluno);
            //_context.SaveChanges();

            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();

            TempData["msg"] = "Aluno cadastrado com sucesso"; 
            return RedirectToAction("Cadastrar");

            //excluir e editar
        }

        [HttpGet]
        public ActionResult Listar()
        {
            // Include -> busca o relacionamento (preenche o grupo que o aluno possui)
            //var lista = _context.Aluno.Include("Grupo").ToList();
            var lista = _unit.AlunoRepository.Listar()

            return View(listar);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            // Buscar o objeto (aluno) no banco 
            //var aluno = _context.Aluno.Find(id);

            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            //ViewBag.grupos = new SelectList( _unit.AlunoRepository.Listar() , "Id", "Nome");
            //manda o aluno para a view
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            //_context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            //_context.SaveChanges();

            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();

            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }

        public ActionResult Excluir(int alunoId)
        {
            //var aluno = _context.Aluno.Find(alunoId);
            //_context.Aluno.Remove(aluno);
            //_context.SaveChanges();

            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();
            TempData["msg"] = "Aluno excluido";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            // Busca  o aluno por parte do nome
            //var lista = _context.Aluno.Where(a => a.Nome.Contains(nomeBusca)).ToList();


            var lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));

            // Retorna para a view com a lista
            return View("Listar", lista);
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }

    }
}