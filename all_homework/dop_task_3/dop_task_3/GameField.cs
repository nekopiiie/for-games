using System;

public class GameField
{
    private const int Size = 10;
    private char[,] field;
    private Player player;

    public GameField(Player player)
    {
        this.player = player;
        field = new char[Size, Size];
        InitializeField();
    }

    private void InitializeField()
    {
        field = new char[Size, Size]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', 'A', '#' },
            { '#', 'R', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', 'T', 'T', '#', 'O', 'O', 'O', '#', '#', '#' },
            { '#', '#', '#', '#', 'O', 'O', 'O', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', 'T' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '#', '#', 'O', 'O', 'O', 'O', '#', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', 'A', '#', '#', '#', '#', '#', 'R', '#', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
        field[player.PositionX, player.PositionY] = 'C'; // Установка персонажа
    }

    public void Display()
    {
        Console.Clear();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                switch (field[i, j])
                {
                    case '#':
                        Console.ForegroundColor = ConsoleColor.Green; // Трава
                        break;
                    case 'R':
                        Console.ForegroundColor = ConsoleColor.Blue; // Камни
                        break;
                    case 'T':
                        Console.ForegroundColor = ConsoleColor.DarkCyan; // Деревья
                        break;
                    case 'O':
                        Console.ForegroundColor = ConsoleColor.White; // Неактивированная плита
                        break;
                    case 'A':
                        Console.ForegroundColor = ConsoleColor.Yellow; // Активированная плита
                        break;
                    case 'C':
                        Console.ForegroundColor = ConsoleColor.Red; // Игрок
                        break;
                    default:
                        Console.ResetColor();
                        break;
                }
                Console.Write(field[i, j] + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public bool MovePlayer(int deltaX, int deltaY)
    {
        int newX = player.PositionX + deltaX;
        int newY = player.PositionY + deltaY;

        if (IsInBounds(newX, newY))
        {
            char target = field[newX, newY];
            if (target == '#' || target == 'O') // Можно двигаться по траве и плитам
            {
                UpdateField(player.PositionX, player.PositionY); // Убираем персонажа с текущей позиции
                player.PositionX = newX;
                player.PositionY = newY;
                field[player.PositionX, player.PositionY] = 'C'; // Устанавливаем персонажа на новую позицию
                return true;
            }
            else if (target == 'R') // Если находимся рядом с камнем
            {
                int nextX = newX + deltaX;
                int nextY = newY + deltaY;

                if (IsInBounds(nextX, nextY) && (field[nextX, nextY] == 'O' || field[nextX, nextY] == '#')) // Проверяем, можно ли двигать камень
                {
                    field[newX, newY] = 'O'; // Убираем камень с текущей позиции
                    field[nextX, nextY] = 'R'; // Двигаем камень
                    UpdateField(player.PositionX, player.PositionY); // Убираем персонажа с текущей позиции
                    player.PositionX = newX;
                    player.PositionY = newY;
                    field[player.PositionX, player.PositionY] = 'C'; // Устанавливаем персонажа на новую позицию
                    return true;
                }
            }
        }
        return false; // Движение невозможно
    }

    private void UpdateField(int x, int y)
    {
        field[x, y] = 'O'; // Плита остается неактивированной
    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < Size && y >= 0 && y < Size;
    }

    public bool CheckWin()
    {
        foreach (char tile in field)
        {
            if (tile == 'O') return false; // Если есть неактивированные плиты, возвращаем false
        }
        return true; // Все плиты активированы
    }

    public void ActivateTile()
    {
        int x = player.PositionX;
        int y = player.PositionY;

        if (field[x, y] == 'O') // Если игрок стоит на неактивированной плите
        {
            field[x, y] = 'A'; // Активируем плиту
        }
    }

}
