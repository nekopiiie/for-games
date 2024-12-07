using System;

public class Game
{
    private Player player;
    private GameField gameField;

    public Game()
    {
        player = new Player(0, 0); 
        gameField = new GameField(player);
    }

    public void GameLoop()
    {
        while (true)
        {
            gameField.Display();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    gameField.MovePlayer(-1, 0); 
                    break;
                case ConsoleKey.A:
                    gameField.MovePlayer(0, -1); 
                    break;
                case ConsoleKey.S:
                    gameField.MovePlayer(1, 0); 
                    break;
                case ConsoleKey.D:
                    gameField.MovePlayer(0, 1); 
                    break;
                case ConsoleKey.Spacebar:
                    gameField.ActivateTile(); 
                    break;
            }

            if (gameField.CheckWin())
            {
                Console.WriteLine("Вы выиграли!");
                break; 
            }
        }
    }
}
