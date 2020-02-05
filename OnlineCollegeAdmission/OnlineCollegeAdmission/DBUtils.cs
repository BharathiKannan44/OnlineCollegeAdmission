using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OnlineCollegeAdmission
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string connectionString = @"Data Source = KANNAN\SQLEXPRESS; Initial Catalog  = OnlineAdmisssionEntry; Persist Security Info =True; User ID =sa; Password = mrbk9698;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public static void CopyDbTOList()
        {
            using (SqlConnection sqlConnection = GetDBConnection())
            {
                sqlConnection.Open();
                string sql = "SELECT_PROCEDURE";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    DataTable adminDataTable = dataSet.Tables["Table"];
                    DataTable userDataTable = dataSet.Tables["Table1"];
                    DataTable collegeDataTable = dataSet.Tables["Table2"];
                    foreach (DataRow row in adminDataTable.Rows)
                    {
                        Admin admin = new Admin(row[0].ToString(), row[2].ToString(), row[1].ToString());
                        AdminRepository.adminList.Add(admin.adminId, admin);
                    }
                    foreach (DataRow row in userDataTable.Rows)
                    {
                        Student student = new Student(Convert.ToInt32(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToDateTime(row[4].ToString()), row[5].ToString(), Convert.ToDouble(row[6].ToString()), Convert.ToDouble(row[7].ToString()), row[8].ToString(), row[9].ToString());
                        UserRepository.userList.Add(student.userId, student);
                    }
                    foreach (DataRow row in collegeDataTable.Rows)
                    {
                        College college = new College(row[0].ToString(), row[1].ToString(), row[2].ToString(), Convert.ToDouble(row[3].ToString()), Convert.ToInt32(row[4].ToString()));
                        CollegeRepository.collegeList.Add(college.collegeCode, college);
                    }
                }
            }
        }

        public static void StudentToDB(Student student)
        {
            using (SqlConnection sqlConnection = GetDBConnection())
            {
                string sql = "INSERT_STUDENT";
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@Password", student.password);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@FirstName", student.firstName);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@SecondName", student.lastName);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@Dob", student.dob);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@EmailID", student.emailId);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@CutOff", student.twelthCutOff);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@Mark", student.twelthMark);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@PhoneNumber", student.phoneNumber);
                    sqlCommand.Parameters.Add(param);

                    param = new SqlParameter("@CollegeCode", student.collegeCode);
                    sqlCommand.Parameters.Add(param);

                    int rows = sqlCommand.ExecuteNonQuery();

                }
            }
        }

        public static int GetId(Student student)
        {
            using (SqlConnection sqlConnection = GetDBConnection())
            {
                string sql = "GET_Id";
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@EmailID", student.emailId);
                    sqlCommand.Parameters.Add(param);

                    return  (int)sqlCommand.ExecuteScalar();                   
                }
            }

        }

        public static bool CheckCollegeSeats(string collegeCode)
        {
            string sql = "ALOT_SEATS";
            using (SqlConnection sqlConnection = GetDBConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@CollegeCode", collegeCode);
                    sqlCommand.Parameters.Add(param);

                    int rows = sqlCommand.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
