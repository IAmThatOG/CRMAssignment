using CRMAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAssignment.DAL
{
    public class CustomerManager
    {
        private CRMContext crmContext;
        private static List<Customer> customerList;

        public CustomerManager()
        {
            crmContext = new CRMContext();
            customerList = new List<Customer>();
        }

        public Customer[] ListCustomers()
        {
            customerList = crmContext.Customers.ToList();
            return customerList.ToArray();
        }

        public Customer GetCustomerById(int? id)
        {
            var foundCustomer = crmContext.Customers.Find(id);
            return foundCustomer;
        }

        public void CreateCustomer(Customer newCustomer)
        {
            crmContext.Customers.Add(newCustomer);
            crmContext.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            crmContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            crmContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var foundStudent = GetCustomerById(id);
            crmContext.Customers.Remove(foundStudent);
            crmContext.SaveChanges();
        }

        public void CustomerDispose()
        {
            crmContext.Dispose();
        }
    }
}