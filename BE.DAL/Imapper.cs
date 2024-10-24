using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DAL
{
    internal interface Imapper<T>
    {

        List<T> GetAll();
        T FindById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
