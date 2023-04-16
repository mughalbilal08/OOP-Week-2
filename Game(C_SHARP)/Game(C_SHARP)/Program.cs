using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;
using Game_C_SHARP_.BL;
namespace Game_C_SHARP_
{
    class Program
    {
        static void Main(string[] args)
        {

            //                   ########################### ARRAYS ##############################
                     
            int score = 0;
            int healthE = 100;
            int healthP = 100;
            int enemy1Shot = 0;
            bool enemy1present = true;            
            string enemyDirection1 = "down";
            
            //    PLAYER COORDINATES;

            char up = (char)94;
            char box = (char)219;
            char[,] ship = new char[2, 5]{
                { ' ', ' ', up, ' ', ' '},
                { '-', box, box, box, '-'}
                };

            //  Enemy  PLAYER COORDINATES;

            char[,] enemy = new char[2, 5]{
             { '-', box, box, box, '-'},
             { ' ', ' ', up, ' ', ' '},
            };

            //    Maze;

            char[,] maze2D = new char[26, 130];

       
            //    Classes            
            
            
            List<bulletsP> Q = new List<bulletsP>();
            data game = new data();
            game.shipX = 22;
            game.shipY = 60;

            List<enemyB> W = new List<enemyB>();
            enemy game2 = new enemy();
            game2.enemyX = 3;
            game2.enemyY = 5;


            //                                    ##################### Body #########################       

            int option = 0;
            Console.Clear();
            loading();
            Console.Clear();
            header();
            loadmaze(ref maze2D);
            printingMaze1(ref maze2D);
            storemaze(ref  maze2D);
            
//            bool run = true;
            while(option != 3)
            {
                Console.Clear();
                header();
                
                option = login();
                if (option == 1)
                {
                    
                    int choice = gamemenu();
                    if (choice == 1)
                    {
                        
                        startGame(ref enemy1present, ref enemy1Shot, ref enemyDirection1, ref maze2D, ref ship, ref enemy,W, game, game2,Q,ref healthP, ref healthE, ref score);
                       // storemaze(ref maze2D);
                    }
                    if (choice == 2)
                    {
                        Console.Write("COMING");
                        
                    }
                }
                if (option == 2)
                {
                    Console.Clear();
                    header();
                    keys();
                    Console.ReadKey();
                    
                }

                if (option == 3)
                {
                    Console.Clear();
                    
                }

            }

        }

        //                                           ################### Printing ######################## 
        public static int login()
        {
            int choice;
            Console.WriteLine("Press 1 To Start The Game: ");
            Console.WriteLine("Press 2 to Read Instructions oF the Game: ");
            Console.WriteLine("Press 3 To Exit The Game: ");
            Console.WriteLine("...................................");
            Console.WriteLine("Enter Your Choice ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void header()
        {
            Console.WriteLine();
            Console.WriteLine("         _______   __   __   ___   _______    _     _   _______   ______    ");
            Console.WriteLine("        |       | |  | |  | |   | |       |  | | _ | | |   _   | |    _ |   ");
            Console.WriteLine("        |  _____| |  |_|  | |   | |    _  |  | || || | |  |_|  | |   | ||   ");
            Console.WriteLine("        | |_____  |       | |   | |   |_| |  |       | |       | |   |_||_  ");
            Console.WriteLine("        |_____  | |       | |   | |    ___|  |       | |       | |    __  | ");
            Console.WriteLine("         _____| | |   _   | |   | |   |      |   _   | |   _   | |   |  | | ");
            Console.WriteLine("        |_______| |__| |__| |___| |___|      |__| |__| |__| |__| |___|  |_| ");
            Console.WriteLine();
        }
        public static void clear()
        {
            Console.WriteLine();
            Console.Write("Press Any Key To Continuou");
            Console.Clear();
            Console.WriteLine();
        }
        public static void keys()
        {
            Console.WriteLine("1. UP         GO UP");
            Console.WriteLine("2. DOWN       GO DOWN");
            Console.WriteLine("3. LEFT       GO LEFT");
            Console.WriteLine("4. RIGHT      GO RIGHT");
            Console.WriteLine("5. SPACE      Fire");
        }
        public static int gamemenu()
        {

            int choice = 0;
            Console.Clear();
            header();
            Console.WriteLine("Press 1 To Start The New Game: " );
            Console.WriteLine("Press 2 To Load Old Saved Game: " );
            Console.WriteLine("Press 3 To Exit The Game: " );
            Console.WriteLine("..................................." );
            Console.WriteLine("Enter Your Choice " );
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static void loading()

        {
  
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine( "                                   .                                                 # #  ( )                      .                   .                                            " );
            Console.WriteLine( "                                     ..                                       ___#_#___|__                             .                                                            " );
            Console.WriteLine( "             .        .          .                                        _  |____________|  _                                 .               .                                    " );
            Console.WriteLine( "          .    .        .                                          _=====| | |            | | |====_                               .     .                                          " );
            Console.WriteLine( "               .                                            =====| |.---------------------------. | |====                  . ..         .                                          " );
            Console.WriteLine( "         .        . .                         <--------------------'   .  .  .  .  .  .  .  .   '----------------//                 ..                                               " );
            Console.WriteLine( "                     .                          \\                                                               //                .                                                  " );
            Console.WriteLine( "         .             ..     ..                 \\                                                             //        ..    .. .                                                 " );
            Console.WriteLine( "                ..       .    .                   \\_______________________________________________WWS_________//            .           .                                         " );
            Console.WriteLine( "        .                ..              wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww         . .     . .                                         " );
            Console.WriteLine( "          ..              ..            wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww        .                                               " );
            Console.WriteLine( "                                          wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww                   . .                                    " );

 
            Console.WriteLine( "        --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- " );
            Console.WriteLine( );
            Console.WriteLine( );
            Console.WriteLine( );
            Console.WriteLine( );

            char box =(char) 219;

           

            Console.WriteLine( "                                                          Your Game Is Loading ");
            for (int i = 0; i < 9; i++)
            {
                Thread.Sleep(300);
            }
            Console.WriteLine( );
        }
        static void printScore(int healthP, int healthE, int score)
        {
            Console.SetCursorPosition(140, 11);
            Console.WriteLine("Score: " + score);

            Console.SetCursorPosition(140, 10);
            Console.WriteLine("Health is: " + healthP);
          
            Console.SetCursorPosition(140, 12);
            Console.WriteLine("Enemy Health is: " + healthE);

        }

        //                                           ################# MAZE PRINTING ######################

        public static void loadmaze(ref char[,] maze)
        {
            
            string line;
            
            string path = "P:\\OPP Week 1\\Game(C_SHARP)\\Game(C_SHARP)\\maze.txt";
            int row = 0;
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                for (int colom = 0; colom < 130; colom++)
                {
                    maze[row,colom] = line[colom];
                }
                Console.WriteLine();
                row++;
            }
            myFile.Close();
        }
        public static void printingMaze1(ref char[,] maze)
        {
            for (int x = 0; x < 26; x++)
            {
                for (int y = 0; y < 130; y++)
                {

                    if ((x == 0) && (y > -1 && y < 130))

                    {
                        maze[x, y] = '_';
                    }

                    else if ((x == 24) && (y > 2 && y < 127))

                    {
                        maze[x, y] = '_';
                    }

                    else if ((x == 1) && (y > 2 && y < 127))

                    {
                        maze[x, y] = '#';
                    }

                    else if ((x == 25) && (y > -1 && y < 130))

                    {
                        maze[x, y] = '#';
                    }

                     else if ((x == 19) && (y >= 40 && y <= 85))

                     {
                         maze[x,y] = '#';
                     }

                    else if ((y == 0 || y == 129) && (x > 0 && x < 25))

                    {
                        maze[x, y] = '|';
                    }

                    else if ((y == 1 || y == 128) && (x > 0 && x < 25))

                    {
                        maze[x, y] = '@';
                    }

                    else if ((y == 2 || y == 127) && (x > 0 && x < 25))
                    {
                        maze[x, y] = '|';
                    }

                    else
                    {
                        maze[x, y] = ' ';
                    }            
                }             
            }
        }
        public static void storemaze(ref char[,] maze)
        {
            string line;
            string path = "P:\\OPP Week 1\\Game(C_SHARP)\\Game(C_SHARP)\\maze.txt";
            int row = 0;
            StreamWriter myFile = new StreamWriter(path, false);
            {
                for (int x = 0; x < 26; x++)
                {
                    for (int y = 0; y < 130; y++)
                    {
                        myFile.Write(maze[x, y]);
                    }
                    myFile.WriteLine();
                }
            }
            myFile.Close();
        }
        public static void maze12D(ref char[,] maze)
        {

            Console.Clear();
            

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write( maze[x,y]);
                }
                Console.WriteLine();
            }
        }

        //                                           ################## Main PLAYER ########################

        static void player(ref char[,] maze, char[,] ship, data game)
        {
            for (int x = 0; x < ship.GetLength(0); x++)
            {           
                for (int y = 0; y < ship.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game.shipY + y, game.shipX + x);
                    Console.Write(ship[x, y]);
                    maze[game.shipX + x, game.shipY + y] = ship[x, y];
                }
            }
        }
        static void Eraseplayer( ref char[,] maze, char[,] ship, data game)
        {
            for (int x = 0; x < ship.GetLength(0); x++)
            {
               // Console.SetCursorPosition(shipY + x, shipX);
                for (int y = 0; y < ship.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game.shipY + y, game.shipX + x);
                    Console.Write(" ");
                    maze[game.shipX + x, game.shipY + y] = ' ';
                }
            }
        }
        static void moveShipRight( ref char[,] maze, char[,] ship, data game)
        {
            if (maze[game.shipX , game.shipY + 5] == ' ' && maze[game.shipX +1 , game.shipY + 5] == ' ')
            {

                Eraseplayer( ref maze,  ship,game);

                game.shipY = game.shipY + 1;
                player(ref maze, ship, game);



            }
        }
        static void moveShipLeft(ref char[,] maze, char[,] ship, data game)
        {
            if (maze[game.shipX, game.shipY - 1] == ' ' && maze[game.shipX - 1, game.shipY - 1] == ' ')
            {

                Eraseplayer(ref maze, ship, game);

                game.shipY = game.shipY - 1;
                player(ref maze, ship, game);
            }
        }

        //                                           ############### PLAYER Bullets #########################

        static void generateBulletPlayer(ref char[,] maze, data game, List<bulletsP> game2)
        {
            bulletsP d = new bulletsP();
            bulletsP f = new bulletsP();
            d.bulletshipX = game.shipX - 1;
            d.bulletshipY = game.shipY + 2;
            char next = maze[d.bulletshipX, d.bulletshipY];
            if (next == ' ')
            {
                printbullet(ref maze, d.bulletshipX, d.bulletshipY);
                game2.Add(d);
                
            }
        }
        static void printbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("*");
            maze[x, y] = '*';
        }
        static void erasebullet(ref char[,] maze, int x, int y, List<bulletsP> game3)
        {
            bulletsP Bulets = new bulletsP();
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
            game3.Remove(Bulets);
        }
        static void movebullet(ref char[,] maze, List<bulletsP> game3)
        {
            for (int x = 0; x < game3.Count; x++)
            {
                 
                    char next = maze[game3[x].bulletshipX - 1, game3[x].bulletshipY];
                    if (next == ' ')
                    {
                        erasebullet(ref maze, game3[x].bulletshipX, game3[x].bulletshipY, game3);
                        game3[x].bulletshipX--;
                        printbullet(ref maze, game3[x].bulletshipX, game3[x].bulletshipY);
                 

                }
                    else if (next != ' ' )
                    {
                        erasebullet(ref maze, game3[x].bulletshipX, game3[x].bulletshipY, game3);
                        game3.RemoveAt(x);
                    }
                
            }
        }
        static void makebulletinactive( ref int index,   ref int []  bulletshipX,  ref int [] bulletshipY,  ref int bulletCount)
        {
            for (int y = index; y < bulletCount; y++)
            {
                bulletshipX[y] = bulletshipX[y + 1];
                bulletshipY[y] = bulletshipY[y + 1];
            }
            bulletCount--;
        }

        //                                            ################# ENEMY  PLAYER #######################

        static void enemyPlayer(ref char[,] maze, ref char[,] enemy,enemy game2)
        {
            for (int x = 0; x < enemy.GetLength(0); x++)
            {
                
                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game2.enemyY + y, game2.enemyX + x);
                    Console.Write(enemy[x, y]);
                    maze[game2.enemyX + x, game2.enemyY + y] = enemy[x, y];
                }
            }
        }
        static void eraseEnemyCharacter1(ref char[,] maze, ref char[,] enemy, enemy game2)
        {
            for (int x = 0; x < enemy.GetLength(0); x++)
            {
             
                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    Console.SetCursorPosition(game2.enemyY + y, game2.enemyX + x);
                    Console.Write(" ");
                    maze[game2.enemyX + x, game2.enemyY + y] = ' ' ;
                }
            }
        }
        static void moveenemy1(ref char[,] maze, ref char[,] enemy,enemy game2, ref string enemyDirection1)
        {
            if (enemyDirection1 == "down")
            {    
                if (maze[game2.enemyX +3, game2.enemyY ] == ' ')
                {
                    eraseEnemyCharacter1(ref  maze, ref enemy, game2);
                    game2.enemyX++;
                    enemyPlayer(ref maze, ref enemy, game2);
                }
                if (game2.enemyX == 10)
                {
                    enemyDirection1 = "up";
                                   
                }                
            }
            if (enemyDirection1 == "up")
            {
                if ((maze[game2.enemyX - 1, game2.enemyY] == ' '))
                {
                    eraseEnemyCharacter1(ref maze, ref enemy,game2);
                    game2.enemyX--;
                    enemyPlayer(ref maze, ref enemy, game2);
                }
                if (maze[game2.enemyX - 1, game2.enemyY] == '#')
                {
                    enemyDirection1 = "down";
                }
            }
        }
      
        //                                           ############### Enemy Bullets #########################
        
        static void generateEbullet(ref char[,] maze,List<enemyB>W, enemy game2, ref int enemy1Shot)
        {
            enemyB v = new enemyB();           
            if (enemy1Shot % 4 == 0)
            {
                v.bulletenemyX = game2.enemyX + 2;
                v.bulletenemyY = game2.enemyY + 2;
                char next =  maze[v.bulletenemyX, v.bulletenemyY];
                if (next == ' ')
                {
                    printEbullet(ref maze, v.bulletenemyX, v.bulletenemyY);
                    W.Add(v);
                }
            }
            enemy1Shot++;
        }
        static void printEbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("o");
            maze[x, y] = 'o';
        }
        static void eraseEbullet(ref char[,] maze, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            maze[x, y] = ' ';
        }
        static void moveEbullet(ref char[,] maze, List<enemyB> W, enemy game2, data game)
        {
            for (int x = 0; x < W.Count; x++)
            {

                    char next = maze[W[x].bulletenemyX + 1, W[x].bulletenemyY + 1];

                    if (next == ' ')
                    {
                        eraseEbullet(ref maze, W[x].bulletenemyX, W[x].bulletenemyY);
                        W[x].bulletenemyX++;
                        if ( (game2.enemyX != game.shipY))
                        {
                        W[x].bulletenemyY = W[x].bulletenemyY + 2;
                        }
                        printEbullet(ref maze, W[x].bulletenemyX, W[x].bulletenemyY);
                    }
                    else if (next != ' '|| (maze[game2.enemyX +1, game2.enemyY +2] != ' ') || (maze[game2.enemyX + 2, game2.enemyY +2] != ' ') || (maze[game2.enemyX + 3, game2.enemyY + 2] != ' ') || (maze[game2.enemyX + 4, game2.enemyY + 2] != ' ') || (maze[game2.enemyX + 5, game2.enemyY + 2 ] != ' '))
                    {
                    eraseEbullet(ref maze, W[x].bulletenemyX, W[x].bulletenemyY);
                    W.RemoveAt(x);                       
                    }
                
            }
        }
        static void makeEbulletinactive(ref int index, ref int[] bulletenemyX, ref int[] bulletenemyY, ref int bulletECount)
        {
            for (int y = index; y < bulletECount; y++)
            {
                bulletenemyX[y] = bulletenemyX[y + 1];
                bulletenemyY[y] = bulletenemyY[y + 1];
            }
            bulletECount--;
        }
       
      
        //                                          ################# Bullets Collision ####################
        
        static void enemyBulletCollisionWithPlayer(  data game, ref char[,] maze, ref int healthP)
        {
            if (maze[game.shipX + 1, game.shipY] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 2, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 3, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 4, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            if (maze[game.shipX - 5, game.shipY - 3] == 'o')
            {
                healthP = healthP - 10;
            }
            else if (healthP <= 0)
            {
                healthP = 0;
            }
        }
        static void playerBulletCollisionWithE(enemy game2, ref char[,] maze, ref int healthE, ref int score)
        {
            if (maze[game2.enemyX + 3, game2.enemyY ] == '*')
            {
                score++;
                healthE = healthE - 10;
            }

            if (maze[game2.enemyX + 3, game2.enemyY + 1] == '*')
            {
                score++;
                healthE = healthE- 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY +2 ] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 3] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 4] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            if (maze[game2.enemyX + 3, game2.enemyY + 5] == '*')
            {
                score++;
                healthE = healthE - 10;
            }
            else if (healthE <= 0)
            {
                healthE = 0;
            }
        }

        //                                          ################ MOVEMENT OF PlaYer #####################

        static void movePlayer(ref char[,] maze2D, ref char[,]ship,data game, List<bulletsP> Q)
        {

            Thread.Sleep(90);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveShipRight(ref maze2D, ship, game);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveShipLeft(ref maze2D, ship, game);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                generateBulletPlayer(ref maze2D,game,Q);
            }
        }

        //                                          ################ GaMe StaRt ###########################
    
        static void startGame(ref bool enemy1present,ref int enemy1Shot ,ref string enemyDirection1, ref char[,] maze2D, ref char[,] ship, ref char[,] enemy,List<enemyB> W, data game,enemy game2,List<bulletsP>Q, ref int healthP, ref int healthE, ref int score)
        {
            Console.Clear();
            enemy1present = true;
            bool gamerunning = true;

            maze12D(ref maze2D);
           
            
            while(gamerunning)
            {
                
                if (enemy1present == true)
                {
                    
                    enemyPlayer(ref maze2D, ref enemy, game2);
                    generateEbullet(ref maze2D,W, game2, ref enemy1Shot);
                    moveenemy1(ref maze2D, ref enemy, game2, ref enemyDirection1);
                    printScore( healthP,  healthE, score);
                }
                if (healthP == 0 || healthE == 0)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine( "Game Ends");
                    Console.WriteLine ("Score:" + score) ;
                    Thread.Sleep(2000);



                    gamerunning = false;
                }

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    storemaze(ref maze2D);
                    gamerunning = false;
                    break;
                }

                player(ref maze2D, ship, game);
                movePlayer(ref maze2D, ref ship, game,Q);

                movebullet(ref maze2D,Q);
                moveEbullet(ref maze2D,W, game2, game);

                playerBulletCollisionWithE(game2, ref maze2D, ref healthE, ref score);
                enemyBulletCollisionWithPlayer(game, ref maze2D, ref healthP);

                

            }

        }
    }

}

