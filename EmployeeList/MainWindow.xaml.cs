using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dataTable;
        DataSet dataSet;
        SqlParameter param;



        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            //lbDepartment.ItemsSource = departments;
            //lbEmployee.ItemsSource = employees;
            //employees.Add(new Employee("Ilshat", "Safin", 1, null, 1));
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
            DataRow dataRow = dataTable.NewRow();
            EmployeeAddWindow employeeAddWindow = new EmployeeAddWindow(dataRow);
            employeeAddWindow.ShowDialog();
            SqlCommand command = new SqlCommand();

            if (employeeAddWindow.DialogResult.HasValue && employeeAddWindow.DialogResult.Value)
            {
                dataTable.Rows.Add(employeeAddWindow.outcomeRow);
                adapter.Update(dataTable);
            }
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
            DataRowView updateRow = (DataRowView)lbEmployee.SelectedItem;
            updateRow.BeginEdit();
            EmployeeChangeWindow employeeChangeWindow = new EmployeeChangeWindow(updateRow.Row);
            employeeChangeWindow.ShowDialog();
            if (employeeChangeWindow.DialogResult.HasValue && employeeChangeWindow.DialogResult.Value)
            {
                updateRow.EndEdit();
                adapter.Update(dataTable);
            }
            else
                updateRow.CancelEdit();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial catalog = EmployeesListDB; Integrated Security = True; Pooling = False";
            connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command = new SqlCommand("SELECT Id, Name, Surname, Department, Salary FROM EmployeesTable", connection);
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            command = new SqlCommand(@"INSERT INTO EmployeesTable (Id, Name, Surname, Department, Salary) VALUES (@Id, @Name, @Surname, @Department, @Salary); SET @Id = @@Identity;", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Surname", SqlDbType.NVarChar, -1, "Surname");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, "Department");
            command.Parameters.Add("@Salary", SqlDbType.Int, 0, "Salary");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = command;


            command = new SqlCommand(@"UPDATE EmployeesTable SET Name = @Name, Surname = @Surname, Department = @Department, Salary = @Salary, WHERE Id = @Id", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Surname", SqlDbType.NVarChar, -1, "Surname");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, "Department");
            command.Parameters.Add("@Salary", SqlDbType.Int, 0, "Salary");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = command;

            command = new SqlCommand(@"DELETE FROM EmployeesTable WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = command;

            //command.CommandText = "SET IDENTITY_INSERT dbo.EmployeesTable ON";
            command.CommandText = "SET IDENTITY_INSERT dbo.EmployeesTable ON";
            command.ExecuteNonQuery();

            dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];

            lbEmployee.DataContext = dataTable.DefaultView;
        }
    }
}
