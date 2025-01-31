using Microsoft.Data.SqlClient;

namespace Labb3LeonD_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // sql server explorer "Conection string"

            // Connection string
            // var connectionString = @"Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            var connectionString2 = @"Data Source = localhost;Initial Catalog = SchoolDeLeon3;Integrated Security=True;Trust Server Certificate=True";

            // Fetching all students

            //using (SqlConnection connection = new SqlConnection(connectionString2)) 
            //{
            //    connection.Open();

            //    string queryPupil = "SELECT FirstName, LastName FROM STUDENT ORDER BY FirstName";
            //    //string querypupil = "SELECT FirstName, LastName FROM STUDENT ORDER BY LastName";

            //    SqlCommand command = new SqlCommand(queryPupil, connection);

            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        for (int i = 0; i < reader.FieldCount; i++) 
            //        {
            //            Console.Write(reader.GetName(i) + "\t");
            //        }
            //        Console.WriteLine();
            //        Console.WriteLine();
            //        while (reader.Read())
            //        {
            //            for (int i = 0; i < reader.FieldCount; i++)
            //            {
            //                Console.Write(reader[i].ToString() + "\t\t");
            //            }
            //            Console.WriteLine();
            //        }
            //    }
            //    connection.Close();
            //}

            // Fetching all students from 1 class

            //using (SqlConnection connection = new SqlConnection(connectionString2)) 
            //{ 
            //    connection.Open();

            //    string queryClass = "SELECT ClassID FROM STUDENT ";
            //    connection.Close();
            //}

            // Add more employe

            using (SqlConnection connection = new SqlConnection(connectionString2)) 
            {
                string queryAdd = @"INSERT INTO EMPLOYE (EmployeName, RollID) 
                                    VALUES (@EmployeName, @RollID)";

                using (SqlCommand commandAdd = new SqlCommand(queryAdd, connection)) 
                {
                    commandAdd.Parameters.AddWithValue("@EmployeName", "Bo Boström");
                    commandAdd.Parameters.AddWithValue("@RollID", "5");

                    connection.Open();
                    var rowsAffected = commandAdd.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected);
                }
            }
        }
    }
}
