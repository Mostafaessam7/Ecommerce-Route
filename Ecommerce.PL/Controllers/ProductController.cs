using Abp.Domain.Repositories;
using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Model;
using Ecommerce.BLL.Repostory;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace Ecommerce.PL.Controllers
{
    public class ProductController : Controller
    {
		private readonly IProductRep repository;
		private readonly IMapper mapper;

		public ProductController(IProductRep repository, IMapper mapper)
        {
            this.repository = repository;
			this.mapper = mapper;
		}

        public IActionResult Index()
        {

            var data = repository.GetAll();

            return View(mapper.Map<IEnumerable<ProductVM>>(data));
        }

        public IActionResult Details(int id)
        {
            var data = repository.GetProById(id);

            return View(mapper.Map<ProductVM>(data));

        }
   
        public IActionResult Edit(int id)
        {                  
                var data = repository.GetProById(id);
                return View(mapper.Map<ProductVM>(data));
        }
        [HttpPost]
		public IActionResult Edit(ProductVM model)
		{
            if(ModelState.IsValid)
            {
				repository.Update(mapper.Map<Product>(model));
				return RedirectToAction("Index");
			}
            else return View(model);
          
		}

		public IActionResult Delete(int id)
        {
			var data = repository.GetProById(id);
			repository.Delete(data);

			return RedirectToAction("Index");

		}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                repository.Create(mapper.Map<Product>(model));
                return RedirectToAction("Index");
            }
            else return View(model);
        }


        public IActionResult InStock()
        {
            var data = repository.GetAll();
            ViewBag.prod = new SelectList(data,"id","name");
            return View();
        }

        [HttpPost]
        public JsonResult InStock(int id)
        {
            var data = repository.GetProById(id);
            return Json(data.quantity);
        }
    }

}

