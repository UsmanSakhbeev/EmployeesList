using System;
using System.Windows;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddWindow.xaml
    /// </summary>
    public partial class EmployeeAddWindow : Window
    {
        public Employee ResultEmployee { get; private set; }
        public event Action<Employee> OnEmployeeSet;
        public EmployeeAddWindow(System.Collections.ObjectModel.ObservableCollection<Department> departments)
        {
            InitializeComponent();
            DepartmentInput.ItemsSource = departments;
        }
        private void EmployeeInput_Click(object sender, RoutedEventArgs e)
        {
            ResultEmployee = new Employee(NameInput.Text, SurnameInput.Text, Convert.ToInt32(IdInput.Text), (Department)DepartmentInput.SelectedItem, Convert.ToInt32(SalaryInput.Text));
            OnEmployeeSet?.Invoke(ResultEmployee);
        }
    }
}
