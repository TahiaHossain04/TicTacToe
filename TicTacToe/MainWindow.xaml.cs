using System.Text;
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
        private Button[,] buttons; // 2D array for Tic Tac Toe buttons
        private string currentPlayer = "X"; // Track current player
        private int xWins = 0, oWins = 0, draws = 0; // Scores
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextPlayerXName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextPlayerOName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonChoosePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1x1Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1x2Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1x3Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2x1Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2x2Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2x3Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3x1Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3x2Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3x3Grid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}