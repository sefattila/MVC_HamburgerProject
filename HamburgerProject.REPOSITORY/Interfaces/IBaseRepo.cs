using HamburgerProject.CORE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.REPOSITORY.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> expression);
        T GetDefault(Expression<Func<T, bool>> expression);
        T GetDefaultById(int id);
        List<T> GetDefaults(Expression<Func<T, bool>> expression);
        List<T> GetAll();
    }
}
