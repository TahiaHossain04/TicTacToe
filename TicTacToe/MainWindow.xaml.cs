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

// Declaration of namespace
namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        // Variables
        // The game starts with X as current player by default
        private string currentPlayer = "X";
        // Track scored os X and O players and their draws
        private int playerXWins = 0;
        private int playerOWins = 0;
        private int draws = 0;
        // Add a field to track if the game has started
        private bool gameStarted = false;

        // Constants
        private const string PlayerX = "X";
        private const string PlayerO = "O";
        private const int Zero = 0;
        private const string Empty = " ";
        private const int RowOne = 0;
        private const int RowTwo = 1;
        private const int RowThree = 2;
        private const int RowFour = 3;

        // Start
        public MainWindow()
        {
            InitializeComponent();
        }

        // 
        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            gameStarted = true; // Set the game as started
            Button_Click(sender, e);
        }


        // Event Handler for clicking the buttons of the game
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!gameStarted) // Check if the game has started
            {
                MessageBox.Show("Please start the game first!"); // Optional: notify the user
                return; // If the game hasn't started, don't proceed
            }

            Button clickedButton = sender as Button;

            // Check if the button is already clicked
            if (clickedButton.Content != null)
            {
                return; // If the button already has a value, don't change it.
            }

            // Set the button content to the current player's symbol (X or O)
            clickedButton.Content = currentPlayer;

            // Check if there's a winner after this move
            if (CheckForWinner())
            {
                if (currentPlayer == PlayerX)
                {
                    playerXWins++; // Increment X's wins
                    textXWins.Text = $"{playerXWins}"; // Immediately update the text box
                    MessageBox.Show($"{PlayerX} wins!"); // Show a message box showing who won
                }
                else
                {
                    playerOWins++; // Increment O's wins
                    textOWins.Text = $"{playerOWins}"; // Immediately update the text box
                    MessageBox.Show($"{PlayerO} wins!");
                }

                ClearBoard(); // Clear the board after the game is won by someone
                return;
            }

            // Check if it's a draw
            if (CheckForDraw())
            {
                draws++; // Increment the draw count
                textDraws.Text = $"{draws}"; // Immediately update the text box
                MessageBox.Show("It's a draw!");
                ClearBoard(); // Clear the board after a draw
                return;
            }

            // Switch the player from X to O and vice versa if there is no winner or draw
            if (currentPlayer == PlayerX)
            {
                currentPlayer = PlayerO;
            }
            else
            {
                currentPlayer = PlayerX;
            }
            // Update the text box with the current player (X or O)
            textCurrentPlayerName.Text = $"{currentPlayer}";
        }

        // 
        private bool CheckForWinner()
        {
            // Declare a 2D array called board which has 3 rows and 3 columns 
            string[,] board = new string[RowFour, RowFour]
            // The current content of the 2D array is intialized below
            {
        { button1x1Grid.Content?.ToString(), button1x2Grid.Content?.ToString(), button1x3Grid.Content?.ToString() },
        { button2x1Grid.Content?.ToString(), button2x2Grid.Content?.ToString(), button2x3Grid.Content?.ToString() },
        { button3x1Grid.Content?.ToString(), button3x2Grid.Content?.ToString(), button3x3Grid.Content?.ToString() }
            }; 
            // .Content - retrieved the content of the button
            // >. - null conditional operator. If content is null, this operator prevents
            // the program trying to call ToString for a null value
            // ToString() - converts button content to string

            // Checks each row to see if all three buttons in that row contain the same non-null
            // value. If yes then returns true.
            for (int row = RowOne; row < RowFour; row++)
            {
                if (board[row, RowOne] != null && board[row, RowOne] == board[row, RowTwo] && board[row, RowTwo] == board[row, RowThree])
                {
                    return true;
                }
            }

            // Check columns the same way
            for (int col = RowOne; col < RowFour; col++)
            {
                if (board[RowOne, col] != null && board[RowOne, col] == board[RowTwo, col] && board[RowTwo, col] == board[RowThree, col])
                {
                    return true;
                }
            }

            // Check diagonals the same way
            if (board[RowOne, RowOne] != null && board[RowOne, RowOne] == board[RowTwo, RowTwo] && board[RowTwo, RowTwo] == board[RowThree, RowThree])
            {
                return true;
            }
            if (board[RowOne, RowThree] != null && board[RowOne, RowThree] == board[RowTwo, RowTwo] && board[RowTwo, RowTwo] == board[RowThree, RowOne])
            {
                return true; 
            }

            return false; // No winner yet
        }


        private bool CheckForDraw()
        {
            // Ensure all buttons are filled (no null content)
            return button1x1Grid.Content != null && button1x2Grid.Content != null && button1x3Grid.Content != null &&
                   button2x1Grid.Content != null && button2x2Grid.Content != null && button2x3Grid.Content != null &&
                   button3x1Grid.Content != null && button3x2Grid.Content != null && button3x3Grid.Content != null;
        }


        private void ClearBoard()
        {
            button1x1Grid.Content = null;
            button1x2Grid.Content = null;
            button1x3Grid.Content = null;
            button2x1Grid.Content = null;
            button2x2Grid.Content = null;
            button2x3Grid.Content = null;
            button3x1Grid.Content = null;
            button3x2Grid.Content = null;
            button3x3Grid.Content = null;

            currentPlayer = PlayerX; // Reset to X as starting player
        }


        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            ClearBoard(); // Reset the board
            buttonStartGame_Click(sender, e);
            TextPlayerXName.Text = Empty;
            TextPlayerOName.Text = Empty;
            playerXWins = Zero;
            playerOWins = Zero;
            draws = Zero;

            // Reset score labels
            textXWins.Text = $"{Zero}";
            textOWins.Text = $"{Zero}";
            textDraws.Text = $"{Zero}";

            currentPlayer = PlayerX; // Reset to player X as starting player
            textCurrentPlayerName.Text = Empty;
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the application
        }

    }
}