﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();//Eager loading Include(c => c.MembershipType)
            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);//var customer = (from cust in GetCustomers() where cust.Id == id select cust).SingleOrDefault();
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult NewCustomer()
        {

            var memberships = _context.MembershipTypes.ToList();
            var viewModel = new CustomersViewModel()
            {
                MembershipTypes = memberships
            };
            return View(viewModel);
        }
    }
}