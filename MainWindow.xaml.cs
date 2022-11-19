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

namespace TicTacToe
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

      
        Logic Logics = new Logic();
        private void ClickSpace(object sender, RoutedEventArgs e)
        {
            
            var buttonClick = (Button)sender;
            if (!String.IsNullOrWhiteSpace(buttonClick.Content?.ToString())) return;
            buttonClick.Content = Logics.CurrentPlayer;

            var coordinates = buttonClick.Tag.ToString().Split(',');
            var xValue = int.Parse(coordinates[0]);
            var yValue = int.Parse(coordinates[1]);


            var buttonPosition = new Position() { x = xValue, y = yValue };
            Logics.UpdateBoard(buttonPosition, Logics.CurrentPlayer);

            Logics.SetPlayer();
            

            if (Logics.Winner())
            {
                

                Win.Visibility = Visibility.Visible;
                Win.Text = $"{Logics.NotCurrentPlayer} Win!";
                Win.FontSize = 70;
                Win.VerticalAlignment = VerticalAlignment.Center;
                Win.HorizontalAlignment = HorizontalAlignment.Center;
                Win.Width = 230;
                Win.Height = 110;
                gridBoard.IsEnabled = false;

               

            }
            
                                                            
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (var control in gridBoard.Children)
            {
                if (control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
                Logics = new Logic();
            }
            Win.Visibility = Visibility.Collapsed;
            gridBoard.IsEnabled = true;
        }
    }
}

