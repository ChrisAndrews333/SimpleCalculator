using System.Linq;
using System.Web.Mvc;
using SimpleCalculator.Models;

namespace SimpleCalculator.Controllers
{
    public class CalculationsController : Controller
    {
        private CalculationDBContext db = new CalculationDBContext();

        // GET: Calculations
        public ActionResult Index()
        {
            var calcs = db.Calculations.ToList();
            calcs.Reverse();
            ViewBag.hist = calcs;
            return View();
        }

        // POST: Calculations/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,Param1,Param2")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                calculation.Operator = "+";
                calculation.Result = calculation.Param1 + calculation.Param2;
                if (Create(calculation) == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index", calculation);
        }

        // POST: Calculations/Subtract
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subtract([Bind(Include = "ID,Param1,Param2")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                calculation.Operator = "-";
                calculation.Result = calculation.Param1 - calculation.Param2;
                if (Create(calculation) == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index", calculation);
        }

        // POST: Calculations/Multiply
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Multiply([Bind(Include = "ID,Param1,Param2")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                calculation.Operator = "*";
                calculation.Result = calculation.Param1 * calculation.Param2;
                if (Create(calculation) == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Index", calculation);
        }

        // POST: Calculations/Divide
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Divide([Bind(Include = "ID,Param1,Param2")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                calculation.Operator = "/";
                calculation.Result = calculation.Param1 / calculation.Param2;
                if (Create(calculation) == true)
                {
                    return RedirectToAction("Index");
                }

            }

            return View("Index", calculation);
        }

        // Creates history record of calculation and returns true if successful
        private bool Create([Bind(Include = "ID,Param1,Param2,Operator,Result")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                db.Calculations.Add(calculation);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
