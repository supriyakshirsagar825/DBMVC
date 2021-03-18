using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLModelLayer;

namespace CLDataBaseLayer.DBOperations
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities())
            {
                tblEmployee employee = new tblEmployee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salary = model.Salary,
                    Gender = model.Gender,
                    //AddressId = model.Address.Id,
                    tblAddress = new tblAddress()
                    {
                        AddressLine1 = model.Address.AddressLine1,
                        AddressLine2 = model.Address.AddressLine2,
                        City = model.Address.City,
                        Country = model.Address.Country,
                        State = model.Address.State
                    }
                };

                context.tblEmployee.Add(employee);
                context.SaveChanges();
                return employee.Id;
            }
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.tblEmployee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary,
                    AddressId = x.AddressId,
                    Gender = x.Gender,
                    Address = new AddressModel()
                    {
                        Id = x.tblAddress.Id,
                        AddressLine1 = x.tblAddress.AddressLine1,
                        AddressLine2 = x.tblAddress.AddressLine2,
                        City = x.tblAddress.City,
                        Country = x.tblAddress.Country,
                        State = x.tblAddress.State
                    }
                }).ToList();
                return result;
            }
        }
        public EmployeeModel GetEmployee(int Id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.tblEmployee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary,
                    AddressId = x.AddressId,
                    Gender = x.Gender,
                    Address = new AddressModel()
                    {
                        Id = x.tblAddress.Id,
                        AddressLine1 = x.tblAddress.AddressLine1,
                        AddressLine2 = x.tblAddress.AddressLine2,
                        City = x.tblAddress.City,
                        Country = x.tblAddress.Country,
                        State = x.tblAddress.State
                    }
                }).FirstOrDefault(x=>x.Id==Id);
                return result;
            }
        }

        public bool UpdateEmployee(int id,EmployeeModel model)
        {
            using(var context=new EmployeeDBEntities())
            {
                tblEmployee emp = context.tblEmployee.FirstOrDefault(x => x.Id == id);
                if(emp!=null)
                {
                    emp.FirstName = model.FirstName;
                    emp.LastName = model.LastName;
                    emp.Salary = model.Salary;
                    emp.Gender = model.Gender;
                    //AddressId = model.Address.Id;
                    emp.tblAddress.AddressLine1 = model.Address.AddressLine1;
                    emp.tblAddress.AddressLine2 = model.Address.AddressLine2;
                    emp.tblAddress.City = model.Address.City;
                    emp.tblAddress.Country = model.Address.Country;
                    emp.tblAddress.State = model.Address.State;
                    
                }
                context.SaveChanges();
                return true;
            }
        }
    }
}
