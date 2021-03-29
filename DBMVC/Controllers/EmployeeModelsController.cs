using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLDataBaseLayer;
using CLModelLayer;

namespace DBMVC.Controllers
{
    public class EmployeeModelsController : Controller
    {
        private EmployeeDBEntities11 db = new EmployeeDBEntities11();

        // GET: EmployeeModels
        public async Task<ActionResult> Index()
        {
            var employeeModels = db.EmployeeModels.Include(e => e.Address);
            return View(await employeeModels.ToListAsync());
        }

        // GET: EmployeeModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = await db.EmployeeModels.FindAsync(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // GET: EmployeeModels/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.AddressModels, "Id", "AddressLine1");
            return View();
        }

        // POST: EmployeeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Salary,AddressId,Gender")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeModels.Add(employeeModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.AddressModels, "Id", "AddressLine1", employeeModel.AddressId);
            return View(employeeModel);
        }

        // GET: EmployeeModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = await db.EmployeeModels.FindAsync(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.AddressModels, "Id", "AddressLine1", employeeModel.AddressId);
            return View(employeeModel);
        }

        // POST: EmployeeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Salary,AddressId,Gender")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.AddressModels, "Id", "AddressLine1", employeeModel.AddressId);
            return View(employeeModel);
        }

        // GET: EmployeeModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModel employeeModel = await db.EmployeeModels.FindAsync(id);
            if (employeeModel == null)
            {
                return HttpNotFound();
            }
            return View(employeeModel);
        }

        // POST: EmployeeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeModel employeeModel = await db.EmployeeModels.FindAsync(id);
            db.EmployeeModels.Remove(employeeModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
