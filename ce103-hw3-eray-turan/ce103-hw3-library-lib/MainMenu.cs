using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace ce103_hw3_library_lib
{
    public class Menu
    {

        // Used to swtich between options the menu
        private int SelectedIndex;
        // Used to take an input from the user to show that which options user will select
        private string Prompt;
        // Used declare the options
        private string[] Options;




        public Menu(string prompt, string[] options)
        {
            // Variables which in up , here they transferred their parametres
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            // we can switch between letter of the words as used to options length method
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

            // if we on the selectedindex , that options becomes yellow 
                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.Yellow;
                }
                // if we are not on the selectedindex that options becomes black
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.Yellow;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");

            }
            ResetColor();
        }


        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                //Every time I press enter, it clears the menu and open the others part.
                Clear();

                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //Uptade selected index based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }

                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }

                }
                //it comes back with esc 
                if (keyPressed == ConsoleKey.Escape)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    library menu = new library();
                    menu.Start();


                }

            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }


    public class library
    {
        public void Start()
        {
            Title = "Library App";
            RunMainMenu();


        }



        public void RunMainMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;



            string prompt = @"
            
           
           
                ████████████████████████████████████████████████████████████████████████████████████████
                ██                                                                                    ██
                ██  ██      ██ ██████  ██████   █████  ██████  ██    ██      █████  ██████  ██████    ██
                ██  ██      ██ ██   ██ ██   ██ ██   ██ ██   ██  ██  ██      ██   ██ ██   ██ ██   ██   ██
                ██  ██      ██ ██████  ██████  ███████ ██████    ████       ███████ ██████  ██████    ██
                ██  ██      ██ ██   ██ ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██        ██
                ██  ███████ ██ ██████  ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██        ██
                ██                                                                                    ██
                ████████████████████████████████████████████████████████████████████████████████████████     
                                                                                
                                                                                
   
                                                                                                                                                                               
 
(Use the arrow keys to cycle through options and press enter to select an option.)";

           // Options are defined with options method
            string[] options = { " Book Option", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();


            switch (selectedIndex)
            {
                case 0:
                    BookOption();
                    break;

                case 1:
                    DisplayAboutInfo();
                    break;

                case 2:
                    ExitApp();
                    break;
            }




        }


        public void BookOption()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            string prompt = @"



                ████████████████████████████████████████████████████████████████████████████████████████
                ██                                                                                    ██
                ██  ██      ██ ██████  ██████   █████  ██████  ██    ██      █████  ██████  ██████    ██
                ██  ██      ██ ██   ██ ██   ██ ██   ██ ██   ██  ██  ██      ██   ██ ██   ██ ██   ██   ██
                ██  ██      ██ ██████  ██████  ███████ ██████    ████       ███████ ██████  ██████    ██
                ██  ██      ██ ██   ██ ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██        ██
                ██  ███████ ██ ██████  ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██        ██
                ██                                                                                    ██
                ████████████████████████████████████████████████████████████████████████████████████████
                                                                                                

            

            
(Use the arrow keys to cycle through options and press enter to select an option.)";


            string[] options = { " Add Book ", " List Book ", " Delete Book ", " Edit Book ", " Borrow Book ", " List Borrow Book ", "Search Book ", "Return Book"," Back " };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            // We declared variables to using this switch case with link the BookFunctions.cs
            BookFunctions a = new BookFunctions();

            switch (selectedIndex)
            {
                case 0:
                    a.AddBook();
                    break;

                case 1:
                    a.ListBook();
                    break;

                case 2:
                    a.DeleteBook();
                    break;

                case 3:
                    a.EditBook();
                    break;
                case 4:
                    a.BorrowBook();
                    break;

                case 5:
                    a.ListBorrowBook();
                    break;

                case 6:
                    a.SearchBook();
                    break;

                case 7:
                    a.ReturnBook();
                    break;

                case 8:
                    Back();
                    break;
            }
            RunMainMenu();

        }


        public void Back()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            // Clear();
            // ReadKey(true);
            RunMainMenu();

        }


        void DisplayAboutInfo()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Write(@"
            
           
         
                ████████████████████████████████████████████████████████████████████████████████████████
                ██                                                                                    ██
                ██  ██      ██ ██████  ██████   █████  ██████  ██    ██      █████  ██████  ██████    ██
                ██  ██      ██ ██   ██ ██   ██ ██   ██ ██   ██  ██  ██      ██   ██ ██   ██ ██   ██   ██
                ██  ██      ██ ██████  ██████  ███████ ██████    ████       ███████ ██████  ██████    ██
                ██  ██      ██ ██   ██ ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██        ██
                ██  ███████ ██ ██████  ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██        ██
                ██                                                                                    ██
                ████████████████████████████████████████████████████████████████████████████████████████
                                                                                    
                                                                                
                                                                                
   
                                                                                                                                                                               
 
(Use the arrow keys to cycle through options and press enter to select an option.)");


            Clear();
            WriteLine("This library app was created by Eray TURAN.");
            WriteLine("It uses assets from https://patorjk.com/software/taag/#p=testall&h=0&v=0&f=Big&t=LIBRARY%20APP ");
            WriteLine("Press any key to return to the menu.");
            ReadKey(true);
            RunMainMenu();
        }


        public void ExitApp()
        {

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;

            Write(@"
            
           
       
██      ██ ██████  ██████   █████  ██████  ██    ██      █████  ██████  ██████  
██      ██ ██   ██ ██   ██ ██   ██ ██   ██  ██  ██      ██   ██ ██   ██ ██   ██ 
██      ██ ██████  ██████  ███████ ██████    ████       ███████ ██████  ██████  
██      ██ ██   ██ ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██      
███████ ██ ██████  ██   ██ ██   ██ ██   ██    ██        ██   ██ ██      ██      
                                                                                
                                                                                
    
                                                                                                                                                                               
(Use the arrow keys to cycle through options and press enter to select an option.)");



            //WriteLine("\nPress any key to exit..");
            //ReadKey(true);
            Environment.Exit(0);
        }


    }
}
