using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

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
            // var customers = _context.Customers will only query database when customers var is interated in the View
            // To query immediately, add a method behind, e.g. ToList() or SingleOrDefault()
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel viewmodel)
        {
            // Id = 0 implies new customer
            if (viewmodel.Customer.Id == 0)
            {
                // Add new Customer. This only stores changes in memory
                _context.Customers.Add(viewmodel.Customer);
            }
            else
            {
                // Retrieves the Customer which matches the Id
                var customer = _context.Customers.Single(c => viewmodel.Customer.Id == c.Id);

                // Modify existing Customer's data
                customer.BirthdayDate = viewmodel.Customer.BirthdayDate;
                customer.IsSubscribedToNewsLetter = viewmodel.Customer.IsSubscribedToNewsLetter;
                customer.MembershipType = viewmodel.Customer.MembershipType;
                customer.Name = viewmodel.Customer.Name;
            }
            

            // To persist changes into Database
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // This will overwrite the view to display. Will look for a view named CustomerForm.cshtml, rather than Edit.cshtml
            return View("CustomerForm", viewModel);
        }
    }
}