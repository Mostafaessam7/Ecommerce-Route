using Abp.Domain.Repositories;
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
    public class OrderController : Controller
    {

        #region Fields

        private readonly IMapper mapper;
        private readonly IOrderRep repository;
        private readonly ICustomerRep customer;
        private readonly IProductRep product;
        private readonly IOrderProductRep orderProductRep;

        #endregion


        #region Ctor

        public OrderController(IMapper mapper,
            IOrderRep repository,
            ICustomerRep customer,
            IProductRep product ,
            IOrderProductRep orderProductRep)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.customer = customer;
            this.product = product;
            this.orderProductRep = orderProductRep;
        }

        #endregion

        #region Action

        public IActionResult Index()
        {
            var data = repository.GetAll();

            return View(mapper.Map<IEnumerable<OrderVM>>(data));
        }
        public IActionResult Create()
        {
            var Customers = customer.GetAll();
            var Products = product.GetAll();
            ViewBag.cust = new SelectList(Customers, "id", "name");
            ViewBag.prod = new SelectList(Products, "id", "name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderVM model)
        {

            var data = repository.Create(mapper.Map<Order>(model));
            foreach (var item in model.ProductId)
            {
                orderProductRep.Create(data, item);
            }
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var data = repository.GetProById(id);

            return View(mapper.Map<OrderVM>(data));

        }
        public IActionResult Delete(int id)
        {
            var data = repository.GetProById(id);
            repository.Delete(data);
            return RedirectToAction("Index");
        }


        public JsonResult Count()
        {
           var data= repository.count();
            return Json(data);
        }

        #endregion
    }
}
