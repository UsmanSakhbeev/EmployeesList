using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Department> departments = new ObservableCollection<Department>();
        private Department _selectedDepartment;
        private Employee _selectedEmployee;
        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            lbDepartment.ItemsSource = departments;
            lbEmployee.ItemsSource = employees;
            employees.Add(new Employee("Ilshat", "Safin", 1, null, 1));

        }
        private void lbEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            _selectedEmployee = (Employee)e.AddedItems[0];
            _selectedDepartment = null;
        }
        private void lbDepartment_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            _selectedDepartment = (Department)e.AddedItems[0];
            _selectedEmployee = null;
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAddWindow employeeAddWindow = new EmployeeAddWindow(departments);
            employeeAddWindow.Owner = this;
            employeeAddWindow.OnEmployeeSet += (newEmployee) =>
            {
                employees.Add(newEmployee);
                employeeAddWindow.Close();
            };
            employeeAddWindow.Show();
        }
        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            DepartmentAddWindow departmentAddWindow = new DepartmentAddWindow();
            departmentAddWindow.Owner = this;
            departmentAddWindow.OnDepartmentSet += (newDepartment) =>
            {
                departments.Add(newDepartment);
                departmentAddWindow.Close();
            };
            departmentAddWindow.Show();
        }

        private void ChangeSelected_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEmployee != null)
            {
                EmployeeChangeWindow employeeChangeWindow = new EmployeeChangeWindow(employees, departments, _selectedEmployee);
                employeeChangeWindow.Owner = this;
                employeeChangeWindow.Show();
                employeeChangeWindow.Closed += (_, __) =>
                {
                    lbEmployee.Items.Refresh();
                    _selectedEmployee = null;
                    lbEmployee.UnselectAll();
                };



            }
            if (_selectedDepartment != null)
            {
                DepartmentChangeWindow departmentChangeWindow = new DepartmentChangeWindow(departments, _selectedDepartment);
                departmentChangeWindow.Owner = this;
                departmentChangeWindow.Show();
                departmentChangeWindow.Closed += (_, __) =>
                {
                    lbDepartment.Items.Refresh();
                    _selectedDepartment = null;
                    lbDepartment.UnselectAll();
                };


            }
        }
    }
}
