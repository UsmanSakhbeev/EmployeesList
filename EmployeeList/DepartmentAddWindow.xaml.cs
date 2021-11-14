using System;
using System.Windows;

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для DepartmentAddWindow.xaml
    /// </summary>
    public partial class DepartmentAddWindow : Window
    {
        public event Action<Department> OnDepartmentSet;
        public Department ResultDepartment { get; private set; }
        public DepartmentAddWindow()
        {
            InitializeComponent();
        }
        private void DepartmentInput_Click(object sender, RoutedEventArgs e)
        {
            ResultDepartment = new Department(DepartmentInput.Text);
            OnDepartmentSet?.Invoke(ResultDepartment);
        }


    }
}
