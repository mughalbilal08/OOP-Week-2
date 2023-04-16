using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BussinessAPP_C_Sharp_.BL;


//role = Signin(names,passwords, name, password, count, count1);

namespace Application_ochoice_
{

    class Program
    {

        static void Main(string[] args)
        {

            // ############################################## ARRAYS ###########################################################

           /* int count1 = 0;
            int bookCount = 0;
            int count = 0;*/
            //  int complainCount = 0;
            // int reviewCount = 0;
            /*string[] reviews = new string[100];
            int[] months = new int[100];
            int[] dates = new int[100];
            string[] fines = new string[100];
            string[] bookBorrow = new string[100];
            bool[] bookWidraw = new bool[100];
            string[] bookList = new string[100];
            string[] names = new string[100];
            string[] passwords = new string[100];
            string[] roles = new string[100];
            string[] bookAuthur = new string[100];
            string[] bookPublish = new string[100];
            string[] userComplaints = new string[100];
            bool[] complaintCheck = new bool[100];
            bool[] reviewCheck = new bool[100];
*/
            // ############################################## VARIABLES ###########################################################

            string option;

            int n = 1;
            int n2 = 1;


            List<data> s = new List<data>();
            List<book> d = new List<book>();
            List<detailB> f = new List<detailB>();
            data a = new data();
            data[] q = new data[1000]; 
            book [] b = new book[10000];
            
            
            loadData(s,d, b);
            loadData1(f);

            // ############################################## MAIN FUNCTION ###########################################################

            while (n == 1)
            {
                string role = "";
                Console.Clear();
                header();
                n2 = 1;
                option = menu();

                if (option == "1")
                {
                    data objIN = new data();
                    for (int x = 0; x < 6; x++)
                    {
                        Console.Clear();
                        header();                        
                        Console.WriteLine(" ---------------------------------------------------------");
                        Console.WriteLine(" | Note: If Your're Admin Enter Only Predefined Admin ID |");
                        Console.WriteLine(" ---------------------------------------------------------");
                        Console.WriteLine("");


                        Console.WriteLine(" Enter your Name: ");
                        objIN.names = Console.ReadLine();

                        Console.WriteLine(" Enter your Password (Password Must be 8 Character ");
                        objIN.passwords = Console.ReadLine();

                        role = signin(s, objIN.names, objIN.passwords);
                        Console.WriteLine(role);
                        Console.Read();

                        if (role == "Invalid")
                        {
                            Console.WriteLine(" User is not Present: ");
                            Console.WriteLine(" Please enter valid data");

                            continue;
                        }
                        if (role == "admin" || role == "student")
                        {
                            break;
                        }

                        if (x >= 5)
                        {
                            n2 = 0;
                            break;
                        }

                    }

                    if (n2 == 0)
                    {
                        Console.WriteLine(" You Have Entered Data Wrong data 5-times, We are going to sign-in page again ");
                        continue;
                    }

                    while (true)
                    {

                        if (role == "admin")
                        {
                            Console.Clear();
                            adminMenu(f, s,q);
                            break;
                        }

                        else if (role == "student")
                        {
                            Console.Clear();
                            Console.Write("Welcome TO Student");
                            Console.ReadKey();
                            break;
                        }
                    }

                }

                else if (option == "2")
                {
                   
                    Console.Clear();
                    header();
                    data objinput = new data();
                    Console.Write(" Enter your Name: ");
                    objinput.names   = Console.ReadLine();
                    Console.Write(" Enter the password (Must Be 8 Characters)");
                    objinput.passwords = Console.ReadLine();

                    bool isCheck = Signup(s, objinput.names, objinput.passwords);
                    if (isCheck == true)
                    {
                        Console.WriteLine("Already Exit");
                        Console.ReadKey();
                    }
                    if (isCheck == false)
                    {

                        Console.Clear();
                        header();
                        Console.Write(" THE ID HAS BEEN CREATED Successfully !! ");
                        Console.ReadKey();
                    }

 /*                   bool isName = name_check(Uname);
                    if (isName == true)
                    {


                        bool valid = password_check(Upassword);
                        if (valid == true)
                        {

                        }
                        else if (valid == false)
                        {
                            Console.Clear();
                            header();
                            Console.Write(" Please Enter a strong password . ");
                        }
                    }
                    else if (isName == false)
                    {
                        Console.Clear();
                        header();
                        Console.Write(" Please Enter a Name without integers");
                    }
 */             }
                else if (option == "3")
                {
                    saveData(s);
                    saveData1(f);
                    n = 0;
                }

            }


        }

        // ############################# MAIN MENU ###############################################

        static string menu()
        {
            string choice;
            Console.WriteLine(" Press 1 to Sign IN: ");
            Console.WriteLine(" Press 2 to Sign UP: ");
            Console.WriteLine(" Press 3 to Exit: ");
            Console.WriteLine(" Press (1 - 3) to Enter: ");
            choice = Console.ReadLine();
            return choice;
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue..."); ;
            Console.ReadKey();
            Console.Clear();
        }

        public static void header()
        {

            Console.WriteLine(""); ;
            Console.WriteLine("              #######################################################################################################################################################################");
            Console.WriteLine("              #                                                                                                                                                                     #");
            Console.WriteLine("              #  $     $  $$$$$$   $$$$$  $$$$$  $$$$$  $    $    $$$$$$$ $$$$$$ $$$$$ $$$$$$ $$$$$$  $$$$$ $$$$$$$ $$$$$ $$$$$ $$$$$    $$$$$$ $    $ $$$$$$ $$$$$ $$$$$  $$$$$$$  #");
            Console.WriteLine("              #  $     $  $     $   $   $  $   $ $    $ $    $    $  $  $ $    $ $   $ $    $ $    $  $     $  $  $ $     $   $   $      $      $    $ $        $   $      $  $  $  #");
            Console.WriteLine("              #  $$    $$ $$$$$$$$ $$$$$$ $$$$$$ $$$$$$ $$$$$$    $$ $  $ $$$$$$ $$  $ $$$$$$ $$      $$$$$ $$ $  $ $$$$$ $$  $   $$     $$$$$$ $$$$$$ $$$$$$   $$  $$$$$  $$ $  $  #");
            Console.WriteLine("              #  $$    $$ $$     $ $$   $ $$   $ $$   $   $$      $$ $  $ $$   $ $$  $ $$   $ $$ $$$$ $$    $$ $  $ $$    $$  $   $$         $$   $$       $$   $$  $$     $$ $  $  #");
            Console.WriteLine("              #  $$$$$ $$ $$$$$$$$ $$   $ $$   $ $$   $   $$      $$ $  $ $$   $ $$  $ $$   $ $$$$$ $ $$$$$ $$ $  $ $$$$$ $$  $   $$     $$$$$$   $$   $$$$$$   $$  $$$$$  $$ $  $  #");
            Console.WriteLine("              #                                                                                                                                                                     #");
            Console.WriteLine("              #######################################################################################################################################################################");
            Console.WriteLine(""); ;
            Console.WriteLine(""); ;
            Console.WriteLine("                                        <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("                                        <><><>---<>---<>---<>---<>---<>---<>---< LIBRARY MANAGEMENT SYSTEM >---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("                                        <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine(""); ;
        }

        public static void clear()
        {
            Console.WriteLine();
            Console.Write(" Press any Key to Continue ....... ");
            Console.ReadKey();
            Console.Clear();
        }


        // ############################# Sign In ###############################################

        public static string signin(List<data> s, string userName, string userPassword)
        {

            for (int index = 0; index < s.Count; index++)
            {
                if (userName == s[index].names && userPassword == s[index].passwords)
                {
                    if (index == 0)
                    {                      
                        return "admin";
                    }
                    else
                    {                     
                        return "student";
                    }

                }
            }

            return "isAbsent";

        }


        // ############################# Sign UP ###############################################

        public static bool Signup(List<data>s ,string name, string password)
        {
            bool isCheck = false;

            for (int index = 0; index < s.Count; index++)
            {
                if (s[index].names == name && s[index].passwords == password)
                {
                    isCheck = true;
                    break;
                }


            }

            if (isCheck == false)
            {
                
                data d = new data();
                d.names = name;
                d.passwords = password;
                if(name == s[0].names && password == s[0].passwords)
                {
                    d.roles = "Admin";
                    s.Add(d);
                }

                else 
                {
                    d.roles = "student";
                    s.Add(d);
                }
                
}


            return isCheck;
        }

        // ############################# Validations ###############################################

        public static bool name_check(string name)
        {
            bool flag = false;
            int i = 0;
            while (i < name.Length)
            {
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123))
                {
                    i++;
                    if (i >= 5)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public static bool password_check(string password)
        {
            bool flag = false;
            int i = 0;
            while (i < password.Length)
            {
                if ((password[i] > 63 && password[i] < 91) || (password[i] > 96 && password[i] < 123) || (password[i] > 47 && password[i] < 58) || (password[i] > 34 && password[i] < 39))
                {
                    i++;
                    if (i >= 8)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        //############################################ myFile HANDING ##########################################################

        static string getfield(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void loadData( List<data>s, List<book> f, book[] d)
        {
             int index = 0;
            string line, names, passwords, role;
            string widraw, complain, check;
            string path = "P:\\OPP Week 1\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\userData.txt";
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                data objdata = new data();
                book objdt = new book();
                objdata.names = getfield(line, 1);            
                objdata.roles = getfield(line, 2);
                objdata.passwords = getfield(line, 3);
                objdt.dates = int.Parse(getfield(line, 4));
                objdt.months = int.Parse(getfield(line, 5));
                objdt.userComplaints = getfield(line, 6);
                objdt.bookBorrow = getfield(line, 7);
                objdt.reviews = getfield(line, 8);
                widraw = getfield(line, 9);
                complain = getfield(line, 10);
                check = getfield(line, 11 );
                helper(d, widraw, complain, check);
                index++;
                s.Add(objdata);
                f.Add(objdt);
            }

            myFile.Close();
        }
        public static void helper(book [] s, string widraw, string complain, string check)
        {
            book objdt = new book();
            if (widraw == "1")
            {
                objdt.bookWidraw = true;
            }
            if (widraw == "0")
            {
                objdt.bookWidraw = false;
            }
            if (complain == "1")
            {
                objdt.complaintCheck = true;
            }
            if (complain == "0")
            {
                objdt.complaintCheck = false;
            }
            if (check == "1")
            {
                objdt.reviewCheck = true;
            }
            if (check == "0")
            {
                objdt.reviewCheck = false;
            }
        }
        public static void saveData(List<data> s)
        {
            string path = "P:\\OPP Week 1\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\userData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 0; x < s.Count; x++)
            { 
                
                    myFile.Write(s[x].names + ",");
                    myFile.Write(s[x].roles + ",");
                    myFile.Write(s[x].passwords + ",");
                    myFile.Write(s[x].dates + ",");
                    myFile.Write(s[x].months + ",");
                    myFile.Write(s[x].userComplaints + ",");
                    myFile.Write(s[x].bookBorrow + ",");
                    myFile.Write(s[x].reviews + ",");
                    myFile.Write(s[x].bookWidraw + ",");
                    myFile.Write(s[x].complaintCheck + ",");
                    myFile.WriteLine(s[x].reviewCheck);
            }
            myFile.Flush();
            myFile.Close();
        }
       
        public static void loadData1(List<detailB> g)
        {
            int index = 0;
            string line;
            string path = "P:\\OPP Week 1\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\bookData.txt";
            StreamReader myFile = new StreamReader(path);
            while ((line = myFile.ReadLine()) != null)
            {
                detailB objdata = new detailB();
                objdata.bookList = getfield(line, 1);
                objdata.bookPublish = getfield(line, 2);
                objdata.bookAuthur = getfield(line, 3);
                index++;
            }
             //bookCount = index;
            myFile.Close();

        }
        public static void saveData1(List<detailB> g)
        {
            string path = "P:\\OPP Week 1\\BussinessAPP(C-Sharp)\\BussinessAPP(C-Sharp)\\bookData.txt";
            StreamWriter myFile = new StreamWriter(path, false);
            for (int x = 0; x < g.Count; x++)
            {
                myFile.Write(g[x].bookList + ",");
                myFile.Write(g[x].bookPublish + ",");
                myFile.WriteLine(g[x].bookAuthur);               
            }
            myFile.Close();
        }
        public static string getField2(string record, int number)
        {
            int commaCount = 1;
            string items = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == '-')
                {
                    commaCount++;
                }
                else if (commaCount == number)
                {
                    items = items + record[x];
                }
            }
            return items;
        }

        //############################################ Admin Functionalities ##########################################################

        public static void adminMenu( List<detailB>grand, List<data> dat, data []z)
        {

            string choice;
            bool logout = false;
            while (true)
            {

                Console.Clear();
                header();
                Console.WriteLine();
                Console.WriteLine(" -------------------------------------");
                Console.WriteLine(" |  Welcome To Admin Functionalities |  ");
                Console.WriteLine(" -------------------------------------");
                Console.WriteLine();
                Console.WriteLine(" Press Any Of Following to Enter:");
                Console.WriteLine(" 1. Modify/ Add Books: ");
                Console.WriteLine(" 2. Search Books: ");
                Console.WriteLine(" 3. View Book List (Details): ");
                Console.WriteLine(" 4. Remove Books: ");
                Console.WriteLine(" 5. View List of Registered Students : ");
                Console.WriteLine(" 6. View List Of Students who Lend The Books: ");
                Console.WriteLine(" 7. Remove User: ");
                Console.WriteLine(" 8. Change Admin Username And Password: ");
                Console.WriteLine(" 9. Check Complaints of Students: ");
                Console.WriteLine(" 10. Check Reviews of Students: ");
                Console.WriteLine(" 11. Return to Main Menu: ");
                Console.WriteLine(" 12. Exit Program: ");
                Console.WriteLine(" Enter Your Choice (1-12): ");

                choice = Console.ReadLine();



                if (choice == "1")
                {
                    Console.Clear();
                    header();
                    int size;
                    Console.Write(" Enter no. of Books You Want to ENTER: ");
                    size = int.Parse(Console.ReadLine());

                    string isCheck = addbooks(grand, ref size);

                    if (isCheck == "true")
                    {
                        Console.Write(" Book Has Been Added:");
                    }

                    else
                    {
                        Console.Write(" No Book Is Available. ");
                        Console.Write(" It Will be Available Soon !! ");
                    }

                    Console.Read();

                }

                else if (choice == "2")
                {
                    Console.Clear();
                    header();
                    string search;
                    Console.Write(" Enter Book Name You Want To Search: ");
                    search = Console.ReadLine();

                    bool isCheck = searchBooks(grand, search);

                    if (isCheck == true)
                    {
                        Console.Write(" Book Is Available: ");
                    }

                    if (isCheck == false)
                    {
                        Console.Write(" Book Is Not Available: ");
                    }

                    clear();
                }

                else if (choice == "3")
                {
                    Console.Clear();
                    header();
                    if (grand.Count != 0)
                    {
                        Console.Clear();
                        header();
                        Console.Write(" Book Details Are ");
                        Console.Write(" .............................");
                        Console.WriteLine();
                        viewDetails(grand);
                    }

                    else
                    {
                        Console.Write(" No Data Has Been Found ");
                    }

                    clear();
                }

                else if (choice == "4")
                {

                    Console.Clear();
                    header();
                    string remove, auth;

                    Console.Write(" Enter Book Name You Want to Remove: ");
                    remove = Console.ReadLine();
                    Console.Write(" Enter Author Name You Want to Remove: ");
                    auth = Console.ReadLine();

                    checkRbooks(grand, ref remove, ref auth);

                    clear();
                }

                else if (choice == "5")
                {

                    Console.Clear();
                    header();
                    bool reg = registeredStudents(dat);
                    if (reg == false)
                    {
                        Console.Write(" No student has been Found. ");
                    }

                    clear();
                }

                else if (choice == "6")
                {
                    Console.Clear();
                    header();
                    borrowlist(dat,z,grand);

                }

                else if (choice == "7")
                {

                    Console.Clear();
                    header();

                    string removeName, userPassword;

                    Console.Write(" Enter username You Want to Remove: ");
                    removeName = Console.ReadLine();

                    Console.Write(" Enter password of Username You Want to Remove: ");
                    userPassword = Console.ReadLine();


                    bool rem = removeUser(dat, ref removeName, ref userPassword);

                    if (rem == true)
                    {
                        Console.Write(" User Has Been Removed ");
                      
                    }

                    else
                    {
                        Console.Write(" No user Found ");
                    }

                    clear();

                }

                else if (choice == "8")
                {

                    Console.Clear();
                    header();
                    string name, password;
                    Console.Write(" Enter Your Current Admin Name: ");
                    name = Console.ReadLine();

                    Console.Write(" ENter Your Current Admin Password: ");
                    password = Console.ReadLine();



                    Console.Clear();
                    header();


                    string check = changedetails(dat, ref name, ref password);

                    if (check == "true")
                    {
                        Console.Clear();
                        header();

                        Console.Write(" ID Has Been Updated !  ");
                        saveData(dat);
                    }

                    if (check == "false")
                    {
                        Console.Write("Irrelevent Credentials");
                    }
                    clear();

                }

                else if (choice == "9")
                {
                    Console.Clear();
                    header();

                    checkComplaint(dat,z);
                    clear();

                }

                else if (choice == "10")
                {
                    Console.Clear();
                    header();

                    checkReview(dat,z);
                    clear();

                }

                else if (choice == "11")
                {
                    logout = true;

                }

                else if (choice == "12")
                {
                    Console.Clear();
                    Console.Write("Programs End ");
                    while (true)
                    {
                        Console.ReadKey();
                    }
                }
                if (logout == true)
                {
                    break;
                }

            }
        }

        public static string addbooks( List<detailB>g, ref int size)
        {
            string isAdd = "false";
            for (int index = g.Count; index <  size; index++)
            {
                detailB v = new detailB();
                
                Console.Write(" Enter Book Name: ");
                v.bookList = Console.ReadLine();
                
                Console.Write(" Enter Authuor Name: ");
                v.bookAuthur = Console.ReadLine();
                
                Console.Write(" Enter Publish Year: ");
                v.bookPublish = Console.ReadLine();
                g.Add(v);
                isAdd = "true";
            }
   
            saveData1(g);
            return isAdd;
            clear();
        }

        public static bool searchBooks(List<detailB> g, string search)
        {

            bool isCheck = false;
            for (int index = 0; index < g.Count; index++)
            {
                if (search == g[index].bookList)
                {
                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }

        public static void viewDetails(List<detailB>g)
        {
            for (int i = 0; i < g.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine(" Book Name " + i + 1 + " is: " + g[i].bookList);
                Console.WriteLine(" Author of book " + i + 1 + " is: " + g[i].bookAuthur);
                Console.WriteLine(" Publish Date of Book " + i + 1 + " is: " + g[i].bookPublish);
                Console.WriteLine();
            }
        }

        public static void checkRbooks(List<detailB>d, ref string remove, ref string auhtor)
        {

            for (int index = 0; index < d.Count; index++)
            {
                if (remove == d[index].bookList && auhtor == d[index].bookAuthur)
                {
                   
                    d.RemoveAt(index);
                    Console.Write(" Book Has Been Removed.");
                    break;
                }
                else 
                {
                    Console.Write("Irrelevent Details");                    
                }
            }
             
                            
        }

        public static bool registeredStudents(List<data>d)
        {

            bool isCheck = false;
            for (int i = 1; i < d.Count; i++)
            {

                if (d[i].names != " " && d[i].passwords != " ")
                {
                    isCheck = true;
                    Console.WriteLine(" Name of Student " + i+ ": " + d[i].names);
                    Console.WriteLine(" Password of Student "+i  + ": " + d[i].passwords);
                    Console.WriteLine();
                }
            }
            return isCheck;
        }

        public static void borrowlist(List<data> d, data[]a, List<detailB> s)

        {

            //string bname = getField2(a[d.Count].bookBorrow, 1);
            for (int x = 1; x < d.Count; x++)
            {
                data m = new data();
                
                if (m.bookWidraw == true)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Names OF Students Who Borrow The Books Are: " + d[x].names);
                    Console.WriteLine(" Book name Is: " + s[x].bookList);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(" Names OF Student is: " + d[x].names);
                    Console.WriteLine(" Status: No book Has been Borrowed ");
                }
            }

            clear();
        }

        public static bool removeUser(List<data>a, ref string name, ref string password)
        {

            bool isCheck = false;
            for (int index = 1; index < a.Count; index++)
            {
                if (name == a[index].names && password == a[index].passwords)
                {
                   
                    a.RemoveAt(index);
                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }

         public static string changedetails(List<data> a, ref string name, ref string password)
        {

            string isCheck = "false";
            if (name == a[0].names && password == a[0].passwords)
            {

                Console.Write(" Enter New Admin Name: ");
                a[0].names = Console.ReadLine();

                Console.Write(" Enter New Admin Password: ");
                a[0].passwords = Console.ReadLine(); ;



                Console.WriteLine(" Your Id Has Been Updated :");
                isCheck = "true";
            }
            return isCheck;
        }

        public static void checkComplaint(List<data> a, data[]s)
        {

            for (int x = 1; x < a.Count; x++)
            {
                data d = new data();
                if(d.complaintCheck == true)
                {
                    Console.WriteLine(" Name of Student is: " + a[x].names);
                    Console.WriteLine(" Complaint is: " + a[x].userComplaints);
                }
                else if (d.complaintCheck == false)
                {
                    Console.WriteLine(" Name of Student is: " + a[x].names);
                    Console.WriteLine(" Complaint Status :  NO complaint has been submitted. ");
                }
                Console.WriteLine();
            }
        }

        public static void checkReview(List<data> a, data[] s)
        {
            for (int x = 1; x < a.Count; x++)
            {

                data d = new data();

                if (d.reviewCheck == true)
                {
                    Console.WriteLine(" Name of Student is: " + a[x].names);
                    Console.WriteLine(" Review : " + a[x].reviews);
                }
                else if (d.reviewCheck == false)
                {
                    Console.WriteLine(" Name of Student is: " + a[x].names);
                    Console.WriteLine(" Review Status :  NO review has been added. ");
                }
                Console.WriteLine();
            }
        }

    }
}
