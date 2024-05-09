using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CheckMVC.Models;
using WebGrease.Extensions;

namespace CheckMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
           using (AlFanarDBEntities db  = new AlFanarDBEntities())
            {
                List<tblFEmployee> EmployeeList = (from data in db.tblFEmployees
                                                            select data).ToList();
                return View(EmployeeList);
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View(new tblFEmployee());
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(tblFEmployee employee)
        {
            try
            {
                // TODO: Add insert logic here
                using (AlFanarDBEntities db = new AlFanarDBEntities())
                {
                    db.tblFEmployees.Add(employee);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (AlFanarDBEntities db = new AlFanarDBEntities())
            {
                tblFEmployee employee = db.tblFEmployees.Find(id);
                return View(employee);
            }
                
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(tblFEmployee employee)
        {
            try
            {
                // TODO: Add update logic here
                using (AlFanarDBEntities db = new AlFanarDBEntities())
                {
                    tblFEmployee tbl= db.tblFEmployees.Find(employee.Id);
                    tbl.Name = employee.Name;
                    tbl.Designation = employee.Designation;
                    tbl.Age = employee.Age;
                    tbl.DOB = employee.DOB;
                    tbl.Gender = employee.Gender;
                    tbl.Street_Address1 = employee.Street_Address1;
                    tbl.Street_Address2 = employee.Street_Address2;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (AlFanarDBEntities db =new AlFanarDBEntities())
            {
                db.tblFEmployees.Remove(db.tblFEmployees.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
