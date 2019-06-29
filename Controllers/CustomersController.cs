using System;
using System.Data.SqlClient;
using System.Linq;
using CustomerCare.Data;
using CustomerCare.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Customer
        public ActionResult Index(string searchTerm = "", string sortColumn = "", string sortOrder = "", string postAction = "", int pageNumber = 1, int pageSize = 10)
        {
            ViewData["SortColumn"] = sortColumn;
            if (!string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(postAction))
                sortOrder = sortOrder == "asc" ? "desc" : "asc";
            ViewData["SortOrder"] = sortOrder;
            searchTerm = searchTerm ?? string.Empty;
            ViewData["SearchTerm"] = searchTerm;
            ViewData["PageNumber"] = pageNumber;
            ViewData["PageSize"] = pageSize;

            var customers = _context.CustomersSearchResult.FromSql("CustomersSearch @SearchTerm, @SortColumn, @SortOrder, @PageNumber, @PageSize",
                new SqlParameter("SearchTerm", searchTerm),
                new SqlParameter("SortColumn", sortColumn),
                new SqlParameter("SortOrder", sortOrder),
                new SqlParameter("PageNumber", pageNumber),
                new SqlParameter("PageSize", pageSize)
                );

            ViewBag.TotalResults = customers.FirstOrDefault()?.TotalCount;

            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }

        // GET: Customer/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Customers model)
        {
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                _context.Customers.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // TODO: set message to internal Log and use custom error messages
                return View(ex.Message);
            }
        }

        // GET: Customer/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, Customers model)
        {
            try
            {
                var updateCustomer = _context.Customers.Find(id);
                _context.Entry(updateCustomer).CurrentValues.SetValues(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // TODO: set message to internal Log and use custom error messages
                return View(ex.Message);
            }
        }

        // GET: Customer/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var deleteCustomer = _context.Customers.Find(id);
                _context.Customers.Remove(deleteCustomer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // TODO: set message to internal Log and use custom error messages
                return View(ex.Message);
            }
        }
    }
}