using System;
using System.Collections.Generic;


namespace OnlineCollegeAdmission
{
    static class CollegeRepository
    {
        public static Dictionary<string, College> collegeList = new Dictionary<string, College>();
        public static void AddCollege(College college)
        {
            collegeList.Add(college.GetCode(), college);
        }
        public static void DisplayAllCollege()
        {
            foreach (string code in collegeList.Keys)
            {
                Console.WriteLine(collegeList[code].ToString());
            }
        }

        public static string SelectCollege()
        {
            DisplayAllCollege();
            Console.WriteLine("Please Select College :");
            string collegeCode = Console.ReadLine();
            if (DBUtils.CheckCollegeSeats(collegeCode))
            {
                return collegeCode;
            }
            return "-";
        }
    }
}
