using Estate.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estate.Data.Entities;
using Estate.Data.Contacts;
using Estate.Core.Contracts;

namespace Estate.Business
{
    public class UserEngine : BusinessEngineBase, IUserEngine
    {
        private readonly IUserRepository _userRepository;
        public UserEngine(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(User us)
        {
                _userRepository.Add(us);
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll(x => !x.IsDeleted);
        }

        public IQueryable<User> GetAll(int skip, int take)
        {
            return _userRepository.GetAll(skip, take).Where(x => !x.IsDeleted);

        }

        public async Task<User> GetAsync(int id)
        {
            return await  _userRepository.GetAsync(id);
        }

        public  void Update(User user)
        {
            _userRepository.Update(user);
            
        }
    }
}
