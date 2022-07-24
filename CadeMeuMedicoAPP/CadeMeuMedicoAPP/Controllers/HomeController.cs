using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedicoAPP.Models;

namespace CadeMeuMedicoAPP.Controllers
{
    public class HomeController : BaseController
    {
        private EntidadesCadeMeuMedicoBDEntities db = new EntidadesCadeMeuMedicoBDEntities();

        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem vindo(a)";
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Especialidades = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            ViewBag.Cidades = new SelectList(db.Cidades, "IDCidade", "Nome");

            return View();
        }
        public ActionResult Buscar(int especialidade, int cidade)
        {
           List< Medicos> med = db.Medicos.Where(m => m.IDCidade== cidade && m.IDEspecialidade ==especialidade).ToList();
            Medicos medico = db.Medicos.Find(especialidade,cidade);


            return View(med);
        }


    }
}
