using EntityFrameCoreInMemory.Entities;

namespace EntityFrameCoreInMemory.Repository
{
    public interface IEmployeeRepo : IRepository<Employee>
    { 
        void Add(Employee item);
        Employee CreateItem();
        Employee GetById(int id);
        void Remove(Employee item);
        void Save();
        IEnumerable<Employee> GetAll();

    }
}
