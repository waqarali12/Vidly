using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        //Constructoe
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Index
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();//Eager loading Include(c => c.MembershipType)
            return View(customers);
        }

        //Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);//var customer = (from cust in GetCustomers() where cust.Id == id select cust).SingleOrDefault();
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        //NewCustomer
        public ActionResult NewCustomer()
        {
            var memberships = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = memberships
            };
            return View("CustomerForm",viewModel);
        }

        //CreateCustomer
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //UpdateCustomer
        public ActionResult Edit(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (Customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                customer = Customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}