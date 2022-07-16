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
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {
        private string placeholderText = "Search by name...";
        public SearchBar()
        {
            InitializeComponent();
            searchTextBoxText.Text = placeholderText;
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != placeholderText)
            {
                var datac = (EmployeeOverViewViewModel)this.DataContext;
                if (tb.Text != "")
                {
                    datac.SearchByName(tb.Text);
                }
                else
                {
                    datac.ObtainEmployees();
                }
            }
        }
    }
}
