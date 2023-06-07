using EntityFrameCoreInMemory.DBContext;
using EntityFrameCoreInMemory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameCoreInMemory.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        private readonly ApiContext _apiContext;
        private readonly DbSet<Employee> _apiDb;

        public EmployeeRepository(ApiContext apiContext) {
            _apiContext = apiContext;
            _apiDb = _apiContext.Set<Employee>();
        }

        public void Add(Employee item)
        {
            _apiDb.Add(item);
        }

        public Employee CreateItem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _apiDb;
        }

        public Employee? GetById(int id)
        {
            return _apiDb.Find(id);
        }

        public void Remove(Employee item)
        {
            _apiDb.Remove(item);
        }

        public void Save()
        {
            _apiContext.SaveChanges();
        }
    }
}
