using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;


namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для EmployeeChangeWindow.xaml
    /// </summary>
    public partial class EmployeeChangeWindow : Window
    {
        public DataRow outcomeRow;
        public EmployeeChangeWindow(DataRow dataRow)
        {
            InitializeComponent();
            outcomeRow = dataRow;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameInput.Text = outcomeRow["Name"].ToString();
            SurnameInput.Text = outcomeRow["Surname"].ToString();
            DepartmentInput.Text = outcomeRow["Department"].ToString();
            SalaryInput.Text = outcomeRow["Salary"].ToString();
        }
        private void EmployeeChange_Click(object sender, RoutedEventArgs e)
        {
            outcomeRow["Name"] = NameInput.Text;
            outcomeRow["Surname"] = SurnameInput.Text;
            outcomeRow["Department"] = DepartmentInput.Text;
            outcomeRow["Salary"] = SalaryInput.Text;
        }
        private void EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void cancelButton_Click(object sender, RoutedEventArgs e)
        //{
        //    DialogResult = false;
        //}


        //private ObservableCollection<Employee> _employeeList;
        //private ObservableCollection<Department> _departmentsList;
        //private Employee _employee;

        //public EmployeeChangeWindow(ObservableCollection<Employee> employeesList, ObservableCollection<Department> departmentsList, Employee employee)
        //{
        //    InitializeComponent();
        //    _employeeList = employeesList;
        //    _employee = employee;
        //    _departmentsList = departmentsList;
        //    FillList();
        //}
        //private void FillList()
        //{
        //    DepartmentInput.ItemsSource = _departmentsList;
        //    NameInput.Text = _employee.Name;
        //    SurnameInput.Text = _employee.Surname;
        //    IdInput.Text = Convert.ToString(_employee.ID);
        //    DepartmentInput.SelectedItem = _employee.Department;
        //    SalaryInput.Text = Convert.ToString(_employee.Salary);
        //}
        //private void EmployeeDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    _employeeList.Remove(_employee);
        //    this.Close();
        //}
        //private void EmployeeChange_Click(object sender, RoutedEventArgs e)
        //{
        //    _employee.Name = NameInput.Text;
        //    _employee.Surname = SurnameInput.Text;
        //    _employee.ID = Convert.ToInt32(IdInput.Text);
        //    _employee.Department = (Department)DepartmentInput.SelectedItem;
        //    _employee.Salary = Convert.ToInt32(SalaryInput.Text);
        //    this.Close();
        //}

    }
}
