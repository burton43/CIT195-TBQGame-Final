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

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

        private void BetaTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.BetaTravel();
        }

        

        private void DeltaTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.DeltaTravel();
        }
        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
        }
        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnUseGameItem();
            }
        }

        private void InteractButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (LocationNpcsDataGrid.SelectedItem != null)
                {
                    _gameSessionViewModel.OnPlayerTalkTo();
                }
            }
        }

        private void LookAtButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (LocationNpcsDataGrid.SelectedItem != null)
                {
                    _gameSessionViewModel.OnPlayerLookAt();
                }
            }
        }

       
    }
}
