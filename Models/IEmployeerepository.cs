using System.Collections;
using System.Collections.Generic;

namespace WebApplication1.models
{
    public interface IEmployeerepository
    {
        Employee GetEmployee(int Id);

        List<Employee> GetAll();
        Employee add(Employee employee);
    }
}
