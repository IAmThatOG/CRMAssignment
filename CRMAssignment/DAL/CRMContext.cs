using CRMAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMAssignment.DAL
{
    public class CRMContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CRMContext() : base("CRMConnection")
        {
        }
    }
}