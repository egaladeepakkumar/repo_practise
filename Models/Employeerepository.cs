using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Data;

namespace WebApplication1.models
{
    
    public class Employeerepository : IEmployeerepository
    {
        private readonly IConfiguration _configuration;
        List<Employee> _Listemp;
        public Employeerepository(IConfiguration configuration)
        {
            _configuration =configuration;
            //_Listemp = new List<Employee>()
            //{
            //   new Employee(){ Id = 1,Name = "naveen",Age = 22,Email = "naveen@gmail.com" },
            //   new Employee(){ Id = 2,Name = "raj",Age = 12,Email = "raj@gmail.com" },
            //   new Employee(){ Id = 3,Name = "deepakkumar",Age = 32,Email = "deepakkumar@gmail.com" }
            //};
        }

       

        public Employee GetEmployee(int Id)
        {
            return _Listemp.FirstOrDefault(x => x.Id == Id);
        }

        public List<Employee> GetAll()
        {
            _Listemp = new List<Employee>();
            try
            { using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("default")))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from [firstcoredb].[dbo].[table]", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {

                        int id = rdr.GetInt32("Id");
                        string name = rdr.GetString("Name");
                        int age = rdr.GetInt32("Age");
                        string email = rdr.GetString("Email");
                        _Listemp.Add(new Employee
                        {
                            Id = id,
                            Name = name,
                            Age = age,
                            Email=email

                        });
                    }
                }
                
            }
            catch(Exception ex)
                {
                Console.WriteLine(ex.Message);
            }
            return _Listemp;
        }

        public Employee add(Employee employee)
        {
            employee.Id = _Listemp.Max(x => x.Id) + 1;
            _Listemp.Add(employee);
            return employee;
        }
    }
}


       


