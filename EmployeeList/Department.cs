using System.ComponentModel;

namespace EmployeeList
{
    public class Department : INotifyPropertyChanged
    {
        private string _name;

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
        public Department(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
