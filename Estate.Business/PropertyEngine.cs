using Estate.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estate.Data.Entities;
using Estate.Data.Contacts;
using Estate.Core.SearchModel;

namespace Estate.Business
{
    public class PropertyEngine : IPropertyEngine
    {       
        private readonly IPropertyRepository _propertyRepository;

        public PropertyEngine(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public void Add(Property pro)
        {
             _propertyRepository.Add(pro);
        }

        public IQueryable<Property> GetAll()
        {
            return _propertyRepository.GetAll(x => !x.IsDeleted);
        }
        public IQueryable<Property> GetAll(PropertySearchModel searchModel)
        {
            var result = _propertyRepository.GetAll(x => !x.IsDeleted);

            if (searchModel!=null)
            {

            if (searchModel.Id.HasValue)
                result = result.Where(x => x.Id == searchModel.Id);
            if (!string.IsNullOrEmpty(searchModel.City))
                result = result.Where(x => x.City.Contains(searchModel.City));
            if (!string.IsNullOrEmpty(searchModel.Adress))
                result = result.Where(x => x.GeoLocation.Address.Contains(searchModel.Adress));
            if (searchModel.PriceFrom.HasValue)
                result = result.Where(x => x.Price >= searchModel.PriceFrom);
            if (searchModel.PriceTo.HasValue)
                result = result.Where(x => x.Price <= searchModel.PriceTo);

                if (searchModel.TypeOfProperty <= 2)
                {
                    if (searchModel.TypeOfProperty==0)
                    {
                    result = result.Where(x => x.TypeOfProperty == false);

                    }
                    else
                    {
                        result = result.Where(x => x.TypeOfProperty == true);

                    }

                }


                if (searchModel.Status <=2)
                result = result.Where(x => x.Status == searchModel.Status);

                if (searchModel.CategoryId != 0)
                    result = result.Where(x => x.Category.Id == searchModel.CategoryId);
            
            }

                return result;

        }

     public Property Get(int id)
        {
            return _propertyRepository.Get(id);
        }

        public IQueryable<Property> GetAll(int skip, int take)
        {
            return _propertyRepository.GetAll(skip, take).Where(x => !x.IsDeleted);
        }

        public async Task<Property> GetAsync(int id)
        {
            return await _propertyRepository.GetAsync(id);
        }
        public async Task<Property> Delete(int id)
        {
             var prop=   await _propertyRepository.GetAsync(id);
            prop.IsDeleted = true;
         await   _propertyRepository.SaveChangeAsync();
            return prop;
        }


        public void Update(Property pro)
        {
         bool result=
                _propertyRepository.Update(pro);
        }
    }
}
