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
    public class PhotoEngine:BusinessEngineBase,IPhotoEngine
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoEngine(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
        public async Task<Photo> GetAsync(int id)
        {
            return await _photoRepository.GetAsync(id);
        }
        public void Add(Photo cat)
        {
            _photoRepository.Add(cat);
        }
        //public async Task<Photo> Delete(int id)
        //{
        //    return await _photoRepository.DeleteAsync(id);
        //}
        public void Update(Photo cat)
        {
            _photoRepository.Update(cat);
        }
        public IQueryable<Photo> GetAll(int skip, int take)
        {
            return _photoRepository.GetAll(skip, take).Where(x => !x.IsDeleted);
        }

        public IQueryable<Photo> GetAll()
        {
            return _photoRepository.GetAll(x => !x.IsDeleted);
        }

        public Task<Photo> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
