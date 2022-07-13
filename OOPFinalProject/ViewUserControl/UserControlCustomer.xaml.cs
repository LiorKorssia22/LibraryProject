using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace OOPFinalProject.ViewUserControl
{
    /// <summary>
    /// Interaction logic for UserControlCustomer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {
        public UserControlCustomer()
        {
            InitializeComponent();
        
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9_.]+").IsMatch(e.Text);
        private void WordValidationTextBox(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^A-Za-z]+").IsMatch(e.Text);
    }
}
