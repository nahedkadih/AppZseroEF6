﻿using AppZseroEF6.Data.Infrastructure;
using AppZseroEF6.Data.Repositories;
using AppZseroEF6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppZseroEF6.Service
{
    public interface ICategoryService
    {
        IQueryable<Category> GetCategories();
        Category GetCategory(long id);
        void CreateCategory(Category category);
        void SaveChanges();
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Category> GetCategories()
        {
            return _repository.GetAll();
        }

        public Category GetCategory(long id)
        {
            return _repository.GetById(id);
        }
        public void CreateCategory(Category category)
        {
            _repository.Add(category);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
