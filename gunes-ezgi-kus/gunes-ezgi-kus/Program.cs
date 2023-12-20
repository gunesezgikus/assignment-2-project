void DrawTicTacToeBoard(string[] gameBoard)
{
    int cellIndex = 0;
    for (int row = 0; row < 3; row++)
    {
        for (int col = 1; col <= 11; col++)
        {
            if (col % 4 == 0)
            {
                Console.Write("|");
            }
            else if (col % 2 == 0)
            {
                if (gameBoard[cellIndex] == "X" || gameBoard[cellIndex] == "O")
                {
                    Console.Write(gameBoard[cellIndex]);
                }
                else
                {
                    Console.Write(" ");
                }
                cellIndex++;
            }
            else
            {
                Console.Write(" ");
            }
        }
        if (row < 2)
        {
            Console.WriteLine();
            Console.WriteLine("---+---+---");
        }
    }
    Console.WriteLine();
}

bool CheckForWinner(string[] gameBoard, string player)
{
    for (int i = 0; i < 3; i++)
    {
        if (gameBoard[i * 3] == player && gameBoard[i * 3 + 1] == player && gameBoard[i * 3 + 2] == player
            || gameBoard[i] == player && gameBoard[i + 3] == player && gameBoard[i + 6] == player)
            return true;
    }
    if (gameBoard[0] == player && gameBoard[4] == player && gameBoard[8] == player || gameBoard[2] == player && gameBoard[4] == player && gameBoard[6] == player)
        return true;
    return false;
}


void Game()
{
    Console.WriteLine("1. New game");
    Console.WriteLine("2. About the author");
    Console.WriteLine("3. Exit");
    Console.Write("> ");
    string menu = Console.ReadLine();
    Console.WriteLine();
    if (menu == "1")
    {

        int totalMoves = 0;
        string[] ticTacToeBoard = new string[9];
        DrawTicTacToeBoard(ticTacToeBoard);

        do
        {
            if (totalMoves != 9)
            {
                string currentPlayer;
                if (totalMoves % 2 == 0)
                {
                    currentPlayer = "X";
                }
                else
                {
                    currentPlayer = "O";
                }
                Console.Write($"{currentPlayer}'s move > ");

                int userMove = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine();
                if (userMove < 0 || ticTacToeBoard.Length <= userMove || ticTacToeBoard[userMove] == "X" || ticTacToeBoard[userMove] == "O")
                {
                    Console.WriteLine("Illegal move! Try again.");
                }
                else
                {
                    ticTacToeBoard[userMove] = currentPlayer;
                    totalMoves++;
                    DrawTicTacToeBoard(ticTacToeBoard);

                    if (CheckForWinner(ticTacToeBoard, currentPlayer))
                    {
                        Console.WriteLine($"\n{currentPlayer} won!");
                        Console.Write("[Press Enter to return to main menu...]");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            else
            {
                totalMoves++;
                Console.WriteLine("Game over!");
            }
        } while (totalMoves < 10);
        Game();
    }
    else if (menu == "2")
    {
        Console.WriteLine("Gunes Ezgi Kus");
        Console.Write("[Press Enter to return to main menu...]");
        Console.ReadLine();
        Game();
    }
    else if (menu == "3")
    {
        Console.WriteLine("Are you sure you want to quit? [y/n]");
        Console.Write("> ");
        string temp = Console.ReadLine();
        if (temp.ToLower() != "y") Game();
    }
    else
    {
        Console.WriteLine();
        Game();
    }
}

Game();
