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
        public string[] GetRolesForUser(string username)
        {
            using(var context= new EmployeeDBEntities11())
            {
                var result = (from usr in context.User
                              join rol in context.Role on usr.Id equals rol.UserId
                              where usr.UserName == username
                              select rol.Role1).ToArray();
                return result;
            }
           
        }
        public bool Login(MemberShip model)
        {
            using(var context= new EmployeeDBEntities11())
            {
               return context.User.Any(x => x.UserName == model.UserName && x.Password == model.Password);
            }
        }

        public int SignUP(MemberShip model, List<string> liststr)
        {
            using (var context = new EmployeeDBEntities11())
            {
                CLDataBaseLayer.User user = new CLDataBaseLayer.User();
                user.UserName = model.UserName;
                user.Password = model.Password;
                foreach (var item in liststr)
                {
                    Role r = new Role() { Role1 = item };
                    user.Role.Add(r);
                }
                context.User.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities11())
            {
                DBEmployee employee = new DBEmployee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salary = model.Salary,
                    Gender = model.Gender,
                    AddressId = model.Address.Id,
                    DBAddress = new DBAddress()
                    {
                        AddressLine1 = model.Address.AddressLine1,
                        AddressLine2 = model.Address.AddressLine2,
                        City = model.Address.City,
                        Country = model.Address.Country,
                        State = model.Address.State
                    }
                };

                context.DBEmployee.Add(employee);
                context.SaveChanges();
                return employee.Id;
            }
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new EmployeeDBEntities11())
            {
                var result = context.DBEmployee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary,
                    AddressId = x.AddressId,
                    Gender = x.Gender,
                    Address = new AddressModel()
                    {
                        Id = x.DBAddress.Id,
                        AddressLine1 = x.DBAddress.AddressLine1,
                        AddressLine2 = x.DBAddress.AddressLine2,
                        City = x.DBAddress.City,
                        Country = x.DBAddress.Country,
                        State = x.DBAddress.State
                    }
                }).ToList();
                return result;
            }
        }
        public EmployeeModel GetEmployee(int Id)
        {
            using (var context = new EmployeeDBEntities11())
            {
                var result = context.DBEmployee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary,
                    AddressId = x.AddressId,
                    Gender = x.Gender,
                    Address = new AddressModel()
                    {
                        Id = x.DBAddress.Id,
                        AddressLine1 = x.DBAddress.AddressLine1,
                        AddressLine2 = x.DBAddress.AddressLine2,
                        City = x.DBAddress.City,
                        Country = x.DBAddress.Country,
                        State = x.DBAddress.State
                    }
                }).FirstOrDefault(x=>x.Id==Id);
                return result;
            }
        }

        public bool UpdateEmployee(int id,EmployeeModel model)
        {
            using (var context = new EmployeeDBEntities11())
            {
                var emp = new DBEmployee();//context.tblEmployee.FirstOrDefault(x => x.Id == id);

                emp.Id = id;
                emp.FirstName = model.FirstName;
                emp.LastName = model.LastName;
                emp.Salary = model.Salary;
                emp.Gender = model.Gender;
                emp.AddressId = model.AddressId;
                emp.DBAddress = new DBAddress()
                {

                    Id = model.Address.Id,
                    AddressLine1 = model.Address.AddressLine1,
                    AddressLine2 = model.Address.AddressLine2,
                    City = model.Address.City,
                    Country = model.Address.Country,
                    State = model.Address.State,
                };

                
                context.Entry(emp.DBAddress).State = System.Data.Entity.EntityState.Modified;
                context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployeeByID(int Id,int addid)
        {
            using(var context= new EmployeeDBEntities11())
            {
                //var employee = new DBEmployee();
                //employee.Id = Id;
                //DBAddress add = new DBAddress();
                //if (addid != 0)
                //{

                //    add.Id = addid;
                //}



                //context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                ////context.Entry(employee.DBAddress).State = System.Data.Entity.EntityState.Deleted;
                //context.SaveChanges();
                //context.Entry(add).State = System.Data.Entity.EntityState.Deleted;
                //context.SaveChanges();
                //return true;
                var employee = context.DBEmployee.FirstOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    context.DBAddress.Remove(employee.DBAddress);
                    context.DBEmployee.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
