// Author:        Tahia Hossain
// Date Created:  8th October 2024
// Date Modified: 12th October 2024
// File name:     TicTacToe
// Description:   The tic tac toe game played between two
//                users, shows wins, draws and losses.

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
        // Player Symbols
        private const string PlayerX = "X";
        private const string PlayerO = "O";
        
        private const int Zero = 0;
        private const string Empty = " ";

        // Rows and Column indexes (named only as Rows but used in columns as well)
        private const int RowZero = 0;
        private const int RowOne = 1;
        private const int RowTwo = 2;
        private const int RowThree = 3;

        // Start
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event Handler for starting the game and enabling game buttons
        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            // Sets the game to started
            gameStarted = true;
            // When Start Game button is clicked, the Button_Click event is also triggered
            Button_Click(sender, e);
            // Sets the current player to be "X" and shows the symbol when user clicks Start Game button
            textCurrentPlayerName.Text = $"{currentPlayer}";
        }


        // Event Handler for clicking the buttons of the game
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if the game has started
            if (!gameStarted)
            {
                // Alerts the user to start the game first
                MessageBox.Show("Please click on the button to start the game first!");
                // If the game hasn't started, exit the method
                return; 
            }

            // Casts the sender object to a button type 
            Button clickedButton = sender as Button;

            // Check if the clicked button is empty or not
            if (clickedButton.Content != null)
            {
                // If the button already has a value, don't change it.
                return;
            }

            // If null, set the button content to the current player's symbol (X or O)
            clickedButton.Content = currentPlayer;

            // Calls the ChechForWinner method to check if there's a winner after this move
            // If there is a winner
            if (CheckForWinner())
            {
                // Checks if the winer is Player X
                if (currentPlayer == PlayerX)
                {
                    playerXWins++; // Increment X's wins
                    textXWins.Text = $"{playerXWins}"; // Immediately update the text box
                    MessageBox.Show($"{TextPlayerXName.Text}({PlayerX}) wins!"); // Show a message box showing who won
                }
                // But if the winer is Player O
                else
                {
                    playerOWins++; // Increment O's wins
                    textOWins.Text = $"{playerOWins}"; // Immediately update the text box
                    MessageBox.Show($"{TextPlayerOName.Text}({PlayerO}) wins!");
                }

                // Calls this method to clear the board after the game is won by someone
                ClearBoard();
                // Exits the method after handling the win
                return;
            }

            // Check if it's a draw
            // If it is afraw
            if (CheckForDraw())
            {
                draws++; // Increment the draw count
                textDraws.Text = $"{draws}"; // Immediately update the text box
                MessageBox.Show("It's a draw!");
                ClearBoard();
                return; // Exits the method after handling the draw
            }

            // Switch the player from X to O and vice versa if there is no winner or draw
            // If current player is X, the next will be O
            if (currentPlayer == PlayerX)
            {
                currentPlayer = PlayerO;
            }
            // Otherwise, if current player is O the next will beX
            else
            {
                currentPlayer = PlayerX;
            }
            // Update the text box with the current player (X or O)
            textCurrentPlayerName.Text = $"{currentPlayer}";
        }

        // Checks if the board has a winner
        private bool CheckForWinner()
        {
            // Declare a 2D array called board which has 3 rows and 3 columns 
            string[,] board = new string[RowThree, RowThree]
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
            // value. If yes then returns true (as it is a win)
            for (int row = RowZero; row < RowThree; row++)
            {
                if (board[row, RowZero] != null && board[row, RowZero] == board[row, RowOne] && board[row, RowOne] == board[row, RowTwo])
                {
                    // If three buttons in a row have the same value then returnt true
                    return true;
                }
            }

            // Check columns the same way
            for (int col = RowZero; col < RowThree; col++)
            {
                if (board[RowZero, col] != null && board[RowZero, col] == board[RowOne, col] && board[RowOne, col] == board[RowTwo, col])
                {
                    // If three buttons in a column have the same value then returnt true
                    return true;
                }
            }

            // Check diagonals for a winner
            // For first diagonal (0,1), (1,1) (2,2) if values are same and not null
            if (board[RowZero, RowZero] != null && board[RowZero, RowZero] == board[RowOne, RowOne] && board[RowOne, RowOne] == board[RowTwo, RowTwo])
            {
                // If the three buttons in the diagonal have the same values then return true
                return true;
            }
            // For first diagonal (0,2), (1,1) (2,0) if values are same and not null
            if (board[RowZero, RowTwo] != null && board[RowZero, RowTwo] == board[RowOne, RowOne] && board[RowOne, RowOne] == board[RowTwo, RowZero])
            {
                // If the three buttons in the diagonal have the same values then return true
                return true; 
            }

            return false; // No winner yet
        }

        // Checks the board for a draw
        private bool CheckForDraw()
        {
            // Checks if all the nine buttons have a content/ have been clicked but without a winner
            // We use && operator because every single cell needs to be filled for this draw to happen
            return button1x1Grid.Content != null && button1x2Grid.Content != null && button1x3Grid.Content != null &&
                   button2x1Grid.Content != null && button2x2Grid.Content != null && button2x3Grid.Content != null &&
                   button3x1Grid.Content != null && button3x2Grid.Content != null && button3x3Grid.Content != null;
        }


        // Resets all the buttons of the game to their initial state
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

            // Reset to X as starting player
            currentPlayer = PlayerX;
        }

        // Event Handler for resetting the game
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            // Call this method to reset the board
            ClearBoard();
            // Calls the StartGame handler again to set gameStarted to true
            buttonStartGame_Click(sender, e);
            // Reset all the text boxes
            TextPlayerXName.Text = Empty;
            TextPlayerOName.Text = Empty;
            playerXWins = Zero;
            playerOWins = Zero;
            draws = Zero;

            // Reset score labels
            textXWins.Text = $"{Zero}";
            textOWins.Text = $"{Zero}";
            textDraws.Text = $"{Zero}";

            // Reset to player X as starting player
            currentPlayer = PlayerX;
            textCurrentPlayerName.Text = Empty;
        }

        // Event Handler for exitting the game
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the application
        }

    }
}