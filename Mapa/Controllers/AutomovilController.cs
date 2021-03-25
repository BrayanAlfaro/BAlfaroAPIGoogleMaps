using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mapa.Controllers
{
    public class AutomovilController : Controller
    {
        // GET: Automovil
        public ActionResult GetAll()
        {
            ML.Automovil automovil = new ML.Automovil();
            ML.Result result = BL.Automovil.GetAll();
            automovil.Automoviles = result.Objects;
            return View(automovil);
        }
        [HttpGet]
        public ActionResult Form(string Matricula)
        {
            ML.Automovil automovil = new ML.Automovil();
            if (Matricula == null)//Add
            {
                automovil.Accion = "Add";
                return View(automovil);
            }
            else //Update
            {
                ML.Result result = BL.Automovil.GetById(Matricula);
                automovil.Accion = "Update";
                if (result.Correct)
                {
                    automovil = ((ML.Automovil)result.Object);

                    return View(automovil);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }            
        }
        [HttpPost]
        public ActionResult Form(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            if (automovil.Accion=="Add")
            {
                result = BL.Automovil.Add(automovil);
                ViewBag.Message = "Automovil ingresado correctamente";
            }
            else
            {
                result = BL.Automovil.Update(automovil);
                ViewBag.Message = "Automovil actualizado correctamente";
            }
            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo actualizar correctamente el alumno";
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(string Matricula)
        {
            ML.Result result = BL.Automovil.Delete(Matricula);
            if (result.Correct)
            {
                ViewBag.Message = "Elemento eliminado ";
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}