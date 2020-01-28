using System;
using System.Data.SqlClient;
using System.Data;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();
            SqlConnection connection = new SqlConnection(@"data source=LAPTOP-HE1NGVBC\SQLEXPRESS;database=student;integrated security=true");
            try
            {
                String sql = "SELECT * from studentDetails";
                SqlCommand cmd = new SqlCommand(sql,connection);
                connection.Open();
                ////SqlDataReader rdr = cmd.ExecuteReader();
                ////rdr.Close();
                //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * from studentDetails", connection);
                //DataTable table = new DataTable();
                //dataAdapter.Fill(table);
                //foreach (DataRow row in table.Rows)
                //{

                //    foreach (DataColumn column in table.Columns)
                //    {
                //        Console.Write(row[column]+"\t");
                //    }
                //    Console.WriteLine();
                //}
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Enter your choice: \n1.Add user\n2.update user\n3.delete user\n4.display user\n5.Exit");
                    byte choice = Byte.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            operations.AddUserDetails(connection);
                            break;
                        case 2:
                            operations.UpdateUserDetail(connection);
                            break;
                        case 3:
                            operations.DeleteUserDetail(connection);
                            break;
                        case 4:
                            operations.DisplayUserDetail(connection);
                            break;
                        case 5:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPS!something went wrong"+ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
