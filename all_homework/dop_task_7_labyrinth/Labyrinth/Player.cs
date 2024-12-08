public class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Player(int startX, int startY)
    {
        X = startX;
        Y = startY;
    }

    public void Move(int deltaX, int deltaY, char[,] labyrinth)
    {
        int newX = X + deltaX;
        int newY = Y + deltaY;

        // Проверка на границы и стены лабиринта
        if (newX >= 0 && newX < labyrinth.GetLength(0) &&
            newY >= 0 && newY < labyrinth.GetLength(1) &&
            labyrinth[newX, newY] == ' ')
        {
            X = newX;
            Y = newY;
        }
    }
}
