using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T data);
        void Update(T data);
        List<T> GetById(Predicate<T> predicate);
        List<T> GetAllByTeacher(Predicate<T> predicate);
        List<T> GetAllByRoom(Predicate<T> predicate);
      
    }
}
