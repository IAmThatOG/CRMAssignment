using CRMAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMAssignment.DAL
{
    public class CRMInitializer : DropCreateDatabaseIfModelChanges<CRMContext>
    {
        protected override void Seed(CRMContext context)
        {
            var customers = new List<Customer>()
            {
                new Customer() {firstname = "Gabriel", Lastname = "Okolie", Email = "gabriel_ifeanyi@ymail.com", Telephone = "08080724807"},
            };

            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }
    }
}