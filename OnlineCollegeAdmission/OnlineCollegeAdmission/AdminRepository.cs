using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCollegeAdmission
{
    class AdminRepository
    {
        public static Dictionary<string, Admin> adminList = new Dictionary<string, Admin>();

        public static bool ValidateAdmin(string userId, string password)
        {
            if (adminList.ContainsKey(userId))
            {
                if (adminList[userId].password == password)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect Password...");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect userID......");
                return false;
            }
        }
        public static void Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nEnter your Id :");
                    string userId = Console.ReadLine();
                    Console.WriteLine("Enter Your password :");
                    string password = Console.ReadLine();
                    if (AdminRepository.ValidateAdmin(userId, password))
                    {
                        Console.WriteLine("Login Sucessfully");
                        DisplayAdminPage(adminList[userId]);
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("please enter valid data..." + e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        public enum AdminOption
        {
            View_Students = 1,
            View_colleges,
            Add_College,
            LogOut
        }
        public static void DisplayAdminPage(Admin admin)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your option");

                    foreach (int item in Enum.GetValues(typeof(AdminOption)))
                    {
                        Console.WriteLine("\npress {0} -->  {1}", item, (AdminOption)item);
                    }

                    string select = Console.ReadLine();
                    AdminOption option = (AdminOption)Enum.Parse(typeof(AdminOption), select);

                    switch (option)
                    {
                        case AdminOption.View_Students:
                            UserRepository.DisplayAllStudents();
                            break;
                        case AdminOption.View_colleges:
                            CollegeRepository.DisplayAllCollege();
                            break;
                        case AdminOption.Add_College:
                            College college = new College();
                            CollegeRepository.AddCollege(college);
                            break;
                        case AdminOption.LogOut:
                            Console.WriteLine("Thank you....");
                            break;
                        default:
                            Console.WriteLine("please enter valid data");
                            break;
                    }

                    if (option == AdminOption.LogOut)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter valid data.......");
                }

            }
        }
    }
}
