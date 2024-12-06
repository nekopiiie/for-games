using System;

public class Game
{
    private Player player;
    private GameField gameField;

    public Game()
    {
        player = new Player(0, 0); // Начальная позиция игрока
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
                    gameField.MovePlayer(-1, 0); // Вверх
                    break;
                case ConsoleKey.A:
                    gameField.MovePlayer(0, -1); // Влево
                    break;
                case ConsoleKey.S:
                    gameField.MovePlayer(1, 0); // Вниз
                    break;
                case ConsoleKey.D:
                    gameField.MovePlayer(0, 1); // Вправо
                    break;
                case ConsoleKey.Spacebar:
                    gameField.ActivateTile(); // Активируем плиту
                    break;
            }

            if (gameField.CheckWin())
            {
                Console.WriteLine("Вы выиграли!");
                break; // Выход из игрового цикла
            }
        }
    }
}
