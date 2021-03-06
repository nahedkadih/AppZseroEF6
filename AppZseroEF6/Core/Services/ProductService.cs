﻿using AppZseroEF6.Data.Infrastructure;
using AppZseroEF6.Data.Repositories;
using AppZseroEF6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppZseroEF6.Service
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        Product GetProduct(string id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void CreateProduct(Product product)
        {
            _repository.AddAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            _repository.Delete(product);
        }

        public Product GetProduct(string id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
