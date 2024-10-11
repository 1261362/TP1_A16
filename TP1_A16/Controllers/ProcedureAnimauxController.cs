using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP1_A16.Controllers
{
    public class ProcedureAnimauxController : Controller
    {
        // GET: ProcedureAnimauxController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProcedureAnimauxController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcedureAnimauxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedureAnimauxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProcedureAnimauxController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProcedureAnimauxController/Edit/5
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

        // GET: ProcedureAnimauxController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcedureAnimauxController/Delete/5
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
