using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedicoAPP.Models;
using CadeMeuMedicoAPP.Repositorios;

namespace CadeMeuMedicoAPP.Controllers
{
    public class UsuariosController : Controller
    {
        private EntidadesCadeMeuMedicoBDEntities db = new EntidadesCadeMeuMedicoBDEntities();
        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuarios.AutenticarUsuario(Login, Senha))
            {
                return Json(new { OK = true, Mensagem = "Usuário autenticado. Redirecionando..." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false, Mensagem = "Usuário não encontrando. Tente novamente." }, JsonRequestBehavior.AllowGet);
            }
        }

         public ActionResult Index()
        {
            var usuarios = db.Usuarios.ToList();
            return View(usuarios);
        }
       
        public ActionResult Adicionar()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.Senha=  RepositorioCriptografia.Criptografar(usuarios.Senha);
                
                
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(usuarios);
        }

        public ActionResult Editar(long id)
        {

           
            Usuarios usuarios = db.Usuarios.Find(id);

            usuarios.Senha = RepositorioCriptografia.Descriptografar(usuarios.Senha);

            return View(usuarios);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Senha = RepositorioCriptografia.Criptografar(usuario.Senha);
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            return View(usuario);
        }
        public ActionResult Detalhes(long id)
        {
            Usuarios usuario = db.Usuarios.Find(id);

           

            return View(usuario);
        }

        [HttpPost]
        public String Excluir(long id)
        {
            try
            {
                Usuarios usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
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
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}