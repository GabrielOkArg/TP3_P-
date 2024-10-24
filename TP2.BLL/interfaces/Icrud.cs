using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.BLL.interfaces
{
    public interface Icrud<T>
    {

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(int id);
        List<T> GetAll();
    }
}
