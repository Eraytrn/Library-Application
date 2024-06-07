using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace ce103_hw3_library_lib
{
    public class BookFunctions
    {
        //library a = new library();
        library mainmenu = new library();



        public void AddBook()
        {

            //A new directory is created to hold the entered values in the library.dat file and the entered values  are transferred that file
            Clear();
           string path = AppDomain.CurrentDomain.BaseDirectory;
          
           string filename = Path.Combine(path, "library.dat");

            Book book = new Book();
            
            Write("Please enter book id: ");
            book.Id = Convert.ToInt32(ReadLine());
            
            Write("\nPlease enter book title: ");
            book.Title = "Title: " + ReadLine();
            Write("\nPlease enter book description: ");
            book.Description = "Description: " + ReadLine();
            Write("\nPlease enter book year: ");
            book.Year = "Year: " + ReadLine();
            Write("\nPlease enter book pages: ");
            book.Pages = "Pages: " + ReadLine();
            Write("\nPlease enter book abstract: ");
            book.Abstract = "Abstract: " + ReadLine();
            Write("\nPlease enter book city: ");
            book.City = "City: " + ReadLine();
            Write("\nPlease enter book edition: ");
            book.Edition = "Edition: " + ReadLine();
            Write("\nPlease enter book publisher: ");
            book.Publisher = "Publisher: " + ReadLine();
            Write("\nPlease enter book catalogid: ");
            book.CatalogId = "CatalogID: " + ReadLine();
            Write("\nPlease enter book price: ");
            book.Price = "Price: " + ReadLine();
            Write("\nPlease enter book rack: ");
            book.RackNo = "Rack: " + ReadLine();
            Write("\nPlease enter book row: ");
            book.RowNo = "Row: " + ReadLine();
            book.Status = "In library";
            Write("\nPlease enter book enter date: ");
            book.Return = "Firstly added to library at: " + ReadLine() + "date";
            book.Given = "Given: -";
            Write("\nPlease enter book url: ");
            book.Url = "Url: " + ReadLine();
            Write("\nPlease enter book author: ");
            book.Authors.Add("Author :" + ReadLine());
            Write("\nPlease enter book tag: ");
            book.Tags.Add("Editor: " + ReadLine());
            Write("\nPlease enter book editor: ");
            book.Editors.Add("Editor: " + ReadLine());
            
            Write("\nPlease enter book category: ");
            book.Categories.Add("Category: " + ReadLine());       
            

           //Enterd values convert the bytes to store the data
            byte[] bookBytes = Book.BookToByteArrayBlock(book);
             FileUtility.AppendBlock(bookBytes, filename);

            mainmenu.RunMainMenu();
            
        }


        public void EditBook()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");
            Book bookk = new Book();
            Console.Clear();
            int booknumber;
            Console.WriteLine(" Enter number of book to edit: ");
            booknumber = Convert.ToInt32(Console.ReadLine());

            using (StreamReader abc = new StreamReader(File.Open("library.dat", FileMode.Open)))
            {
                
                Console.WriteLine(" Enter book id: ");
                bookk.Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" Enter book title: ");
                bookk.Title = Console.ReadLine();
                Console.WriteLine(" Enter book description: ");
                bookk.Description = Console.ReadLine();
                Console.WriteLine(" Enter book author: ");
                bookk.Authors.Add(Console.ReadLine());
                Console.WriteLine(" Enter book category: ");
                bookk.Categories.Add(Console.ReadLine());

                byte[] bookBytes = Book.BookToByteArrayBlock(bookk);
                FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                WriteLine("Press any key to return...");
                ReadKey(true);
                mainmenu.RunMainMenu();

            }
    
            
        }

        public void ListBook()
        {
            Clear();
            int i = 1;
            WriteLine(" ID Title Description Author Categories  Rack Row");
            using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
            {
                string datlength = sr.ReadLine();
                sr.Close();
                do
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "library.dat");


                    byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);
                    if(bookWrittenObject != null)
                    {

                        WriteLine(i + "." + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | " + bookWrittenObject.Description + " | " + bookWrittenObject.Authors[0] + " | " + bookWrittenObject.Categories[0] + " | " + "\n");
                    }
                    
                    i++;
                } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                WriteLine("Press any key to return...");
                ReadKey(true);
                mainmenu.RunMainMenu();

            }
        }


        public void DeleteBook()
        {
            

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "library.dat");
            Clear();
            int booknumber;
            WriteLine(" Enter number of book to delete: ");
            booknumber = Convert.ToInt32(ReadLine());
            FileUtility.DeleteBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);

            WriteLine("Press any key to return...");
            ReadKey(true);
            mainmenu.RunMainMenu();
        }


        public void BorrowBook()
        {

            if (File.Exists("library.dat"))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string filename = Path.Combine(path, "library.dat");
                Clear();
                int booknumber;
                string student;
                string date;
                Write("Please enter number of book which do you want to borrow: ");
                booknumber = Convert.ToInt32(ReadLine());
                Write("\nWhat is the name of student who got the book: ");
                student = ReadLine();
                Write("\nDate: ");
                date = ReadLine();


                using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                {
                    string datalength = sr.ReadLine();
                    sr.Close();

                    byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);


                    if (bookWrittenObject != null)
                    {
                        Book book = new Book();
                        book = bookWrittenObject;
                        book.Status = "Borrowed by student: " + student;
                        book.Given = "Given date: " + date;
                        byte[] bookBytes = Book.BookToByteArrayBlock(book);

                        FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    }

                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    mainmenu.RunMainMenu();
                }
            }
            else { Clear(); WriteLine("Library file couldn't found."); }
            WriteLine("Press any key to return...");
            ReadKey(true);
            mainmenu.RunMainMenu();

        }


        public void ListBorrowBook()
        {
            Clear();
            if (File.Exists("library.dat"))
            {
                int i = 1;
                using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                {
                    string datlength = sr.ReadLine();
                    sr.Close();
                    do
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory;
                        string filename = Path.Combine(path, "library.dat");


                        byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                        Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                        if (bookWrittenObject != null && bookWrittenObject.Title.Contains("Borrowed"))
                        {
                            WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + "\n");

                        }
                        i++;

                    } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                    WriteLine("Press any key to return...");
                    ReadKey(true);
                    mainmenu.RunMainMenu();
                }
            }
            else { Clear(); WriteLine("Library file couldn't found."); }

            WriteLine("Press any key to return...");
            ReadKey(true);
            mainmenu.RunMainMenu();

        }



        public void SearchBook()
        {


            Clear();
            int i = 1;
            if (File.Exists("library.dat"))
            {
                Write("Please enter name or ID of the book which do you want to find: ");
                var search = ReadLine();
                if (ConversionUtility.IsNumeric(search) == false)
                {
                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        Clear();
                        string datlength = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string filename = Path.Combine(path, "library.dat");


                            byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                            if (bookWrittenObject != null && (bookWrittenObject.Title.Contains(search)))
                            {
                                WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | Description: " + bookWrittenObject.Description + " | Author: " + bookWrittenObject.Authors[0] + " | Category: " + bookWrittenObject.Categories[0] + "\n");
                            }
                            i++;

                        } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                        WriteLine("Press any key to return...");
                        ReadKey(true);
                        mainmenu.RunMainMenu();
                    }

                }
                else
                {
                    int searchint = Convert.ToInt32(search);

                    using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                    {
                        Clear();
                        string datlength = sr.ReadLine();
                        sr.Close();
                        do
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory;
                            string filename = Path.Combine(path, "library.dat");


                            byte[] bookWrittenBytes = FileUtility.ReadBlock(i, Book.BOOK_DATA_BLOCK_SIZE, filename);
                            Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytes);

                            if (bookWrittenObject != null && (bookWrittenObject.Id.Equals(searchint)))
                            {
                                WriteLine(i + ". - " + bookWrittenObject.Id + " | " + bookWrittenObject.Title + " | Description: " + bookWrittenObject.Description + " | Author: " + bookWrittenObject.Authors[0] + " | Category: " + bookWrittenObject.Categories[0] + "\n");
                            }
                            i++;

                        } while (i < (((datlength.Length) / (Book.BOOK_DATA_BLOCK_SIZE)) + 1));
                        WriteLine("Press any key to return...");
                        ReadKey(true);
                        mainmenu.RunMainMenu();
                    }
                }
            }
            else { Clear(); WriteLine("Library file couldn't found."); }

            WriteLine("Press any key to return...");
            ReadKey(true);
            mainmenu.RunMainMenu();
        }

        public void ReturnBook()
        {
            if (File.Exists("library.dat"))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string filename = Path.Combine(path, "library.dat");
                Clear();
                int booknumber;
                string bookname;
                Write("Please enter number of book which do you want to return: ");
                booknumber = Convert.ToInt32(ReadLine());
                Write("\nWhat is book name: ");
                bookname = ReadLine();


                using (StreamReader sr = new StreamReader(File.Open("library.dat", FileMode.Open)))
                {
                    string datalength = sr.ReadLine();
                    sr.Close();

                    byte[] bookWrittenBytesforBorrow = FileUtility.ReadBlock(booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                    Book bookWrittenObject = Book.ByteArrayBlockToBook(bookWrittenBytesforBorrow);



                    Book book = new Book();
                    book.Id = bookWrittenObject.Id;
                    book.Title = bookname;
                    book.Description = bookWrittenObject.Description;
                    book.Authors.Add(bookWrittenObject.Authors[0]);
                    book.Categories.Add(bookWrittenObject.Categories[0]);

                    byte[] bookBytes = Book.BookToByteArrayBlock(book);

                    FileUtility.UpdateBlock(bookBytes, booknumber, Book.BOOK_DATA_BLOCK_SIZE, filename);
                }

                WriteLine("Press any key to return...");
                ReadKey(true);
                mainmenu.RunMainMenu();
            }
            else { Clear(); WriteLine("Library file couldn't found."); }
            WriteLine("Press any key to return...");
            ReadKey(true);
            mainmenu.RunMainMenu();
        }



    }
}
