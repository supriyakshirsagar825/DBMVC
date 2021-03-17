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
            using(var context= new EmployeeDBEntities())
            {
                tblEmployee employee = new tblEmployee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salary = model.Salary,
                    Gender = model.Gender,
                    //AddressId = model.Address.Id,
                    //tblAddress = new tblAddress()
                    //{
                    //    AddressLine1 = model.Address.AddressLine1,
                    //    AddressLine2 = model.Address.AddressLine2,
                    //    City = model.Address.City,
                    //    Country = model.Address.Country,
                    //    State = model.Address.State
                    //}
                };

                context.tblEmployee.Add(employee);
                context.SaveChanges();
                return employee.Id;
            }

        }
    }
}
