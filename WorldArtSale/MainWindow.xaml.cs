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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ BIZ;
        UserControlExchangerates ucExchangerates;
        UserControlCustomer ucCustomer;
        UserControlAuctionItem ucAuctionItem;
        UserControlBidCalculation ucBidCalculation;


        //UserControlExchangerates userControlExchangerates = new UserControlExchangerates();
        //UserControlCustomer userControlCustomer = new UserControlCustomer();
        //UserControlAuctionItem userControlAuctionItem = new UserControlAuctionItem();
        //UserControlBidCalculation userControlBidCalculation = new UserControlBidCalculation();

        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();
            ucExchangerates = new UserControlExchangerates(BIZ);
            ucCustomer = new UserControlCustomer(BIZ);
            ucAuctionItem = new UserControlAuctionItem(BIZ);
            ucBidCalculation = new UserControlBidCalculation(BIZ);

            GridBottom.Children.Add(ucExchangerates);
            GridTopLeft.Children.Add(ucCustomer);
            GridTopMiddel.Children.Add(ucAuctionItem);
            GridTopRight.Children.Add(ucBidCalculation);
        }

       
       
    }
}
