using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeDetailApplication.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeOverview.xaml
    /// </summary>
    public partial class EmployeeOverview : UserControl
    {
        public EmployeeOverview()
        {
            InitializeComponent();            
        }

        //Remove the selected employee. IEmployeeDataService (to preform deletion) can be accessed via the passthrought datacontext from ViewModel
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Employee selectedEmployee = (Employee)btn.DataContext;
            var datac = (EmployeeOverViewViewModel)this.DataContext;
            datac.DeleteEmployee(selectedEmployee.id);
        }
    }
}
