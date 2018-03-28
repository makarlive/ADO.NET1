using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ADO.NET_LINQ2
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
        public Employee(int id,string fname,string lname,int age,int depid)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            Age = age;
            DepId = depid;
        }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Department(int id,string country,string city)
        {
            Id = id;
            Country = country;
            City = city;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department(1,"Ukraine","DNR"),
                new Department(2,"Ukraine","Kyiv"),
                new Department(3,"France","Paris"),
                new Department(4,"Russian","Moscow")
            };
            List<Employee> emloyees = new List<Employee>()
            {
                new Employee(1,"Tamara","Ivanova",22,2),
                new Employee(2,"Nikita","Larin",33,1),
                new Employee(3,"Alica","Ivanova",43,3),
                new Employee(4,"Lida","Marusyk",22,2),
                new Employee(5,"Lida","Voron",36,4),
                new Employee(6,"Ivan","Kalyta",22,2),
                new Employee(7,"Nikita","Krotov",27,4)
            };

            Console.WriteLine("Select from Ukraine but not DNR");
            var result1 = from emp in emloyees
                          from dep in departments
                          where emp.DepId == dep.Id &&
                                dep.Country == "Ukraine" && dep.City != "DNR"
                          select new
                          {
                              FirstName = emp.FirstName,
                              LastName = emp.LastName,
                              City = dep.City
                          };

            foreach (var emp in result1)
            {
                Console.WriteLine(emp.FirstName+" "+emp.LastName+" "+emp.City);
            }

            Console.WriteLine();
            Console.WriteLine("Select Country's without re");
            var result2 = (from dep in departments
                           select dep.Country).Distinct();
                          

            foreach (var count in result2)
            {
                Console.WriteLine(count);
            }

            Console.WriteLine();
            Console.WriteLine("Select TOP3");

            var result3 = (from emp in emloyees
                           where emp.Age > 25
                           select emp).Take(3);

            foreach (var emp in result3)
            {
                Console.WriteLine(emp.FirstName+" "+emp.LastName+" "+emp.Age);
            }

            Console.WriteLine();
            Console.WriteLine("Select from Kyiv and Age>23");

            var result4 = from emp in emloyees
                          from dep in departments
                          where emp.DepId == dep.Id &&
                                emp.Age > 23 && dep.City == "Kyiv"
                          select emp;

            foreach (var emp in result4)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName + " " + emp.Age);
            }


        }
    }
}
