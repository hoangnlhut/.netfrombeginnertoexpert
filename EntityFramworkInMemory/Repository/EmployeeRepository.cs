using EntityFrameCoreInMemory.DBContext;
using EntityFrameCoreInMemory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameCoreInMemory.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        public EmployeeRepository() {
            using (var context = new ApiContext())
            {
                var emps = new List<Employee>
                {
                new Employee
                {
                    FirstName ="Hoang",
                    LastName ="Nguyen",
                      Id = 5,
                },
                new Employee
                {
                    FirstName ="Trang",
                    LastName ="Thu",
                    Id=6,
                }
                };
                context.Employees.AddRange(emps);
                context.SaveChanges();
            }
        }

        public void Add(Employee item)
        {
            using (var context = new ApiContext())
            {
                context.Add(item);
            }
            return;
        }

        public Employee CreateItem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employee = new List<Employee>();
            using (var context = new ApiContext())
            {
                employee = context.Employees.ToList();
            }
            return employee;
        }

        public Employee? GetById(int id)
        {
            var em = new Employee();
            using (var context = new ApiContext())
            {
                em = context.Employees.Find(id);
            }
            return em;
        }

        public void Remove(Employee item)
        {
            using (var context = new ApiContext())
            {
                context.Employees.Remove(item);
            }
            return;
        }

        public void Save()
        {
            using (var context = new ApiContext())
            {
                context.SaveChanges();
            }
            return;
        }
    }
}
