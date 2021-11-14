using System;
using System.Windows;
using System.Collections.ObjectModel;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для DepartmentChangeWindow.xaml
    /// </summary>
    public partial class DepartmentChangeWindow : Window
    {
        private ObservableCollection<Department> _departments;
        private Department _department;
        public DepartmentChangeWindow(ObservableCollection<Department> departments, Department department)
        {
            InitializeComponent();
            _departments = departments;
            _department = department;
            FillList();
        }
        private void FillList()
        {
            DepartmentInput.Text = _department.Name;
        }
        private void ChangeDepartment_Click(object sender, RoutedEventArgs e)
        {
            _department.Name = DepartmentInput.Text;
            this.Close();
        }
        private void DeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            _departments.Remove(_department);
            this.Close();
        }
    }
}
