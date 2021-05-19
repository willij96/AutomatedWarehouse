using System;
using static System.Console;

namespace AutomatedWarehouseClass
{
    class Program
    {
        static void Main(string[] args)
        {

            //string[,] grid = new string[0, 0];
            Shelf createShelf = new Shelf();
            createShelf.shelfBox = new Box[0, 0];
            bool isTrue = false;
            string contentName;


            while (!isTrue)
            {

                Clear();

                WriteLine("1. Create shelf");
                WriteLine("2. Print shelf");
                WriteLine("3. Place package");
                WriteLine("4. Fetch package");
                WriteLine("5. Exit");

                ConsoleKeyInfo KeyPressed = Console.ReadKey(true);

                Console.Clear();

                switch (KeyPressed.Key)
                {
                    
                    case ConsoleKey.D1:

                        Write("Name: ");
                        string shelfName = ReadLine();

                        Write("Rows: ");
                        int rows = int.Parse(ReadLine());

                        Write("Columns: ");
                        int columns = int.Parse(ReadLine());

                        WriteLine("Shelf successfully created");
                        ReadKey();

                        createShelf.shelfBox = new Box[rows, columns];

                        createShelf.name = shelfName;

                        

                        break;


                    case ConsoleKey.D2:

                        int counter = 0; 
                        for (int i = 0; i < createShelf.shelfBox.GetLength(0); i++)
                        {
                            Console.Write("|");
                            for (int j = 0; j < createShelf.shelfBox.GetLength(1); j++)
                            {
                                if (createShelf.shelfBox[i, j] != null) //
                                {
                                    Write("X |");

                                }
                                else
                                {
                                    Write("  |");
                                    counter++;
                                }
                            }
                            WriteLine();
                        }

                        WriteLine("Available slots: " + counter);
                        

                        ReadKey();
                        
                        break;


                    case ConsoleKey.D3:

                        Write("Content: ");
                        contentName = ReadLine();

                        Write("Row: ");
                        int row = int.Parse(ReadLine());

                        Write("Column: ");
                        int column = int.Parse(ReadLine());

                        if (createShelf.shelfBox[row, column] == null)
                        {
                            createShelf.shelfBox[row - 1, column - 1] = new Box();

                            createShelf.shelfBox[row - 1, column - 1].content = contentName;

                            WriteLine("Sucessfully Added.");
                        }
                        else
                        {
                            WriteLine("Slot occupied.");
                        }
                        ReadKey();
                        

                        break;

                    case ConsoleKey.D4:


                        Write("Row: ");
                        row = int.Parse(ReadLine());

                        Write("Column: ");
                        column = int.Parse(ReadLine());

                        if (createShelf.shelfBox[row - 1, column - 1] != null)
                        {
                            contentName = createShelf.shelfBox[row - 1, column - 1].content;

                            WriteLine("Package successfully retrieved");

                            WriteLine("Content: " + contentName);

                            createShelf.shelfBox[row - 1, column - 1] = null;
                        }
                        else
                        {
                            WriteLine("Slot empty");
                        }

                         ReadKey();

                        

                        break;

                    case ConsoleKey.D5:

                        isTrue = true;

                        break;

                }






            }   
            
        }
    }
}

class Shelf
{
    public string name;
    public Box[,] shelfBox = new Box[0,0];
}


class Box
{
    public string content;

}