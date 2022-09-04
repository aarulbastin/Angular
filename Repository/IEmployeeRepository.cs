using AngularWebAPIProject.DataDB;
using EmployeeViewAngular.Model;

namespace AngularWebAPIProject.Repository
{
    public interface IEmployeeRepository 
    {
       List<Employee> GetEmployeeList();
        bool checkValidUser(string username);
        bool RegisterUser(EmployeeModel username);
    }
}
