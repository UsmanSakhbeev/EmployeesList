using System.ComponentModel;


namespace EmployeeList
{
    public class Employee : INotifyPropertyChanged
    {
        string _name;
        private string _surname;
        private int _id;
        private Department _department;
        private int _salary;

        public string Name
        {
            get => _name;
            set
            {
                if (this._name != value)
                {
                    _name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (this._surname != value)
                {
                    _surname = value;
                    this.NotifyPropertyChanged("Surname");
                }
            }
        }
        public int ID
        {
            get => _id;
            set
            {
                if (this._id != value)
                {
                    _id = value;
                    this.NotifyPropertyChanged("ID");
                }
            }
        }
        public Department Department
        {
            get => _department;
            set
            {
                if (this._department != value)
                {
                    _department = value;
                    this.NotifyPropertyChanged("Department");
                }
            }
        }
        public int Salary
        {
            get => _salary;
            set
            {
                if (this._salary != value)
                {
                    _salary = value;
                    this.NotifyPropertyChanged("Salary");
                }
            }
        }

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
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
