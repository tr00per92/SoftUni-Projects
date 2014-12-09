using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _04_CompanyHierarchy;

namespace _05_BusinessReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> employees;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            this.employees = CompanyHierarchy.GetData();

            foreach (var employee in this.employees)
            {
                CheckBox current = new CheckBox
                {
                    Margin = new Thickness(4),
                    Content = string.Format("{0} {1}'s Report", employee.FirstName, employee.LastName),
                    Name = "_" + employee.Id
                };

                current.Click += this.Checkbox_Click;

                if (employee is IDeveloper)
                {
                    this.ProjectReports.Children.Add(current);
                }
                else if (employee is ISalesEmployee)
                {
                    this.SalesReports.Children.Add(current);
                }
            }
        }

        private void Checkbox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox clicked = (CheckBox)sender;
            int id = int.Parse(clicked.Name.Trim('_'));
            string info = this.employees.First(x => x.Id == id).ToString();

            this.Detais.Text = info;
        }
    }
}
