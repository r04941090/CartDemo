using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Repositories.Interface
{
    public interface IRepository
    {
        DbContext _ctx { get; }
        void Create<T>(T value) where T : class;
        void Update<T>(T value) where T : class;
        void Delete<T>(T value) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        void SaveChange();
    }
}
