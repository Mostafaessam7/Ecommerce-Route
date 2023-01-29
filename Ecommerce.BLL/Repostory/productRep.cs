using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Model;
using Ecommerce.DAL.Database;
using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Ecommerce.BLL.Repostory
{
    public class productRep : IProductRep
    {
		private readonly ProductContext db;
		private readonly IMapper mapper;

		//ProductContext db = new ProductContext();

		public productRep(ProductContext db , IMapper mapper)
        {
			this.db = db;
			this.mapper = mapper;
		}
        /// <summary>
        /// Method to get all data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll()
        {
            var data = db.Products.Select(x => x);
            return data;

        }

        /// <summary>
        /// Method to get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Product GetProById(int id)
        {
            var data = db.Products.Where(x => x.id == id).FirstOrDefault();
     
            return (data);
        }

        /// <summary>
      /// Create
      /// </summary>
      /// <param name="proVM"></param>
        public void Create(Product proVM)
        {
            
            db.Products.Add(proVM);
            db.SaveChanges();

        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="proVM"></param>
        public void Update(Product proVM)
        {
    
            db.Entry(proVM).State=EntityState.Modified;
            db.SaveChanges();

        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="proVM"></param>
        public void Delete(Product proVM)
        {
            
            db.Products.Remove(proVM);
            db.SaveChanges();

        }
    }
}
