using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ce103_hw3_library_lib
{
    public class PasswordContent
    {
        public void password()
        {
            int attempt = 3;
            // PasswordContent app = new PasswordContent();



            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine(" ## Enter username: ## ");
                string username = Console.ReadLine();

                Console.WriteLine("## Enter Password ## ");
                string password = Console.ReadLine();


                if (username == "eray" && password == "1234")
                {
                    library lib = new library();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Congratulations, you have successfully logged in.");

                    lib.Start();
                    break;

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    Console.WriteLine("Your username or password is incorrect !");

                    if (attempt > 0)
                    {
                        attempt -= 1;
                    }
                    if (attempt == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Your rights are expired, you can no longer login");
                        break;
                    }

                }
                Console.ReadLine();
            }
        }


    }
}
