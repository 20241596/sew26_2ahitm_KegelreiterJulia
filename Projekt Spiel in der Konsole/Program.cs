
using Microsoft.Win32;
/// Code für Consolensteuerung
using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;





namespace ConsolenSteuerung
{


    internal class Program
    {
        //global variables
        static string[,] gameBoard = new string[30, 30];
        static bool[,] goalList = new bool[30, 30];
        static bool running = true;
        static ConsoleKeyInfo inputkey;
        static ConsoleKey key;
        static int xKoorMaxl, yKoorMaxl;
        static int countGoals;
        static string playerName = "";
        static int footSteps = 0;
        static StreamWriter sw = null;
        static int count = 0;

        static void Input()
        {
            while (running)
            {
                inputkey = Console.ReadKey(true);               //Activate Key
                key = inputkey.Key;
            }

        }
        

        [STAThread]
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;     //for emojis
            Console.CursorVisible = false;


            const int MAX_X = 200;
            const int MAX_Y = 100;

            StartScreen();

            ShowMenu();

            var myThread = new System.Threading.Thread(Input);
            myThread.Start();


            Console.SetWindowSize(MAX_X, MAX_Y);
          
            Console.Title = "Konsolensteuerung von Julia Kegelreiter";

        }
        static void PositionHeading(string ausgabe, int xKoor, int yKoor)
        {
            Console.SetCursorPosition(xKoor, yKoor);                    //Method for Position of Heading
            Console.WriteLine(ausgabe);
            Thread.Sleep(25);

        }
        private static void StartScreen()
        {

            Bitmap bmp = new Bitmap("Startscreen1.bmp"); 
            for (int y = 0; y < bmp.Height; y++) 
            { 
                for (int x = 0; x < bmp.Width; x++) 
                { 
                    Color c = bmp.GetPixel(x, y); 
                    Console.Write($"\x1b[48;2;{c.R};{c.G};{c.B}m ");                    //Picture of startscreen for 5 seconds
                } 
                if (y != bmp.Height-1)
                    Console.Write("\x1b[0m\n"); 
            }
         
               
          
            Thread.Sleep(3000);
            Console.BackgroundColor = ConsoleColor.Black;
            ShowMenu();
            
             
            
           
        }

        static void ShowMenu()
        {
            int activeRow = 0;
            string[] lines = { "Anleitung", "Bestenliste", "Start" };
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;

            PositionHeading("███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗", 0, 0);
            PositionHeading("████╗░████║██╔════╝████╗░██║██║░░░██║", 0, 1);
            PositionHeading("██╔████╔██║█████╗░░██╔██╗██║██║░░░██║", 0, 2);
            PositionHeading("██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║", 0, 3);
            PositionHeading("██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝", 0, 4);
            PositionHeading("╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░", 0, 5);


            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(0, 7);

            Console.WriteLine("Menü (Abbruch mit 'Esc')");
            Console.WriteLine("Um sich im Menü nach oben zu bewegen,drücken Sie die Pfeiltaste nach oben");
            Console.WriteLine("Um sich im Menü nach unten zu bewegen,drücken Sie  die Pfeiltaste nach unten");
            Console.WriteLine("Mit Enter bestätigen");                                                          //Describtion of menu

            Console.WriteLine();
            Console.SetCursorPosition(12, 0);
            while (true)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == activeRow)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(12, 13 + i);
                    Console.WriteLine(lines[i]);
                }
                key = Console.ReadKey(true).Key;                                            //List of menu

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        activeRow--;
                        if (activeRow < 0)
                        {
                            activeRow += lines.Length;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        activeRow++;
                        activeRow %= lines.Length;
                        break;

                    case ConsoleKey.Enter:
                        switch (activeRow)
                        {
                            case 0:
                                Console.Clear();
                                GameInstruction();
                                break;
                            case 1:
                                HighScoreList();
                                break;
                            case 2:

                                Console.BackgroundColor = ConsoleColor.Black;                                
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                PositionHeading("███╗░░██╗░█████╗░███╗░░░███╗███████╗", 0, 0);
                                PositionHeading("████╗░██║██╔══██╗████╗░████║██╔════╝", 0, 1);
                                PositionHeading("██╔██╗██║███████║██╔████╔██║█████╗░░", 0, 2);
                                PositionHeading("██║╚████║██╔══██║██║╚██╔╝██║██╔══╝░░", 0, 3);
                                PositionHeading("██║░╚███║██║░░██║██║░╚═╝░██║███████╗", 0, 4);
                                PositionHeading("╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝", 0, 5);
                                Console.WriteLine();


                                Console.SetCursorPosition(15, 10);
                                Console.Write("Wie heißt du? : ");                                                          //write name 
                                playerName = Console.ReadLine();
                                Start();
                                break;
                        }
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }


        }
              

        private static void GameInstruction()
        {

            Console.Clear();
            Console.WriteLine("Hallo, ich bin Kelly!  🧍‍♀️");
            Console.WriteLine("Ich arbeite in einem Lagerhaus");
            Console.WriteLine("Leider gab es einen Fehler bei der Platzierung von einigen Boxen");
            Console.WriteLine("Deswegen habe ich die Aufgabe bekommen, die Boxen auf dem richtigen Platz zu bringen");
            Console.WriteLine("Ich brauche dafür deine Hilfe! Ich weiß nämlich nicht genau wo die Kisten hinmüssen");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Mit den Pfeiltasten kannst du mir die Richtung vorgeben");
            Console.WriteLine("Die linke Pfeiltaste bewegt mich nach links, die rechte Pfeiltaste nach rechts, die Pfeiltaste nach oben nach oben und die Pfeiltaste nach unten bewegt mich nach unten");
            Console.WriteLine("Überlege gut wo du die Kisten hinbewegst, denn du kannst sie nur schieben");
            Console.WriteLine("So sehen die Boxen aus: 📦");
            Console.WriteLine("Und so sehen die Ziele aus: ❌");
            Console.WriteLine();
            Console.WriteLine("Zurück mit der Enter Taste");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();                                     //Describtion

        }

        static void HighScoreList()
        {

            int activeRow = 0;
            string level = "nothing";
            Console.Clear();
            string[] lines = { "Level1", "Level2", "Level3" };

            Console.ForegroundColor = ConsoleColor.Green;
            PositionHeading("██╗░░░░░███████╗██╗░░░██╗███████╗██╗", 0, 0);
            PositionHeading("██║░░░░░██╔════╝██║░░░██║██╔════╝██║░", 0, 1);
            PositionHeading("██║░░░░░█████╗░░╚██╗░██╔╝█████╗░░██║░", 0, 2);
            PositionHeading("██║░░░░░██╔══╝░░░╚████╔╝░██╔══╝░░██║░░░░", 0, 3);
            PositionHeading("███████╗███████╗░░╚██╔╝░░███████╗███████╗", 0, 4);                                             //Heading level
            PositionHeading("╚══════╝╚══════╝░░░╚═╝░░░╚══════╝╚══════╝", 0, 5);
            Console.WriteLine();

            Console.WriteLine();
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("Drücke Escape um zum Startmenü zu kommen");

            ConsoleKey key = ConsoleKey.NoName;

            while (key != ConsoleKey.E)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.BackgroundColor = (i == activeRow) ? ConsoleColor.White : ConsoleColor.Black;
                    Console.SetCursorPosition(10, 7 + i);
                    Console.WriteLine(lines[i]);
                }

                Console.BackgroundColor = ConsoleColor.Black;

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        activeRow = (activeRow - 1 + lines.Length) % lines.Length;                                              //List of Levels
                        break;

                    case ConsoleKey.DownArrow:
                        activeRow = (activeRow + 1) % lines.Length;
                        break;

                    case ConsoleKey.Enter:
                        level = "score_"+ lines[activeRow] + ".txt";
                        ShowLevelHigscore(level);
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        ShowMenu();
                        break;
                }

                if (key == ConsoleKey.Enter)
                    break;
            }
        }

        static void ShowLevelHigscore(string level)
        {
            Console.Clear();
            string line;

            Console.WriteLine("Aktueller Punktestand:");
            Console.WriteLine();

            var sr = new StreamReader(level);
            for (int i = 0; !sr.EndOfStream; i++)
            {
                line = sr.ReadLine();                                                                           //highscore of tapped level
                Console.WriteLine(line);
            }
            sr.Close();

            Console.WriteLine("Um zurück zum Startmenü zu kommen, drücken Sie die Enter-Taste");
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadLine();

            HighScoreList();
        }

      
        private static void Start()
        {
            Console.Clear();
         
            string level = "nothing";
            string levelScoreName = null;
            int activeRow = 0;
            string[] lines = { "Level1", "Level2", "Level3" };
            footSteps = 0;


            Console.Clear();

            for (int i = 0; i < (gameBoard.GetLength(0)-1); i++)
            { 
                for (int j = 0; j < (gameBoard.GetLength(1)-1); j++)                                                //Level list
                {
                    gameBoard[i, j] = null;
                    goalList[i, j] = false;
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Green;
            PositionHeading("██╗░░░░░███████╗██╗░░░██╗███████╗██╗", 0, 0);
            PositionHeading("██║░░░░░██╔════╝██║░░░██║██╔════╝██║░", 0, 1);
            PositionHeading("██║░░░░░█████╗░░╚██╗░██╔╝█████╗░░██║░", 0, 2);
            PositionHeading("██║░░░░░██╔══╝░░░╚████╔╝░██╔══╝░░██║░░░░", 0, 3);                      //Heading
            PositionHeading("███████╗███████╗░░╚██╔╝░░███████╗███████╗", 0, 4);
            PositionHeading("╚══════╝╚══════╝░░░╚═╝░░░╚══════╝╚══════╝", 0, 5);

            Console.WriteLine();
            Console.WriteLine();

            Console.SetCursorPosition(10, 8);
            Console.WriteLine("Hallo " + playerName);                           //Greeting
            Console.WriteLine();

            ConsoleKey key = ConsoleKey.NoName;

            while (key != ConsoleKey.E)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.BackgroundColor = (i == activeRow) ? ConsoleColor.White : ConsoleColor.Black;
                    Console.SetCursorPosition(10, 10 + i);
                    Console.WriteLine(lines[i]);
                }

                Console.BackgroundColor = ConsoleColor.Black;

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        activeRow = (activeRow - 1 + lines.Length) % lines.Length;
                        break;                                                                  //List of Levels

                    case ConsoleKey.DownArrow:
                        activeRow = (activeRow + 1) % lines.Length;
                        break;

                    case ConsoleKey.Enter:
                        level = lines[activeRow] + ".txt";
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        ShowMenu();
                        break;
                }

                if (key == ConsoleKey.Enter)
                    break;
            }
            levelScoreName = "score_" + level;
            if (sw != null)
            {
                sw.Close();
            }                                                                                   //Write in File score_level...
            sw = new StreamWriter(levelScoreName, append: true);

            BoardInitialize(level);

            DrawBoard();
        
        }

        static void BoardInitialize(string level)
        {
            var sr = new StreamReader(level);
            countGoals = 0;
            Console.Clear();

            string zeile;

            for (int i = 0; !sr.EndOfStream; i++)
            {
                zeile = sr.ReadLine();

                for (int j = 0; j < zeile.Length; j++)
                {

                    switch (zeile[j])
                    {
                        case '#':
                            gameBoard[j, i] = "Wand";
                            break;
                        case 'x':
                            gameBoard[j, i] = "Ziel";
                            goalList[j, i] = true;
                            countGoals++;
                            break;
                        case 'O':
                            gameBoard[j, i] = "Box";                        //Initialize what what is
                            break;
                        case '§':
                            gameBoard[j, i] = "Maxl";
                            xKoorMaxl = j;
                            yKoorMaxl = i;
                            break;
                        case ' ':
                            gameBoard[j, i] = "Leer";
                            break;
                        
                    }

                }
            }
            sr.Close();
        }

        static void DrawBoard()
        {
            int countCurrentGoals = 0;
            Console.SetCursorPosition(0, 0);
 
            for (int x = 0; x < 30; x++)
            {
                if (gameBoard[x, 0] == null)
                { break; }
                for (int y = 0; y < 30; y++)
                {
                    string tile = gameBoard[y, x];

                    switch (tile)
                    {
                        case "Wand":
                            Console.Write("🧱");
                            break;
                        case "Box":
                            Console.Write("📦");
                            if (goalList[y, x] == true)
                            {
                                countCurrentGoals++;                            //every Time a key is tapped new Board
                            }
                            break;
                        case "Ziel":
                            Console.Write("❌");
                            break;
                        case "Maxl":
                            Console.Write("🧍‍♀️");
                            break;
                        case "Leer":
                            if (goalList[y, x] == true)
                            {
                                Console.Write("❌");
                            }
                            else
                            {
                                Console.Write("  ");
                            }
                            break;
                    }
                }
                Console.WriteLine();

            }

            if (countCurrentGoals == countGoals)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(playerName +" du hast gewonnen!!!");                  //winning
              
                sw.WriteLine(playerName + ": " + footSteps);
                sw.Flush();
                sw.Close();

            }
            else
            {
                
                Console.WriteLine("Bisher " + countCurrentGoals + " Boxen im Ziel");
                Console.WriteLine("Schritte bisher: " + footSteps);                                         //how much Boxes are in goal, how much footsteps are made

                Console.WriteLine();
            }

           Console.WriteLine("Drücke Escape um zur Levelauswahl zu gelangen");

            Movement();
        }

 
        static void Movement()
        {
            //Conditions
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);


                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (gameBoard[xKoorMaxl, yKoorMaxl - 1] == "Leer" || gameBoard[xKoorMaxl, yKoorMaxl - 1] == "Ziel")
                            {
                                gameBoard[xKoorMaxl, yKoorMaxl - 1] = "Maxl";
                                gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";

                                yKoorMaxl--;
                                footSteps++;

                            }
                            else if (gameBoard[xKoorMaxl, yKoorMaxl - 1] == "Box")
                            {
                                if (gameBoard[xKoorMaxl, yKoorMaxl - 2] == "Leer" || gameBoard[xKoorMaxl, yKoorMaxl - 2] == "Ziel")
                                {
                                    gameBoard[xKoorMaxl, yKoorMaxl - 1] = "Maxl";
                                    gameBoard[xKoorMaxl, yKoorMaxl - 2] = "Box";
                                    gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";

                                    yKoorMaxl--;
                                    footSteps++;
                                }
                            }
                            DrawBoard();

                            break;

                        case ConsoleKey.DownArrow:
                            if (gameBoard[xKoorMaxl, yKoorMaxl + 1] == "Leer" || gameBoard[xKoorMaxl, yKoorMaxl + 1] == "Ziel")
                            {
                                gameBoard[xKoorMaxl, yKoorMaxl + 1] = "Maxl";
                                gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";
                                yKoorMaxl++;
                                footSteps++;
                            }
                            else if (gameBoard[xKoorMaxl, yKoorMaxl + 1] == "Box")
                            {
                                if (gameBoard[xKoorMaxl, yKoorMaxl + 2] == "Leer" || gameBoard[xKoorMaxl, yKoorMaxl + 2] == "Ziel")
                                {
                                    gameBoard[xKoorMaxl, yKoorMaxl + 1] = "Maxl";
                                    gameBoard[xKoorMaxl, yKoorMaxl + 2] = "Box";
                                    gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";
                                    yKoorMaxl++;
                                    footSteps++;
                                }
                            }
                            DrawBoard();
                            break;

                        case ConsoleKey.LeftArrow:
                            if (gameBoard[xKoorMaxl - 1, yKoorMaxl] == "Leer" || gameBoard[xKoorMaxl - 1, yKoorMaxl] == "Ziel")
                            {
                                gameBoard[xKoorMaxl - 1, yKoorMaxl] = "Maxl";
                                gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";
                                xKoorMaxl--;
                                footSteps++;
                            }
                            else if (gameBoard[xKoorMaxl - 1, yKoorMaxl] == "Box")
                            {
                                if (gameBoard[xKoorMaxl - 2, yKoorMaxl] == "Leer" || gameBoard[xKoorMaxl - 2, yKoorMaxl] == "Ziel")
                                {
                                    gameBoard[xKoorMaxl - 1, yKoorMaxl] = "Maxl";
                                    gameBoard[xKoorMaxl - 2, yKoorMaxl] = "Box";
                                    gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";
                                    xKoorMaxl--;
                                    footSteps++;
                                }

                            }
                           
                            DrawBoard();
                            break;

                        case ConsoleKey.RightArrow:
                            if (gameBoard[xKoorMaxl + 1, yKoorMaxl] == "Leer" || gameBoard[xKoorMaxl + 1, yKoorMaxl] == "Ziel")
                            {
                                gameBoard[xKoorMaxl + 1, yKoorMaxl] = "Maxl";
                                gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";
                                xKoorMaxl++;
                                footSteps++;
                            }
                            else if (gameBoard[xKoorMaxl + 1, yKoorMaxl] == "Box")
                            {
                                if (gameBoard[xKoorMaxl + 2, yKoorMaxl] == "Leer" || gameBoard[xKoorMaxl + 2, yKoorMaxl] == "Ziel")
                                {
                                    gameBoard[xKoorMaxl + 1, yKoorMaxl] = "Maxl";
                                    gameBoard[xKoorMaxl + 2, yKoorMaxl] = "Box";
                                    gameBoard[xKoorMaxl, yKoorMaxl] = "Leer";
                                    xKoorMaxl++;
                                    footSteps++;
                                }
                            }
                            DrawBoard();
                            break;

                        case ConsoleKey.Escape:
                            Start();
                            break;
                    }
                }

                Thread.Sleep(10); 
            }

        }

    }
}
