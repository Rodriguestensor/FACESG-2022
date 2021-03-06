using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedicoAPP.Models;

namespace CadeMeuMedicoAPP.Controllers
{
    public class MedicosController : Controller
    {
        private EntidadesCadeMeuMedicoBDEntities db = new EntidadesCadeMeuMedicoBDEntities();

        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades").ToList();
            return View(medicos);
        }
        public ActionResult listar()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades").ToList();
            return View(medicos);
        }


        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,"IDEspecialidade", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", "IDCidade");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", "IDEspecialidade");
            return View(medicos);
        }

        public ActionResult Editar(long id)
        {
            Medicos medico = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade","Nome", medico.IDEspecialidade);

            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidades,"IDCidade","Nome",medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade","Nome",medico.IDEspecialidade);

            return View(medico);
        }
        public ActionResult Detalhes(long id)
        {
            Medicos medico = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }

        [HttpPost]
        public String Excluir(long id)
        {
            try
            {
                Medicos medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
        // GET: /Movies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            db.Medicos.Remove(medico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}