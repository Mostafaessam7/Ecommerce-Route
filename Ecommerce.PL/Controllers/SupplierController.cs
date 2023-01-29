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
    public class SupplierController : Controller
    {
        private readonly ISupplierRep repository;
        private readonly IMapper mapper;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;

        public SupplierController(ISupplierRep repository ,
            IMapper mapper,
            ICountryRep country,
            ICityRep city,
            IDistrictRep district
            )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.country = country;
            this.city = city;
            this.district = district;
        }
        public IActionResult Index()
        {
            var data = repository.GetAll();
            var res = mapper.Map<IEnumerable<SupplierVM>>(data);
            return View(res);
        }

        public IActionResult Details(int id) 
        {
            var data = repository.getById(id);
            return View(mapper.Map<SupplierVM>(data));

        }
        public IActionResult Delete(int id)
        {
            var data = repository.getById(id);
            repository.Delete(data);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var data = repository.getById(id);
            return View(mapper.Map<SupplierVM>(data));
        }
        [HttpPost]
        public IActionResult Edit(SupplierVM model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(mapper.Map<Supplier>(model));
                return RedirectToAction("Index");
            }
            else return View(model);

        }

		public IActionResult Create()
		{
            var data = country.getAll();
            var res = mapper.Map<IEnumerable<CountryVM>>(data);

            //data.photourl = fileUploader.UploadFile("/Files", model.Photo); ;
            //data.Fileurl = fileUploader.UploadFile("/Files", model.File); ;

            ViewBag.countries = new SelectList(res, "id", "name");
            return View();
		}
        [HttpPost]
        public IActionResult Create(SupplierVM model)
        {
            var res = mapper.Map<Supplier>(model);
            repository.Create(res);
            return RedirectToAction("Index");
        }

            public JsonResult getCities(int id)
        {
            var data = city.getAll(id);
            var res = mapper.Map<IEnumerable<CityVM>>(data);

            return Json(res);
        }
        public JsonResult getDistricts(int id)
        {
            var data = district.getAll(id);
            var res = mapper.Map<IEnumerable<DistrictVM>>(data);

            return Json(res);
        }
    }
}
