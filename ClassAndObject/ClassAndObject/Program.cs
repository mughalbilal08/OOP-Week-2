using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using  ClassAndObject.BL;

namespace ClassAndObject
{
    class Program
    {

        static void Main(string[] args)

        {
            // t1();
            // t2();
            // t3();
            // t4();
            // t5();
            t6();
        }
        static void t1()
        {
            Student s1 = new Student();
            s1.name = "ALi";
            s1.roll_no = 5;
            s1.cgpa = 2.1F;
            Console.Write("Name is: " + s1.name + " Roll No Is: " + s1.roll_no + " GPA Is: " + s1.cgpa);
            Console.Read();

        }

        static void t2()
        {
            //Student s1 = new Student();
            Student[] total = new Student[5];
            total[0] = new Student();
            total[1] = new Student();
            total[0].name = "Ali";
            total[0].roll_no = 22;
            total[0].cgpa = 2.2F;
            total[1].name = "bilal";
            total[1].roll_no = 19;
            total[1].cgpa = 3.2F;

            for (int x = 0; x < 2; x++)
            {
                Console.WriteLine("Name is: " + total[x].name + " Roll No Is: " + total[x].roll_no + " GPA Is: " + total[x].cgpa);
            }

            Console.Read();
        }

        static void t3()
        {
            Student s1 = new Student();
            Console.WriteLine("Enter Name : ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll Number : ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter GPA : ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name Is: " + s1.name + " Roll No Is: " + s1.roll_no + " CGPA Is: " + s1.cgpa);
            Console.ReadLine();
        }

        //                              #################### STUDENTS TASK #########################
        static void t4()
        {
            students[] s = new students[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewstudent(s, count);
                }
                else if (option == '3')
                {
                    topstudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            } while (option != '4');
            Console.WriteLine("Press any key to Exit....");
            Console.Read();
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 For Adding A new Student");
            Console.WriteLine("Press 2 For View Student");
            Console.WriteLine("Press 3 For Three top Student");
            Console.WriteLine("Press 4 to Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.WriteLine();
            Console.Write(" Enter Name ");
            s1.name = Console.ReadLine();
            Console.Write(" Enter Roll Number ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write(" Enter CGPA");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.Write(" Enter Department");
            s1.department = Console.ReadLine();
            Console.Write(" Is HostelLide (y || n): ");
            s1.isHostleLide = char.Parse(Console.ReadLine());
            return s1;
        }
        static void viewstudent(students[] s, int count)
        {
            Console.Clear();
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Name: " + s[x].name + " Roll no: " + s[x].roll_no + " CGPA: " + s[x].cgpa + " Department: " + s[x].department + " Hostelide: " + s[x].isHostleLide);
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        static void topstudent(students[] s, int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if (count == 1)
            {
                viewstudent(s, 1);
            }
            else if (count == 2)
            {
                for (int x = 0; x < count; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewstudent(s, 2);
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewstudent(s, 3);
            }
        }
        static int largest(students[] s, int start, int count)
        {
            int index = start;
            float large = s[start].cgpa;
            for (int x = start; x < count; x++)
            {
                if (large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }

        //                           ########################## PRODUCTS TASK #########################

        static void t5()
        {
            product[] total = new product[10];
            char option;
            int count = 0;
            do
            {
                option = menuT();
                if (option == '1')
                {
                    total[count] = addProducts();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewProduct(total, count);
                }
                else if (option == '3')
                {
                    sumPrices(total, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            } while (option != '4');
            Console.WriteLine("Press any key to Exit....");
            Console.Read();
        }
        static char menuT()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 For Adding A Product");
            Console.WriteLine("Press 2 For Showing Products");
            Console.WriteLine("Press 3 For Total Show Worth");
            Console.WriteLine("Press 4 to Exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static product addProducts()
        {
            Console.Clear();
            product s1 = new product();
            Console.WriteLine();
            Console.Write(" Enter Name ");
            s1.name = Console.ReadLine();
            Console.Write(" Enter ID ");
            s1.id = int.Parse(Console.ReadLine());
            Console.Write(" Enter Prices ");
            s1.price = float.Parse(Console.ReadLine());
            Console.Write(" Enter Categories ");
            s1.categories = char.Parse(Console.ReadLine());
            Console.Write(" Enter Brand ");
            s1.brand = Console.ReadLine();
            Console.Write(" Country ");
            s1.country = Console.ReadLine();
            return s1;
        }
        static void viewProduct(product[] s, int count)
        {
            Console.Clear();
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Name: " + s[x].name + " ID: " + s[x].id + " Prices " + s[x].price + " Categories: " + s[x].categories + " Country " + s[x].country);
            }
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        static void sumPrices(product[] s, int count)
        {
            float sum = 0;
            for (int x = 0; x < count; x++)
            {
                sum = sum + s[x].price;
            }
            Console.Write(" Sum Is " + sum);
            Console.Read();
        }

        //                           ########################## SIGN IN TASK #########################


        static void t6()
        {
            Sign[] s1 = new Sign[5];
            s1[0]  = new Sign();
            s1[1] = new Sign();
            s1[2] = new Sign();
            s1[3] = new Sign();
            s1[4] = new Sign();
            


            string path = "P:\\ClassAndObject\\ClassAndObject\\record.txt";
            string n, p;
            string option;
            int count = 0;
            do
            {
                readdata(path, s1);
                Console.Clear();
                option = menu5();
                Console.Clear();
                if (option == "1")
                {
                    Console.WriteLine(" Enter name: ");
                    n = Console.ReadLine();
                    Console.WriteLine(" Enter password: ");
                    p = Console.ReadLine();
                    signin(n, p, s1);
                }
                else if (option == "2")
                {
                    s1[count] =  signup();
                    count++;
                    Store(ref path, s1, ref count);
                }
            }
            while (option != "3");
            Console.Read();
        }
        static string parseData(string record, int field)
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

        static void readdata(string path, Sign[] s)
        {
            int x = 0;
            
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    s[x].userName = parseData(record, 1);
                    s[x].Password = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                filevariable.Close();
            }
            else
            {
                Console.WriteLine(" Not Exists");
            }
        }

        static void signin(string n, string p, Sign[] s)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == s[x].userName && p == s[x].Password)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }

        static void Store( ref string path, Sign[]s, ref int count )
        {
            StreamWriter file = new StreamWriter(path, false);
            for (int x=0; x< count; x++)
            {
                file.WriteLine(s[x].userName + "," + s[x].Password);
            }
           
            file.Flush();
            file.Close();
        }
        static string menu5()
        {
            string option;
            Console.WriteLine(" 1 Sign In ");
            Console.WriteLine(" 2 Sign Up ");
            Console.WriteLine(" Enter Option: ");
            option = Console.ReadLine();
            return option;
        }
        static Sign signup()
        {
            Sign s = new Sign(); 
            Console.WriteLine(" Enter new names: ");
            s.userName = Console.ReadLine();
            Console.WriteLine("Enter New password: ");
            s.Password = Console.ReadLine();
            return s;
        }
    }
}
