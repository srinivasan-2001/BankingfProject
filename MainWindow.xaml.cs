using System;
using System.Collections.Generic;
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

namespace entering_sheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_employee_Click(object sender, RoutedEventArgs e)
        {
            loginemployee obj = new loginemployee();
            obj.Show();
            this.Hide();
        }

        private void btn_customer_Click(object sender, RoutedEventArgs e)
        {
            logincustomer obj = new logincustomer();
            obj.Show();
            this.Hide();
        }
    }
}
