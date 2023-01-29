using AutoMapper;
using Ecommerce.BLL.Model;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
	public class DomainProfile :Profile
	{
		public DomainProfile()
		{
			CreateMap<Product, ProductVM>();
			CreateMap<ProductVM, Product>();

			CreateMap<Order, OrderVM>();
			CreateMap<OrderVM, Order>();

			CreateMap<Customer, CustomerVM>();
			CreateMap<CustomerVM, Customer>();

			CreateMap<OrderProduct, OrderProductVM>();
			CreateMap<OrderProductVM, OrderProduct>();

            CreateMap<SupplierVM, Supplier>();
            CreateMap<Supplier, SupplierVM>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();
        }
	}
}
