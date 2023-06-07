using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;


namespace WiredBrainCoffee.StorageApp
{
    internal class Program
    {
        #region Demo interface variant includes: Covariance and Contravariance
        public class Base
        {
            public void DoSomething() => Console.WriteLine($"Doing from {this.GetType().Name}");
            public void DoMore() => Console.WriteLine($"aaaaaaaaaaaaaaa");
        }

        public class Derived : Base
        {
            public void DoMore() => Console.WriteLine($"Doing from {this.GetType().Name}");
        }

        //Covariance ~ Func delegate => return value and with/without input
        interface IProduce<out T>
        {
            T Produce();
        }

        //Contravariance ~ Action delegate => NO return and with/without input
        interface IConsumer<in T>
        {
            void Consumer(T item);
        }

        #endregion

        static void Main(string[] args)
        {
            #region MAIN Demo interface variant includes: Covariance and Contravariance
            //IConsumer<Base> consumerBase = null;
            //consumerBase.Consumer(new Base());
            //consumerBase.Consumer(new Derived());

            //IConsumer<Derived> consumerDerived = null;
            //consumerDerived.Consumer(new Derived());


            //IProduce<Base> produceBase = null;
            //Base a = produceBase.Produce();


            //IProduce<Derived> produceDerived = null;
            //Base c = produceDerived.Produce();
            //Derived d = produceDerived.Produce();

            //Base x = new Base();
            //Base x2 = new Derived();

            //x.DoSomething();
            //x2.DoMore();

            //Derived x3 = new Derived();
            //x3.DoSomething();
            //x3.DoMore();
            #endregion

            ListRepositoryProcess();

        }

        private static void ListRepositoryProcess()
        {
            EmployeeRepository();
            OrganizationRepository();
        }

        #region EmployeeRepository in SQL
        private static void EmployeeRepository()
        {
            //Action<Employee> itemAddedEmployee = new Action<Employee>(EntityAdded);

            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.itemAdded += EmployeeRepository_itemAdded;

            //Action<Manager> itemAddedManager = itemAddedEmployee;

            AddNewListEmployee(employeeRepository);
            AddNewListManager(employeeRepository);

            GetEmployeeById(employeeRepository);
            GetAllEntities(employeeRepository);
        }

        private static void EmployeeRepository_itemAdded(object? sender, Employee e)
        {
            Console.WriteLine($"FirstName: {e.FirstName} was added");
        }

        private static void EntityAdded<T>(T item)
        {
            var employee = item;
            Console.WriteLine($"FirstName: {employee} was added");
        }

        private static void AddNewListManager(IWriteRepository<Manager> employeeRepository)
        {
            var listManagers = new[]
            {
                new Manager { Id = 7, FirstName = "HoaZZ", LastName = "Van" },
                new Manager { Id = 6, FirstName = "TrangZZ", LastName = "Thu" },
                new Manager { Id = 4, FirstName = "HoangZZ", LastName = "Nguyen" },
                new Manager { Id = 5, FirstName = "HoangZZ", LastName = "Nguyen" },
            };

            var newManager = new Manager{ Id = 8, FirstName = "HoaZZdsdf", LastName = "Vansdfsd" };

            var copiedManager = newManager.Copy();
            if (copiedManager != null)
            {
                copiedManager.LastName += "_Copied";
                var newList = listManagers.ToList();
                newList.Add(copiedManager);
                listManagers = newList.ToArray();
            }


            RepositoryExtentions.AddBatch(employeeRepository, listManagers);
            //employeeRepository.AddBatch(listManagers); ~ tương tự như cách trên
        }
        private static void AddNewListEmployee(IWriteRepository<Employee> employeeRepository)
        {
            var listEmps = new[]
            {
                new Employee { Id = 1, FirstName = "Hoang", LastName = "Nguyen" },
                new Employee { Id = 2, FirstName = "Trang", LastName = "Thu" },
                new Employee { Id = 3, FirstName = "Hoa", LastName = "Van" },
            };
            RepositoryExtentions.AddBatch(employeeRepository, listEmps);
        }
        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.GetById(2));
        }
        #endregion


        #region EmployeeRepository in List
        private static void OrganizationRepository()
        {
            var organizationRepository = new ListRepository<Organization>();
            AddNewListOrganization(organizationRepository);
            GetOrganizationById(organizationRepository);
            GetAllEntities(organizationRepository);
            Console.ReadLine();
        }
        private static void AddNewListOrganization(IWriteRepository<Organization> organizationRepository)
        {
            var listOrg = new[]
            {
                new Organization { Name = "CongTyA" },
                new Organization { Name = "CongTyB" },
                new Organization { Name = "CongTyC" }
            };
            RepositoryExtentions.AddBatch(organizationRepository, listOrg);
        }
        private static void GetOrganizationById(IRepository<Organization> organizationRepository)
        {
            Console.WriteLine(organizationRepository.GetById(1));
        }
        #endregion

        private static void GetAllEntities(IReadRepository<IEntity> organizationRepository)
        {
            var listOrgs = organizationRepository.GetAll();
            foreach (var organization in listOrgs)
            {
                Console.WriteLine(organization);
            }
        }
    }
}