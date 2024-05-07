using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.WEB.Controllers
{


    public class CompteController : Controller
    {
        ICompteServices SC;
        IServicesBanque SB;

        public CompteController(ICompteServices sC, IServicesBanque sB)
        {
            SC = sC;
            SB = sB;
        }
        // GET: CompteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompteController/Create
        public ActionResult Create()
        {
            
            ViewBag.BanqueListe = new SelectList(SB.GetAll(), "Code", "Nom");
            return View();
        }

        // POST: CompteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compte collection)
        {
            try
            {
                SC.Add(collection);
                SC.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: CompteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
