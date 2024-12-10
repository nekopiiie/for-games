using System;
using System.Collections.Generic;
using System.Threading;

namespace Labyrinth
{
    class Program
    {
        static int width = 30;
        static int height = 20;
        static char[,] labyrinth = new char[width, height]; // массив символов, представляющий лабиринт
        static bool[,] visited = new bool[width, height]; // массив для отслеживания посещенных клеток
        static Random random = new Random(); // объект для генерации случайных чисел
        static Player player;
        static (int x, int y) finish; // финиш

        static void Main(string[] args) // начальная точка игры . массив строк
        {
            GenerateLabyrinth(0, 0);
            player = new Player(0, 0);
            finish = (width - 2, height - 2); 

            DateTime startTime = DateTime.Now; // Время начала игры
            TimeSpan timeLimit = TimeSpan.FromMinutes(1);  

            Console.WriteLine("У вас на игру 1 минута!");
            Console.WriteLine("Нажмите любую клавишу, чтобы начать...");
            Console.ReadKey(); // ждемс пока нажмет

            while (true)
            {
                Console.Clear();
                PrintLabyrinth();

                // Проверка на достижение финиша
                if (player.X == finish.x && player.Y == finish.y)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Класс!! Вы прошли лабиринт!");
                    break;
                }

                
                TimeSpan elapsedTime = DateTime.Now - startTime; // тип. прошед вр = текущ - начало .. интервал
                if (elapsedTime >= timeLimit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("УПС! Время вышло! Вы не успели пройти лабиринт.");
                    break;
                }

                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Оставшееся время: {timeLimit - elapsedTime:hh\\:mm\\:ss}");

                Console.ForegroundColor = ConsoleColor.White; 
                Console.WriteLine("Используйте W, A, S, D для перемещения. Выход: Q.");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q) break;

                switch (key)
                {
                    case ConsoleKey.W:
                        player.Move(0, -1, labyrinth);
                        break;
                    case ConsoleKey.S:
                        player.Move(0, 1, labyrinth);
                        break;
                    case ConsoleKey.A:
                        player.Move(-1, 0, labyrinth);
                        break;
                    case ConsoleKey.D:
                        player.Move(1, 0, labyrinth);
                        break;
                }
            }
        }

        static void GenerateLabyrinth(int startX, int startY)
        {
            // все стены + все посетили 
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    labyrinth[x, y] = '#'; 
                    visited[x, y] = false; 
                }
            }

            // Генерация лабиринта ВХОД()
            Stack<(int x, int y)> stack = new Stack<(int, int)>();
            stack.Push((startX, startY)); // нач точка
            visited[startX, startY] = true;
            labyrinth[startX, startY] = ' '; 

            while (stack.Count > 0) // непосещенные соседи
            {
                var current = stack.Pop();
                List<(int x, int y)> neighbors = GetUnvisitedNeighbors(current.x, current.y);

                if (neighbors.Count > 0) // случайные соседи
                {
                    stack.Push(current);
                    var next = neighbors[random.Next(neighbors.Count)];

                    // стены находятся между клетками, а не внутри них (/2)
                    labyrinth[(current.x + next.x) / 2, (current.y + next.y) / 2] = ' ';

                    visited[next.x, next.y] = true;
                    labyrinth[next.x, next.y] = ' ';
                    stack.Push(next); // чтобы не было тупиков запоминаем координаты
                }
            }
        }

        // непосещенные соседи
        static List<(int x, int y)> GetUnvisitedNeighbors(int x, int y)
        {   // neighbors для хранения координат соседних клеток
            List<(int x, int y)> neighbors = new List<(int x, int y)>(); 

            // Проверка соседних клеток (все четыре стороны)
            if (x > 1 && !visited[x - 2, y]) neighbors.Add((x - 2, y)); // добавь в список коорд
            if (x < width - 2 && !visited[x + 2, y]) neighbors.Add((x + 2, y)); 
            if (y > 1 && !visited[x, y - 2]) neighbors.Add((x, y - 2)); 
            if (y < height - 2 && !visited[x, y + 2]) neighbors.Add((x, y + 2)); 

            return neighbors; // ДОБАВЛЯЕМС
        }

        static void PrintLabyrinth()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == player.X && y == player.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.Write('P');
                    }
                    else if (x == finish.x && y == finish.y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.Write('F');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.Write(labyrinth[x, y]);
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor(); // Сброс цвета консоли
        }

    }

    class Player
    { 
        public int X { get; private set; }
        public int Y { get; private set; } // хранение коорд

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        } 

        public void Move(int deltaX, int deltaY, char[,] labyrinth) // вычисл новых координат
        {
            //  дельта = на сколько единиц объект должен переместиться по осям
            int newX = X + deltaX; 
            int newY = Y + deltaY;
            // новые коорд

            // + не выходит ли новая координата за пределы лабиринта
            if (newX >= 0 && newX < labyrinth.GetLength(0) && newY >= 0 && newY < labyrinth.GetLength(1) && labyrinth[newX, newY] == ' ')
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
