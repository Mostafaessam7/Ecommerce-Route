using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Model;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace Ecommerce.PL.Controllers
{
	public class CustomerController : Controller
	{
        private readonly ICustomerRep repository;
        private readonly IMapper mapper;

        public CustomerController(ICustomerRep repository ,IMapper mapper)
		{
            this.repository = repository;
            this.mapper = mapper;
        }
		public IActionResult Index()
		{
			var data = repository.GetAll();

            return View(mapper.Map<IEnumerable<CustomerVM>>(data));
		}
        public IActionResult Details(int id)
        {
            var data =repository.GetProById(id);

            return View(mapper.Map<CustomerVM>(data));
        }

		public IActionResult Edit(int id)
        {
            var data = repository.GetProById(id);

            return View(mapper.Map<CustomerVM>(data));
        }
        [HttpPost]
        public IActionResult Edit(CustomerVM ProVM)
        {
            
                repository.Update(mapper.Map<Customer>(ProVM));
                return RedirectToAction("Index");

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerVM model)
        {
            repository.Create(mapper.Map<Customer>(model));
            return RedirectToAction("Index");
        }

        public IActionResult CheckProducts()
        {
            var customers = repository.GetAll();
            ViewBag.cst = new SelectList(customers, "id", "name");
            return View();
        }
        [HttpPost]
        public JsonResult CheckProducts(int id)
        {
            var data = repository.ProductByCstId(id);
            return Json(data);
        }
    }
}
