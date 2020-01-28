using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    class Operations
    {

        public void AddUserDetails(SqlConnection connection)
        {

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Roll NO: ");
            int rollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            
            SqlCommand sqlCommand = new SqlCommand("INSERTUSER", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ROLLNO", rollNo);
            sqlCommand.Parameters.AddWithValue("@NAME", name);
            sqlCommand.Parameters.AddWithValue("@AGE", age);
            
            int i = sqlCommand.ExecuteNonQuery();
            if (i > 0)
            {
                Console.WriteLine("Inserted successfully!!!");
            }
        }
        public void DisplayUserDetail(SqlConnection connection)
        {
            
            //Using stored procedure
            Console.WriteLine("Enter the roll no to display the user detail");
            int rollNo = int.Parse(Console.ReadLine());
            SqlCommand sqlCommand = new SqlCommand("DISPLAYUSER", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ROLLNO", rollNo);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("ROLLNO: {0}\nNAME: {1}\nAge: {2}",  reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            }
            else
                Console.WriteLine("Not present");
        }
        public void UpdateUserDetail(SqlConnection connection)
        {
            string status;
            do
            {
                Console.WriteLine("Enter the field to be updated: \n1.Name\n2.Age");
                byte choice = Byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UpdateUserName(connection);
                        break;
                    case 2:
                        UpdateAge(connection);
                        break;
                    default:
                        Console.WriteLine("enter correct No");
                        break;
                }
                Console.WriteLine("Do you want to continue[yes/no]: ");
                status = Console.ReadLine().ToLower();
            } while (status == "yes");
        }
        public void UpdateUserName(SqlConnection connection)
        {
            Console.WriteLine("Enter the ROll No");
            int rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the updated name: ");
            String name = Console.ReadLine();


            SqlCommand command = new SqlCommand("UPDATEUSERNAME", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ROLLNO", rollNo);
            command.Parameters.AddWithValue("@NAME", name);
            //command.Parameters["@ROLLNO"].Value = rollNo;
            command.Parameters["@NAME"].Value = name;
            int i = command.ExecuteNonQuery();
            if (i > 0)
            {
                Console.WriteLine("User name updated successfully!!!");
            }

        }
        public void UpdateAge(SqlConnection connection)
        {
            Console.WriteLine("Enter the Roll no");
            int rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the updated age: ");
            int age = int.Parse(Console.ReadLine());



            SqlCommand command = new SqlCommand("UPDATEAGE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ROLLNO", rollNo);
            command.Parameters.AddWithValue("@AGE", age);
            //command.Parameters["@ROLLNO"].Value = rollNo;
            command.Parameters["@AGE"].Value = age;
            int i = command.ExecuteNonQuery();
            if (i > 0)
            {
                Console.WriteLine("User  updated successfully!!!");
            }
        }
        
        public void DeleteUserDetail(SqlConnection connection)
        {
            Console.WriteLine("Enter the mail id to delete the user: ");
            int rollNo = int.Parse(Console.ReadLine());

            SqlCommand command = new SqlCommand("DELETEUSER", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ROLLNO", rollNo);
            command.Parameters["@ROLLNO"].Value = rollNo;
            //command.Parameters.Remove(rollNo);
            command.ExecuteNonQuery();
        }

       
    }
}
