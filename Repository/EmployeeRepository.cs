using AngularWebAPIProject.DataDB;
using AngularWebAPIProject.Repository;
using EmployeeViewAngular.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AngularWebAPIProject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDBContext dataContext;
        public EmployeeRepository(EmployeeDBContext _context)
        {
            dataContext = _context;
        }
        public List<Employee> GetEmployeeList()
        {
            return dataContext.Employees.ToList();
        }
       public bool checkValidUser(string username)
        {
            //var emp = from s in dataContext.Employees
            //          where s.EmployeeName == username
            //          select (s);
            var emp =   dataContext.Employees.Where(s => s.EmployeeName == username).Select( s=> (s));
            //await Task.WhenAll(emp);
            if(emp.Count()==0)
            {
                return  false;
            }

            return true;
        }

        public bool RegisterUser(EmployeeModel userdetails)
        {
            try
            {
                var Newemployee = new Employee()
                {
                    EmployeeName = userdetails.Name,
                    Salary = userdetails.Salary,
                    Userpassword = userdetails.password
                };
                dataContext.Employees.Add(Newemployee);
                dataContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public enum ResponseStatus
        {
            Success,
            Fail,
            AlreadyRegistered
        }
    }
}
