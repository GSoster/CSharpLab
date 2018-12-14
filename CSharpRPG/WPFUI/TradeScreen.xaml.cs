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
using System.Windows.Shapes;
using Engine.ViewModels;
using Engine.Models;
namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {

        public GameSession Session => DataContext as GameSession;

        public TradeScreen()
        {
            InitializeComponent();
        }


        public void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            //what row the button was clicked
            GameItem item = (((FrameworkElement)sender).DataContext as GroupedInventoryItem).Item;

            if (item != null)
            {
                Session.CurrentPlayer.ReceiveGold(item.Price);
                Session.CurrentTrader.AddItemToInventory(item);
                Session.CurrentPlayer.RemoveItemFromInventory(item);
            }

        }

        public void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItem item = (((FrameworkElement)sender).DataContext as GroupedInventoryItem).Item;

            if (item != null)
            {
                //TODO change this to a "CanAfford" function that checks and returns true or false
                if (Session.CurrentPlayer.Gold >= item.Price)
                {
                    Session.CurrentPlayer.SpendGold(item.Price);
                    Session.CurrentPlayer.AddItemToInventory(item);
                    Session.CurrentTrader.RemoveItemFromInventory(item);
                }
                else
                {
                    MessageBox.Show("You don't have enought gold!");
                }

            }
        }

        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }


}
