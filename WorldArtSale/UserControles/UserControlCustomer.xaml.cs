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
using BIZ;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UserControlCostumer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {

        ClassBIZ BIZ;

        public UserControlCustomer(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
            DataContext = BIZ;
        }

        private void OpretButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedigerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
