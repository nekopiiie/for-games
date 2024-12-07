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
        field[player.PositionX, player.PositionY] = 'C'; 
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
            if (target == '#' || target == 'O') 
            {
                UpdateField(player.PositionX, player.PositionY); 
                player.PositionX = newX;
                player.PositionY = newY;
                field[player.PositionX, player.PositionY] = 'C'; 
                return true;
            }
            else if (target == 'R') 
            {
                int nextX = newX + deltaX;
                int nextY = newY + deltaY;

                if (IsInBounds(nextX, nextY) && (field[nextX, nextY] == 'O' || field[nextX, nextY] == '#'))  
                {
                    field[newX, newY] = 'O'; 
                    field[nextX, nextY] = 'R'; 
                    UpdateField(player.PositionX, player.PositionY); 
                    player.PositionX = newX;
                    player.PositionY = newY;
                    field[player.PositionX, player.PositionY] = 'C'; 
                    return true;
                }
            }
        }
        return false; 
    }

    private void UpdateField(int x, int y)
    {
        field[x, y] = 'O'; 
    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < Size && y >= 0 && y < Size;
    }

    public bool CheckWin()
    {
        foreach (char tile in field)
        {
            if (tile == 'O') return false; 
        }
        return true; 
    }

    public void ActivateTile()
    {
        int x = player.PositionX;
        int y = player.PositionY;

        if (field[x, y] == 'O') 
        {
            field[x, y] = 'A'; 
        }
    }

}
