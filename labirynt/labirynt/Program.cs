using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true) // Pętla, która pozwala na ciągłe działanie programu
        {
            try
            {
                Console.WriteLine("Podaj ilość wierszy dla labiryntu:");
                int wiersze = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj ilość kolumn dla labiryntu:");
                int kolumny = int.Parse(Console.ReadLine());

                char[,] maze = new char[wiersze, kolumny];

                // Inicjalizacja labiryntu
                for (int i = 0; i < wiersze; i++)
                {
                    for (int j = 0; j < kolumny; j++)
                    {
                        maze[i, j] = '?'; // Znak zapytania dla pustych miejsc
                    }
                }

                // Wyświetlenie labiryntu
                for (int i = 0; i < wiersze; i++)
                {
                    for (int j = 0; j < kolumny; j++)
                    {
                        Console.Write(maze[i, j]);
                    }
                    Console.WriteLine();
                }

                // Modyfikowanie labiryntu
                Console.WriteLine("Podaj wiersz i kolumnę do zmiany lub wpisz 'exit', aby zakończyć:");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                    break; // Wyjście z pętli, jeśli użytkownik chce zakończyć program

                try
                {
                    int row = int.Parse(userInput);
                    int column = int.Parse(Console.ReadLine());

                    Console.WriteLine("Wybierz stan: 1 - brak, 2 - ściana, 3 - ścieżka:");
                    int state = int.Parse(Console.ReadLine());

                    switch (state)
                    {
                        case 1:
                            maze[row, column] = ' ';
                            break;
                        case 2:
                            maze[row, column] = '#';
                            break;
                        case 3:
                            maze[row, column] = '.';
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nieprawidlowy format. Wprowadz liczbe");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Blad");
                }

                // Zapisanie labiryntu do pliku
                using (StreamWriter writer = new StreamWriter("maze.txt"))
                {
                    for (int i = 0; i < wiersze; i++)
                    {
                        for (int j = 0; j < kolumny; j++)
                        {
                            writer.Write(maze[i, j]);
                        }
                        writer.WriteLine();
                    }
                }

                // Odczytanie labiryntu z pliku
                char[,] loadedMaze = new char[wiersze, kolumny];
                using (StreamReader reader = new StreamReader("maze.txt"))
                {
                    for (int i = 0; i < wiersze; i++)
                    {
                        string line = reader.ReadLine();
                        for (int j = 0; j < kolumny; j++)
                        {
                            loadedMaze[i, j] = line[j];
                        }
                    }
                }

                // Wyświetlenie załadowanego labiryntu
                for (int i = 0; i < wiersze; i++)
                {
                    for (int j = 0; j < kolumny; j++)
                    {
                        Console.Write(loadedMaze[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidlowy format. Wprowadz liczbe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad");
            }
        }
    }
}
