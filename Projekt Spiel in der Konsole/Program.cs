
using Microsoft.Win32;
/// Code für Consolensteuerung
using System;
using System.Threading;

using System.IO;



namespace ConsolenSteuerung
{


    internal class Program
    {
        static bool running = true;
        static ConsoleKeyInfo inputkey;
        static ConsoleKey key;

        static string[,] spielBrett;



        static string LadeDatei()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Textdateien|*.txt|Alle Dateien|*.*";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return File.ReadAllText(dialog.FileName);
            }

            return null;
        }


        static void Eingabe()
        {


            while (running)
            {
                inputkey = Console.ReadKey(true);
                key = inputkey.Key;
            }

        }

        [STAThread]
        static void Main(string[] args)
        {
            spielBrett = new string[100, 100];

            const int MAX_X = 70;
            const int MAX_Y = 40;

            StartScreen();

            MenuAusgabe();

            // parallele Methode zum Einlesen des Tastendrucks
            var myThread = new System.Threading.Thread(Eingabe);
            myThread.Start();

            Console.SetWindowSize(MAX_X, MAX_Y);    // Konsolen Größe 
            Console.Title = "Konsolensteuerung von Julia Kegelreiter";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Konsole - 2AHITM - Kegelreiter Julia");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bunt ist cool!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            System.Threading.Thread.Sleep(1000);
            Console.Clear();



        }




        private static void StartScreen()
        {
            int runx = 0;

            Console.SetCursorPosition(5, 4);

            while (runx < 95)
            {
                Console.Write('#');                     //Zeile 1
                Thread.Sleep(5);
                runx++;

            }





            KreuzAusgabe("#", 5, 5);

            BoxAusgabe(6, 5);

            KreuzAusgabe("#", 8, 5);

            Console.SetCursorPosition(10, 5);
            Console.ForegroundColor = ConsoleColor.Red;                             //Zeile 2
            Console.WriteLine('O');
            Thread.Sleep(25);

            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("#", 50, 5);

            KreuzAusgabe("#", 30, 5);
            KreuzAusgabe("#", 99, 5);


            Console.SetCursorPosition(5, 5);
            for (int i = 5; i < 21; i++)
            {
                Console.WriteLine("#");

                Console.SetCursorPosition(5, i);
                Thread.Sleep(5);

            }



            Console.SetCursorPosition(99, 5);
            for (int i = 5; i < 21; i++)
            {
                Console.WriteLine("#");

                Console.SetCursorPosition(99, i);
                Thread.Sleep(5);

            }



            KreuzAusgabe("#", 5, 6);

            KreuzAusgabe("#", 8, 6);

            Console.SetCursorPosition(10, 6);
            Console.ForegroundColor = ConsoleColor.Red;                             //Zeile 3
            Console.Write('O');
            Thread.Sleep(25);

            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("#", 50, 6);

            KreuzAusgabe("#", 30, 6);

            KreuzAusgabe("#", 99, 6);

            KreuzAusgabe("#", 5, 7);

            KreuzAusgabe("#", 8, 7);







            BoxAusgabe(9, 7);

            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("#", 30, 7);
            //Zeile 4
            KreuzAusgabe("## #####", 33, 7);

            BoxAusgabe(48, 7);

            KreuzAusgabe("#", 50, 7);

            KreuzAusgabe("###########", 66, 7);

            KreuzAusgabe("#", 99, 7);






            KreuzAusgabe("#", 5, 8);

            KreuzAusgabe("#", 8, 8);

            KreuzAusgabe("#", 30, 8);                                //Zeile 5

            KreuzAusgabe("## ######", 33, 8);

            KreuzAusgabe("#", 50, 8);

            KreuzAusgabe("######", 68, 8);

            KreuzAusgabe("#", 99, 8);






            Console.SetCursorPosition(10, 12);

            Console.ForegroundColor = ConsoleColor.Yellow;

            KreuzAusgabe(" ____                                                   ", 20, 9);
            KreuzAusgabe(" | __ )  _____  _____ _ __                              ", 20, 10);
            KreuzAusgabe(" |  _ \\ / _ \\ \\/ / _ \\ '_ \\                             ", 20, 11);
            KreuzAusgabe(" | |_) | (_) >  <  __/ | | |                            ", 20, 12);
            KreuzAusgabe(" |____/ \\___/_/\\_\\___|_| |_|    _      _                ", 20, 13);
            KreuzAusgabe(" __   _____ _ __ ___  ___| |__ (_) ___| |__   ___ _ __  ", 20, 14);
            KreuzAusgabe(" \\ \\ / / _ \\ '__/ __|/ __| '_ \\| |/ _ \\ '_ \\ / _ \\ '_ \\", 20, 15);
            KreuzAusgabe("  \\ V /  __/ |  \\__ \\ (__| | | | |  __/ |_) |  __/ | | |", 20, 16);
            KreuzAusgabe("   \\_/ \\___|_|  |___/\\___|_| |_|_|\\___|_.__/ \\___|_| |_|", 20, 17);





            //Anschrift
            Thread.Sleep(25);
            Console.ForegroundColor = ConsoleColor.White;

            int runy = 9;
            do
            {
                Console.SetCursorPosition(5, runy);
                Console.WriteLine('#');
                Console.SetCursorPosition(99, runy);
                Console.WriteLine("#");
                runy++;
            } while (runy < 16);







            KreuzAusgabe("#", 5, 19);

            KreuzAusgabe("#", 8, 19);

            KreuzAusgabe("#", 30, 19);                                     //Zeile 18

            KreuzAusgabe("## ########", 33, 19);

            KreuzAusgabe("##############", 40, 19);

            Console.SetCursorPosition(52, 19);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('O');
            Thread.Sleep(25);
            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("######", 68, 19);

            KreuzAusgabe("#", 99, 19);




            Console.SetCursorPosition(78, 19);

            runx = 0;
            for (int straight = 5; straight < 15; straight++)
            {
                Console.Write('#');
                Thread.Sleep(10);                                               //mix Strecke nach unten
                runx++;
                Console.SetCursorPosition(78, straight);


            }




            KreuzAusgabe("#", 5, 20);

            KreuzAusgabe("#", 8, 20);

            KreuzAusgabe("#", 20, 20);                                 //Zeile 15

            KreuzAusgabe("## ## # ###", 30, 20);

            Console.SetCursorPosition(43, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('O');
            Thread.Sleep(25);
            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("##########", 50, 20);

            KreuzAusgabe("######", 68, 20);

            Console.SetCursorPosition(10, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('O');
            Thread.Sleep(25);
            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("#", 99, 20);




            KreuzAusgabe("#", 5, 21);


            BoxAusgabe(6, 21);

            Console.ForegroundColor = ConsoleColor.White;

            KreuzAusgabe("#", 30, 21);
            //Zeile 4
            KreuzAusgabe("## ######", 33, 21);                                         //Zeile 16

            BoxAusgabe(42, 21);

            KreuzAusgabe("#", 50, 21);

            KreuzAusgabe("########", 66, 21);

            KreuzAusgabe("### #########", 78, 21);

            KreuzAusgabe("#", 99, 21);

            Console.SetCursorPosition(5, 22);



            runx = 0;
            while (runx < 95)
            {                                                                   //Zeile 17
                Console.Write('#');
                Thread.Sleep(5);
                runx++;

            }

            Console.SetCursorPosition(5, 25);

            Console.Write("Press ENTER to continue...");

            Console.ReadKey(true);
            //Wartezeit

            Console.Clear();

        }

        static int KreuzAusgabe(string ausgabe, int xKoor, int yKoor)
        {
            Console.SetCursorPosition(xKoor, yKoor);
            Console.Write(ausgabe);
            Thread.Sleep(25);
            return 0;
        }

        static int BoxAusgabe(int xKoor, int yKoor)
        {
            Console.SetCursorPosition(xKoor, yKoor);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("■");
            Thread.Sleep(25);
            Console.ForegroundColor = ConsoleColor.White;
            return 0;
        }

        private static void MenuAusgabe()
        {
            int aktiveZeile = 0;
            string[] zeilen = { "Spielerklärung", "Bestenliste", "Start" };
            Console.Clear();
            Console.SetCursorPosition(10, 0);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Menü (Abbruch mit 'e')");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Um sich im Menü nach oben zu bewegen, drücken Sie die Taste w");
            Console.WriteLine("Um sich im Menü nach unten zu bewegen drücken Sie die Taste s");

            Console.WriteLine();


            while (key != ConsoleKey.E)
            {
                for (int i = 0; i < zeilen.Length; i++)
                {
                    if (i == aktiveZeile)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(zeilen[i]);
                }
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        aktiveZeile--;
                        if (aktiveZeile < 0)
                        {
                            aktiveZeile += zeilen.Length;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        aktiveZeile++;
                        aktiveZeile %= zeilen.Length;
                        break;

                    case ConsoleKey.Enter:
                        switch (aktiveZeile)
                        {
                            case 0:
                                Console.Clear();
                                SpielErklärung();
                                break;


                            case 2:

                                Start();
                                break;


                        }
                        break;



                }



            }

        }

        private static void SpielErklärung()
        {

            Console.Clear();
            Console.WriteLine("Hallo, ich bin Sammy!");
            Console.WriteLine("Ich arbeite als Stapelfahrer am Hafen ");
            Console.WriteLine("Leider gab es einen Fehler bei der Platzierung von einigen Boxen");
            Console.WriteLine("Ich habe jetzt die Aufgabe bekommen die Boxen auf dem richtigen Platz zu bringen, damit es zu keiner Verwirrung kommt");
            Console.WriteLine("Ich brauche dafür deine Hilfe! Ich weiß nämlich nicht genau wo sich die Container befinden");
            Console.WriteLine("Mithilfe der Karte vom Hafen wirst du mir helfen sie auf ihren Platz zu fahren und zu platzieren");
            Console.WriteLine("Um mir zu sagen, dass ich nach oben gehen soll drücke die Pfeiltaste nach oben");
            Console.ReadLine();
        }

        static int KoordinateVonMaxl(out int yKoorMaxl)
        {
            string gesucht = "Maxl";
            int xKoorMaxl = -1;
            yKoorMaxl = -1;

            for (int i = 0; i < spielBrett.GetLength(0); i++)
            {
                for (int j = 0; j < spielBrett.GetLength(1); j++)
                {
                    if (spielBrett[i, j] == gesucht)
                    {
                        yKoorMaxl = i;
                        xKoorMaxl = j;
                        return xKoorMaxl;
                    }


                }

            }

            return xKoorMaxl;
        }


        private static void Brett()
        {
            int counter = 7;

            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(39, counter);
                spielBrett[0, i] = "Wand";
                Console.WriteLine('#');
                counter++;
            }

            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(39, counter);
                spielBrett[i, 0] = "Wand";
                Console.WriteLine('#');
                counter++;
            }


            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, Console.WindowHeight / 2 - 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            spielBrett[Console.WindowWidth / 2 - 1, Console.WindowHeight / 2 - 1] = "Maxl";

            Console.Write("L");

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(counter, 40);
                spielBrett[0, i] = "Wand";
                Console.WriteLine('#');
                counter++;
            }


        }




        private static void Start()
        {
            string level = "nothing";
            int aktiveZeile = 0;
            string[] zeilen = { "Level 1", "Level 2", "Level 3" };
            Console.Clear();
            Console.SetCursorPosition(10, 0);



            while (key != ConsoleKey.E)
            {
                for (int i = 0; i < zeilen.Length; i++)
                {
                    if (i == aktiveZeile)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(10, 4 + i);
                    Console.WriteLine(zeilen[i]);
                }
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        aktiveZeile--;
                        if (aktiveZeile < 0)
                        {
                            aktiveZeile += zeilen.Length;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        aktiveZeile++;
                        aktiveZeile %= zeilen.Length;
                        break;

                    case ConsoleKey.Enter:
                        switch (aktiveZeile)
                        {
                            case 0:
                                level = "Level1";
                                break;

                            case 1:
                                level = "Level2";
                                break;

                            case 2:
                                level = "Level3";
                                break;


                        }
                        break;



                }



            }

            int maxWidth = 0;
            int maxLength = 0;
            var sr = new StreamReader(level);
            char[,] zeichen = new char[40,40];
            string zeile;

            for (int i = 0; !sr.EndOfStream; i++)
            {
                zeile = sr.ReadLine();
                
                for(int j = 0; j < zeile.Length; j++)
                {
                    zeichen[j, i] = zeile[j];
                }

                Console.WriteLine(zeile);
            }


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();







            Console.ForegroundColor = ConsoleColor.White;

            Brett();


            int xKoorMaxl = KoordinateVonMaxl(out int yKoorMaxl);

            while (true)
            {

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (spielBrett[xKoorMaxl, yKoorMaxl - 1] == "Leer")
                        {
                            spielBrett[xKoorMaxl, yKoorMaxl - 1] = "Maxl";
                            spielBrett[xKoorMaxl, yKoorMaxl] = "Leer";

                        }
                        else if (spielBrett[xKoorMaxl, yKoorMaxl - 1] == "Box")
                        {
                            if (spielBrett[xKoorMaxl, yKoorMaxl - 2] == "Leer")
                            {
                                spielBrett[xKoorMaxl, yKoorMaxl - 1] = "Maxl";
                                spielBrett[xKoorMaxl, yKoorMaxl - 2] = "Box";
                                spielBrett[xKoorMaxl, yKoorMaxl] = "Leer";

                            }
                            else if (spielBrett[xKoorMaxl, yKoorMaxl - 2] == "Ziel")
                            {
                                spielBrett[xKoorMaxl, yKoorMaxl - 1] = "Maxl";
                                spielBrett[xKoorMaxl, yKoorMaxl - 2] = "BoxImZiel";
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (spielBrett[xKoorMaxl, yKoorMaxl + 1] == "Leer")
                        {
                            spielBrett[xKoorMaxl, yKoorMaxl + 1] = "Maxl";
                            spielBrett[xKoorMaxl, yKoorMaxl] = "Leer";

                        }
                        else if (spielBrett[xKoorMaxl, yKoorMaxl + 1] == "Box")
                        {
                            if (spielBrett[xKoorMaxl, yKoorMaxl + 2] == "Leer")
                            {
                                spielBrett[xKoorMaxl, yKoorMaxl + 1] = "Maxl";
                                spielBrett[xKoorMaxl, yKoorMaxl + 2] = "Box";
                                spielBrett[xKoorMaxl, yKoorMaxl] = "Leer";

                            }
                            else if (spielBrett[xKoorMaxl, yKoorMaxl + 2] == "Ziel")
                            {
                                spielBrett[xKoorMaxl, yKoorMaxl + 1] = "Maxl";
                                spielBrett[xKoorMaxl, yKoorMaxl + 2] = "BoxImZiel";
                            }
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (spielBrett[xKoorMaxl - 1, yKoorMaxl] == "Leer")
                        {
                            spielBrett[xKoorMaxl - 1, yKoorMaxl] = "Maxl";
                            spielBrett[xKoorMaxl, yKoorMaxl] = "Leer";

                        }
                        else if (spielBrett[xKoorMaxl - 1, yKoorMaxl] == "Box")
                        {
                            if (spielBrett[xKoorMaxl - 2, yKoorMaxl] == "Leer")
                            {
                                spielBrett[xKoorMaxl - 1, yKoorMaxl] = "Maxl";
                                spielBrett[xKoorMaxl - 2, yKoorMaxl] = "Box";
                                spielBrett[xKoorMaxl, yKoorMaxl] = "Leer";

                            }
                            else if (spielBrett[xKoorMaxl - 2, yKoorMaxl] == "Ziel")
                            {
                                spielBrett[xKoorMaxl - 1, yKoorMaxl] = "Maxl";
                                spielBrett[xKoorMaxl - 2, yKoorMaxl] = "BoxImZiel";
                            }
                        }
                        break;
                }

            }
        }
    }
}