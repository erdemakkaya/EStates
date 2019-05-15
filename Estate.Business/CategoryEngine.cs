using Estate.Business.Contracts;
using Estate.Data.Contacts;
using Estate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Business
{
   public class CategoryEngine:BusinessEngineBase, ICategoryEngine
    {
        private readonly ICategoryRepository _categoryRepository;
            public CategoryEngine(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> GetAsync(int id)
        {
         return await  _categoryRepository.GetAsync(id);
        }
        public void Add(Category cat)
        {
            _categoryRepository.Add(cat);
        }
        //public async Task<Category> Delete(int id)
        //{
        //    return await _categoryRepository.DeleteAsync(id);
        //}
        public void Update(Category cat)
        {
            _categoryRepository.Update(cat);
        }
        public IQueryable<Category> GetAll(int skip,int take)
        {
            return _categoryRepository.GetAll(skip, take).Where(x=>!x.IsDeleted);
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll(x => !x.IsDeleted);
        }

        public Task<Category> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
