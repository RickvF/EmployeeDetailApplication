using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailApplication.Services
{
    //Interface to specify CRUD operations. Can be used for REST, SQL, Mongo
    public interface IDataService<T>
    {
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);

    }
}
