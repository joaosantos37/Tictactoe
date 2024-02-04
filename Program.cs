using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int playerTurn = 1; // Player 1 starts

    static void Main()
    {
        do
        {
            Console.Clear(); // Clear console for a new turn
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("\n");
            DrawBoard();

            // Check for a winner or tie
            if (IsWinner())
            {
                Console.WriteLine($"Player {3 - playerTurn} wins!");
                break;
            }
            else if (IsBoardFull())
            {
                Console.WriteLine("It's a tie!");
                break;
            }

            // Get player move
            Console.WriteLine($"Player {playerTurn}'s turn");
            int choice = 0;
            while (true)
            {
                Console.Write($"Enter a number (1-9): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            // Update board and switch player turn
            board[choice - 1] = (playerTurn == 1) ? 'X' : 'O';
            playerTurn = 3 - playerTurn;

        } while (true);

        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    static bool IsWinner()
    {
        // Check rows, columns, and diagonals for a winner
        for (int i = 0; i < 3; i++)
        {
            if ((board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2]) ||
                (board[i] == board[i + 3] && board[i + 3] == board[i + 6]) ||
                ((i == 0 && board[i] == board[i + 4] && board[i + 4] == board[i + 8]) || (i == 2 && board[i + 2] == board[i + 4] && board[i + 4] == board[i + 6])))
            {
                return true;
            }
        }
        return false;
    }

    static bool IsBoardFull()
    {
        // Check if the board is full
        foreach (var cell in board)
        {
            if (cell != 'X' && cell != 'O')
            {
                return false;
            }
        }
        return true;
    }
}
