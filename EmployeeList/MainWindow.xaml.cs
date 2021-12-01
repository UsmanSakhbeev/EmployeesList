using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Controls;
using System;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

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
            this.DataContext = this;
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
                    //lbEmployee.Items.Refresh();
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
                    //lbDepartment.Items.Refresh();
                    _selectedDepartment = null;
                    lbDepartment.UnselectAll();
                };
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string createExpression = @"CREATE TABLE[dbo].[EmployeesTable]([Id]	INT IDENTITY(1,1) NOT NULL,
							  [Name] NVARCHAR(MAX) NOT NULL,
							  [Surname] NVARCHAR(MAX) NOT NULL,
							  [Department] NVARCHAR(MAX) NULL,
							  [Salary] INT NULL,
							  CONSTRAINT[PK_dbo.EmployeesTable] PRIMARY KEY CLUSTERED ([Id] Asc));";
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial catalog = EmployeesListDB; Integrated Security = True";
            //string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial catalog = EmployeesListDB; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("connection checking");
            connection.Close();
        }
    }
}
