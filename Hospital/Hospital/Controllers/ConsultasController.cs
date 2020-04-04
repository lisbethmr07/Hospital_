using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class ConsultasController : Controller
    {
        private HospitalEntities db = new HospitalEntities();
        // GET: Consultas
        public ActionResult Pacientes()
        {
            return View(db.Pacientes.ToList());
        }
        public ActionResult Medicos()
        {
            return View(db.Medicos.ToList());
        }
        public ActionResult Habitaciones()
        {
            var habitaciones = db.Habitaciones.Include(h => h.TipoH);
            return View(habitaciones.ToList());
        }
        public ActionResult Citas()
        {
            var citas = db.Citas.Include(c => c.Medicos).Include(c => c.Pacientes);
            return View(citas.ToList());
        }
        public ActionResult Ingresos()
        {
            var ingresos = db.Ingresos.Include(i => i.Habitaciones).Include(i => i.Pacientes);
            return View(ingresos.ToList());
        }
        public ActionResult AltaMedica()
        {
            var altaMedica = db.AltaMedica.Include(a => a.Habitaciones).Include(a => a.Ingresos).Include(a => a.Pacientes);
            return View(altaMedica.ToList());
        }
    }
}