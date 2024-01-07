using EasyPay.DataAccess.Abstract;
using EasyPay.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }
    }
}
