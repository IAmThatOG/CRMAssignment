using CRMAssignment.DAL;
using CRMAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CRMAssignment.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerManager customerManager;

        public CustomerController()
        {
            customerManager = new CustomerManager();
        }

        // GET: Customer
        [HttpGet]
        public ActionResult Index()
        {
            return View(customerManager.ListCustomers());
        }

        // GET: Customer/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var foundCustomer = customerManager.GetCustomerById(id);
            if (foundCustomer == null)
                return HttpNotFound();
            return View(foundCustomer);
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Firstname, Lastname, Email, Telephone")] Customer newCustomer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    customerManager.CreateCustomer(newCustomer);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "An error occured while creating";
            }
            return View(newCustomer);
        }

        // GET: Customer/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(customerManager.GetCustomerById(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Firstname, Lastname, Email, Telephone")] Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    customerManager.EditCustomer(customer);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again";
            var foundCustomer = customerManager.GetCustomerById(id);
            if (foundCustomer == null)
                return HttpNotFound();
            return View(foundCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                customerManager.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        protected override void Dispose(bool disposing)
        {
            customerManager.CustomerDispose();
            base.Dispose(disposing);
        }
    }
}
