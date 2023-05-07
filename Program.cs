using System;

class Program
{
    // Game board
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    // Player and AI symbols
    static char playerSymbol = 'X';
    static char aiSymbol = 'O';

    // Main method
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        bool isPlayerTurn = true;
        bool gameOver = false;

        while (!gameOver)
        {
            // Display the current board
            DisplayBoard();

            if (isPlayerTurn)
            {
                // Player's turn
                Console.WriteLine("Your turn! Enter a number (1-9) to place your symbol:");
                int move = Convert.ToInt32(Console.ReadLine());

                if (IsValidMove(move))
                {
                    MakeMove(move, playerSymbol);

                    if (IsWinner(playerSymbol))
                    {
                        Console.WriteLine("Congratulations! You won!");
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        isPlayerTurn = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
            else
            {
                // AI's turn
                Console.WriteLine("AI's turn...");

                int aiMove = GetAIMove();
                MakeMove(aiMove, aiSymbol);

                if (IsWinner(aiSymbol))
                {
                    Console.WriteLine("AI wins!");
                    gameOver = true;
                }
                else if (IsBoardFull())
                {
                    Console.WriteLine("It's a draw!");
                    gameOver = true;
                }
                else
                {
                    isPlayerTurn = true;
                }
            }
        }

        // Display the final board
        DisplayBoard();

        Console.WriteLine("Game Over. Press any key to exit.");
        Console.ReadKey();
    }

    // Display the game board
    static void DisplayBoard()
    {
        Console.Clear();
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        Console.WriteLine();
    }

    // Check if a move is valid
    static bool IsValidMove(int move)
    {
        return (move >= 1 && move <= 9 && board[move - 1] == ' ');
    }

    // Make a move on the board
    static void MakeMove(int move, char symbol)
    {
        board[move - 1] = symbol;
    }

    // Check if a player has won
    static bool IsWinner(char symbol)
    {
        return
            (board[0] == symbol && board[1] == symbol && board[2] == symbol) ||
            (board[3] == symbol && board[4] == symbol && board[5] == symbol) ||
            (board[6] == symbol && board[7] == symbol && board[8] == symbol) ||
            (board[0] == symbol && board[3] == symbol && board[6] == symbol) ||
            (board[1] == symbol
            && board[4] == symbol && board[7] == symbol) ||
            (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
            (board[0] == symbol && board[4] == symbol && board[8] == symbol) ||
            (board[2] == symbol && board[4] == symbol && board[6] == symbol);
    }

    // Check if the board is full
    static bool IsBoardFull()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == ' ')
                return false;
        }
        return true;
    }
    // Get the AI's move
    static int GetAIMove()
    {
        // Simple AI logic: Randomly select an empty cell
        Random random = new Random();
        int move;

        do
        {
            move = random.Next(1, 10);
        } while (!IsValidMove(move));

        return move;
    }
}