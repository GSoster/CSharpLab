﻿using System;
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
using Engine.ViewModels;
using Engine.EventArgs;
namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameSession _gameSession = new GameSession();
        
        public MainWindow()
        {
            InitializeComponent();            

            //here the View subscribes to the event handler
            _gameSession.OnMessageRaised += OnGameMessageRaised;
            DataContext = _gameSession;
        }

        #region Movement methods
        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveNorth();
        }

        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }

        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }

        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }
        #endregion
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }


        private void OnClick_DisplayTradeScreen(object sender, RoutedEventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.Owner = this;
            tradeScreen.DataContext = _gameSession;
            tradeScreen.ShowDialog();
        }

        //TODO: Rename to attack ENEMY
        private void OnClick_AttackMonster(Object sender, EventArgs e)
        {
            _gameSession.AttackCurrentMonster();
        }

    }
}
