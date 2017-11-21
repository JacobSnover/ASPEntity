using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ASPEntity.Models;

namespace ASPEntity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCustomers()
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> CustomerList = ORM.Customers.ToList();

            ViewBag.CustomerList = CustomerList;

            return View("CustomersView");
        }

        public ActionResult ListCustomersByID(string CustomerID)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> output = new List<Customer>();

            foreach (Customer CustomerRecord in ORM.Customers.ToList())
            {
                if (CustomerRecord.CustomerID.Contains(CustomerID.ToUpper()))
                {
                    output.Add(CustomerRecord);
                }
            }

            ViewBag.CustomerList = output;

            return View("CustomersView");
        }

        public ActionResult ListCustomersByCountry(string Country)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> output = new List<Customer>();

            foreach (Customer CustomerRecord in ORM.Customers.ToList())
            {
                if (CustomerRecord.Country.ToLower() == Country.ToLower())
                {
                    output.Add(CustomerRecord);
                }
            }

            ViewBag.CustomerList = output;

            return View("CustomersView");
 
        }
    }
}