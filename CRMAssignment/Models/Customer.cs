using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAssignment.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}