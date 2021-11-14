using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeList
{
    public class Employee
    {
        string _name;
        private string _surname;
        private int _id;
        private Department _department;
        private int _salary;

        public string Name { get => _name; set { _name = value; } }
        public string Surname { get => _surname; set { _surname = value; } }
        public int ID { get => _id; set { _id = value; } }
        public Department Department { get => _department; set { _department = value; } }
        public int Salary { get => _salary; set { _salary = value; } }

        public Employee(string name, string surname, int id, Department department, int salary)
        {
            Name = name;
            Surname = surname;
            ID = id;
            Department = department;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{Name}\t{Surname}\t{ID}\t{Department}\t{Salary}";
        }
    }
}
