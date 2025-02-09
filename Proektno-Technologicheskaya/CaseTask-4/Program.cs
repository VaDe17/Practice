using System;
using System.Threading;
using System.Diagnostics;

namespace Tetris
{


    class Program
    {
        const int mapSizeX = 10;
        const int mapSizeY = 20;
        static char[,] bg = new char[mapSizeY, mapSizeX];


        static int score = 0;


        const int holdSizeX = 6;
        const int holdSizeY = mapSizeY;
        static int holdIndex = -1;
        static char holdChar;

        const int upNextSize = 6;


        static ConsoleKeyInfo input;



        static int currentX = 0;
        static int currentY = 0;
        static char currentChar = 'O';

        static int currentRot = 0;


      
        static int[] bag;
        static int[] nextBag;

        static int bagIndex;
        static int currentIndex;


        static int maxTime = 20;
        static int timer = 0;
        static int amount = 0;


        #region Assets

        readonly static string characters = "OILJSZT";
        readonly static int[,,,] positions =
        {
        {
        {{0,0},{1,0},{0,1},{1,1}},
        {{0,0},{1,0},{0,1},{1,1}},
        {{0,0},{1,0},{0,1},{1,1}},
        {{0,0},{1,0},{0,1},{1,1}}
        },

        {
        {{2,0},{2,1},{2,2},{2,3}},
        {{0,2},{1,2},{2,2},{3,2}},
        {{1,0},{1,1},{1,2},{1,3}},
        {{0,1},{1,1},{2,1},{3,1}},
        },
        {
        {{1,0},{1,1},{1,2},{2,2}},
        {{1,2},{1,1},{2,1},{3,1}},
        {{1,1},{2,1},{2,2},{2,3}},
        {{2,1},{2,2},{1,2},{0,2}}
        },

        {
        {{2,0},{2,1},{2,2},{1,2}},
        {{1,1},{1,2},{2,2},{3,2}},
        {{2,1},{1,1},{1,2},{1,3}},
        {{0,1},{1,1},{2,1},{2,2}}
        },

        {
        {{2,1},{1,1},{1,2},{0,2}},
        {{1,0},{1,1},{2,1},{2,2}},
        {{2,1},{1,1},{1,2},{0,2}},
        {{1,0},{1,1},{2,1},{2,2}}
        },
        {
        {{0,1},{1,1},{1,2},{2,2}},
        {{1,0},{1,1},{0,1},{0,2}},
        {{0,1},{1,1},{1,2},{2,2}},
        {{1,0},{1,1},{0,1},{0,2}}
        },

        {
        {{0,1},{1,1},{1,0},{2,1}},
        {{1,0},{1,1},{2,1},{1,2}},
        {{0,1},{1,1},{1,2},{2,1}},
        {{1,0},{1,1},{0,1},{1,2}}
        }
        };
        #endregion
        static void Main()
        {
            Thread inputThread = new Thread(Input);
            inputThread.Start();
            bag = GenerateBag();
            nextBag = GenerateBag();
            NewBlock();

            for (int y = 0; y < mapSizeY; y++)
                for (int x = 0; x < mapSizeX; x++)
                    bg[y, x] = '-';

            while (true)
            {

                if (timer >= maxTime)
                {
                    if (!Collision(currentIndex, bg, currentX, currentY + 1, currentRot)) currentY++;
                    else BlockDownCollision();

                    timer = 0;
                }
                timer++;

                InputHandler(); 
                input = new ConsoleKeyInfo(); 
                char[,] view = RenderView(); 

                char[,] hold = RenderHold(); 
                char[,] next = RenderUpNext(); 

                Print(view, hold, next); 

                Thread.Sleep(20); 
            }


        }


        static void InputHandler()
        {
            switch (input.Key)
            {

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (!Collision(currentIndex, bg, currentX - 1, currentY, currentRot)) currentX -= 1;
                    break;


                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (!Collision(currentIndex, bg, currentX + 1, currentY, currentRot)) currentX += 1;
                    break;


                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    int newRot = currentRot + 1;
                    if (newRot >= 4) newRot = 0;
                    if (!Collision(currentIndex, bg, currentX, currentY, newRot)) currentRot = newRot;

                    break;


                case ConsoleKey.Spacebar:
                    int i = 0;
                    while (true)
                    {
                        i++;
                        if (Collision(currentIndex, bg, currentX, currentY + i, currentRot))
                        {
                            currentY += i - 1;
                            break;
                        }

                    }
                    score += i + 1;
                    break;

 
                case ConsoleKey.Escape:
                    Environment.Exit(1);
                    break;

                case ConsoleKey.Enter:

                    if (holdIndex == -1)
                    {
                        holdIndex = currentIndex;
                        holdChar = currentChar;
                        NewBlock();
                    }
                    // If there is:
                    else
                    {
                        if (!Collision(holdIndex, bg, currentX, currentY, 0)) 
                        {

                            int c = currentIndex;
                            char ch = currentChar;
                            currentIndex = holdIndex;
                            currentChar = holdChar;
                            holdIndex = c;
                            holdChar = ch;
                        }

                    }
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    timer = maxTime;
                    break;

                case ConsoleKey.R:
                    Restart();
                    break;

                default:
                    break;
            }
        }
        static void BlockDownCollision()
        {

            for (int i = 0; i < positions.GetLength(2); i++)
            {
                bg[positions[currentIndex, currentRot, i, 1] + currentY, positions[currentIndex, currentRot, i, 0] + currentX] = currentChar;
            }

            while (true)
            {
                int lineY = Line(bg);

                if (lineY != -1)
                {
                    ClearLine(lineY);

                    continue;
                }
                break;
            }
            NewBlock();

        }


        static void Restart()
        {
            var applicationPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Process.Start(applicationPath);
            Environment.Exit(Environment.ExitCode);
        }

        static void ClearLine(int lineY)
        {
            score += 40;
            for (int x = 0; x < mapSizeX; x++) bg[lineY, x] = '-';

            for (int y = lineY - 1; y > 0; y--)
            {
                for (int x = 0; x < mapSizeX; x++)
                
                    char character = bg[y, x];
                    if (character != '-')
                    {
                        bg[y, x] = '-';
                        bg[y + 1, x] = character;
                    }

                }
            }
        }

        static char[,] RenderView()
        {
            char[,] view = new char[mapSizeY, mapSizeX];

            for (int y = 0; y < mapSizeY; y++)
                for (int x = 0; x < mapSizeX; x++)
                    view[y, x] = bg[y, x];


            for (int i = 0; i < positions.GetLength(2); i++)
            {
                view[positions[currentIndex, currentRot, i, 1] + currentY, positions[currentIndex, currentRot, i, 0] + currentX] = currentChar;
            }
            return view;
        }

        static char[,] RenderHold()
        {
            char[,] hold = new char[holdSizeY, holdSizeX];
            for (int y = 0; y < holdSizeY; y++)
                for (int x = 0; x < holdSizeX; x++)
                    hold[y, x] = ' ';


            if (holdIndex != -1)
            {
                for (int i = 0; i < positions.GetLength(2); i++)
                {
                    hold[positions[holdIndex, 0, i, 1] + 1, positions[holdIndex, 0, i, 0] + 1] = holdChar;
                }
            }
            return hold;
        }
        static char[,] RenderUpNext()
        {
            char[,] next = new char[mapSizeY, upNextSize];
            for (int y = 0; y < mapSizeY; y++)
                for (int x = 0; x < upNextSize; x++)
                    next[y, x] = ' ';


            int nextBagIndex = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int l = 0; l < positions.GetLength(2); l++)
                {
                    if (i + bagIndex >= 7) 
                        next[positions[nextBag[nextBagIndex], 0, l, 1] + 5 * i, positions[nextBag[nextBagIndex], 0, l, 0] + 1] = characters[nextBag[nextBagIndex]];
                    else
                        next[positions[bag[bagIndex + i], 0, l, 1] + 5 * i, positions[bag[bagIndex + i], 0, l, 0] + 1] = characters[bag[bagIndex + i]];


                }
                if (i + bagIndex >= 7) nextBagIndex++;
            }
            return next;

        }

        static void Print(char[,] view, char[,] hold, char[,] next)
        {
            for (int y = 0; y < mapSizeY; y++)
            {

                for (int x = 0; x < holdSizeX + mapSizeX + upNextSize; x++)
                {
                    char i = ' ';
                    if (x < holdSizeX) i = hold[y, x];
                    else if (x >= holdSizeX + mapSizeX) i = next[y, x - mapSizeX - upNextSize];
                    else i = view[y, (x - holdSizeX)];


                    // Colours
                    switch (i)
                    {
                        case 'O':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(i);
                            break;
                        case 'I':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(i);
                            break;

                        case 'T':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(i);
                            break;

                        case 'S':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(i);
                            break;
                        case 'Z':
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(i);
                            break;
                        case 'L':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(i);
                            break;

                        case 'J':
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(i);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(i);
                            break;
                    }

                }
                if (y == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("   " + score);
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, Console.CursorTop - mapSizeY);
        }
        static int[] GenerateBag()
        {
            Random random = new Random();
            int n = 7;
            int[] ret = { 0, 1, 2, 3, 4, 5, 6, 7 };
            while (n > 1)
            {
                int k = random.Next(n--);
                int temp = ret[n];
                ret[n] = ret[k];
                ret[k] = temp;

            }
            return ret;

        }
        static bool Collision(int index, char[,] bg, int x, int y, int rot)
        {

            for (int i = 0; i < positions.GetLength(2); i++)
            {
                if (positions[index, rot, i, 1] + y >= mapSizeY || positions[index, rot, i, 0] + x < 0 || positions[index, rot, i, 0] + x >= mapSizeX)
                {
                    return true;
                }
                if (bg[positions[index, rot, i, 1] + y, positions[index, rot, i, 0] + x] != '-')
                {
                    return true;
                }
            }

            return false;
        }

        static int Line(char[,] bg)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                bool i = true;
                for (int x = 0; x < mapSizeX; x++)
                {
                    if (bg[y, x] == '-')
                    {
                        i = false;
                    }
                }
                if (i) return y;
            }

            return -1;
        }

        static void NewBlock()
        {
            if (bagIndex >= 7)
            {
                bagIndex = 0;
                bag = nextBag;
                nextBag = GenerateBag();
            }

            currentY = 0;
            currentX = 4;
            currentChar = characters[bag[bagIndex]];
            currentIndex = bag[bagIndex];

            if (Collision(currentIndex, bg, currentX, currentY, currentRot) && amount > 0)
            {
                GameOver();
            }
            bagIndex++;
            amount++;
        }


        static void GameOver()
        {
            Environment.Exit(1);
        }
        static void Input()
        {
            while (true)
            {
                input = Console.ReadKey(true);
            }
        }
    }
}
