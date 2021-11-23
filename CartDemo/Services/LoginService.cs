using CartDemo.Models.DataModels;
using CartDemo.Repositories.Interface;
using CartDemo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository _repository;
        public LoginService(IRepository repository)
        {
            _repository = repository;
        }
        public int GetUserId(string Account)
        {
            int UserId;
            try
            {
                UserId = _repository.GetAll<Member>().First(x => x.Account == Account).UserId;
            }
            catch
            {
                throw;
            }
            return UserId;
        }
    }
}
