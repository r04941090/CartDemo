using CartDemo.Models.DataModels;
using CartDemo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Repositories
{
    public class Repository : IRepository
    {
        private CartDemo20211122Context ctx;
        public DbContext _ctx { get => ctx;}

        public Repository(CartDemo20211122Context context)
        {
            ctx = context;
        }
        public void Create<T>(T value) where T : class
        {
            _ctx.Entry(value).State = EntityState.Added;
        }
        public void Update<T>(T value) where T : class
        {
            _ctx.Entry(value).State = EntityState.Modified;
        }
        public void Delete<T>(T value) where T : class
        {
            _ctx.Entry(value).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _ctx.Set<T>();
        }

        public void SaveChange()
        {
            _ctx.SaveChanges();
        }
    }
}
