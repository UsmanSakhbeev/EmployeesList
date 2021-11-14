using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
    public class Department
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public Department(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
