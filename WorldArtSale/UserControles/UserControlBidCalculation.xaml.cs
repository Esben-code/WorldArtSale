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
    /// Interaction logic for UserControlBidCalculation.xaml
    /// </summary>
    public partial class UserControlBidCalculation : UserControl
    {
        ClassBIZ BIZ;

        public UserControlBidCalculation(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
            DataContext = BIZ;
        }
    }
}
