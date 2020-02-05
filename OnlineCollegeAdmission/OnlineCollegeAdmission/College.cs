using System;

namespace OnlineCollegeAdmission
{
    internal class College
    {
        internal string collegeCode { get; set; }
        internal string collegeName { get; set; }
        internal string collegeWebsite { get; set; }
        internal double admissionFee { get; set; }
        internal int totalSeats { get; set; }

        public College()
        {
            GetDetails();
        }
        public College(string code, string name, string website, double admissionFee, int totalSeats)
        {
            this.collegeCode = code;
            this.collegeName = name;
            this.collegeWebsite = website;
            this.admissionFee = admissionFee;
            this.totalSeats = totalSeats;
        }
        public void GetDetails()
        {
            while (true)
            {
                Console.WriteLine("Enter your College Name :");
                try
                {
                    string collegeName = Console.ReadLine();
                    if (!Validation.IsValidName(collegeName))
                    {
                        throw new FormatException();
                    }
                    this.collegeName = collegeName;
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid College Name");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your College Code :");
                try
                {
                    string collegeCode = Console.ReadLine();
                    if (!Validation.IsValidCode(collegeCode))
                    {
                        throw new FormatException();
                    }
                    this.collegeCode = collegeCode;
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid College Code");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter your College Website :");
                try
                {
                    string website = Console.ReadLine();
                    if (!Validation.IsValidWebsite(website))
                    {
                        throw new FormatException();
                    }
                    this.collegeWebsite = website;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid website");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter Your Admission Fee:");
                double fees;
                if (double.TryParse(Console.ReadLine(), out fees))
                {
                    this.admissionFee = fees;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid fees");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter total seats of your college:");
                int fees;
                if (int.TryParse(Console.ReadLine(), out fees))
                {
                    this.admissionFee = fees;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid fees");
                }
            }
        }
        public string GetCode()
        {
            return this.collegeCode;
        }
        public override string ToString()
        {
            return "College Code : " + collegeCode + "     College Name : " + collegeName;
        }
    }

}
