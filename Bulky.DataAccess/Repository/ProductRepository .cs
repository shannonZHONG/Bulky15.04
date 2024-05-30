﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
        public class ProductRepository :Repository<Product>, IProductRepository
        {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

      

        public void Update(Product obj)
        {
            var objFromDb =_db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
