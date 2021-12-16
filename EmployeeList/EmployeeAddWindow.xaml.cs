using System;
using System.Windows;
using System.Data;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddWindow.xaml
    /// </summary>
    public partial class EmployeeAddWindow : Window
    {
        //public Employee ResultEmployee { get; private set; }
        //public event Action<Employee> OnEmployeeSet;
        //public EmployeeAddWindow(System.Collections.ObjectModel.ObservableCollection<Department> departments)
        //{
        //    InitializeComponent();
        //    DepartmentInput.ItemsSource = departments;
        //}
        //private void EmployeeInput_Click(object sender, RoutedEventArgs e)
        //{
        //    ResultEmployee = new Employee(NameInput.Text, SurnameInput.Text, Convert.ToInt32(IdInput.Text), (Department)DepartmentInput.SelectedItem, Convert.ToInt32(SalaryInput.Text));
        //    OnEmployeeSet?.Invoke(ResultEmployee);
        //}

        public DataRow outcomeRow { get; private set; }
        public EmployeeAddWindow(DataRow dataRow)
        {
            InitializeComponent();
            outcomeRow = dataRow;
        }
        private void EmployeeInput_Click(object sender, RoutedEventArgs e)
        {
            NameInput.Text = outcomeRow["Name"].ToString();
            SurnameInput.Text = outcomeRow["Surname"].ToString();
            DepartmentInput.Text = outcomeRow["Department"].ToString();
            SalaryInput.Text = outcomeRow["Salary"].ToString();
            DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
