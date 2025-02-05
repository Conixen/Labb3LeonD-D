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

            //// Fetching all students from 1 class

            //using (SqlConnection connection = new SqlConnection(connectionString2))
            //{
            //    connection.Open();

            //    string queryClass = "SELECT ClassID, ClassName FROM Class ";
            //    SqlCommand commandClass = new SqlCommand(queryClass, connection);

            //    SqlDataReader reader = commandClass.ExecuteReader();

            //    List<(int ID, string Name)> allClasses = new List<(int ID, string Name)> ();

            //    Console.WriteLine("Välj en klass:");
            //    while (reader.Read())
            //    {
            //        int id = reader.GetInt32(0); 
            //        string name = reader.GetString(1); 

            //        allClasses.Add((id, name));
            //        Console.WriteLine($"{id}: {name}");
            //    }
            //    reader.Close();
            //    Console.Write("Välj vilken klass: ");
            //    if (int.TryParse(Console.ReadLine(), out int classId))
            //    {
            //        // Hämta elever i vald klass
            //        string queryStudents = "SELECT FirstName, LastName FROM Student WHERE ClassID = @ClassId";
            //        SqlCommand cmdStudents = new SqlCommand(queryStudents, connection);
            //        cmdStudents.Parameters.AddWithValue("@ClassId", classId);

            //        SqlDataReader readerStudents = cmdStudents.ExecuteReader();

            //        Console.WriteLine("\nElever i vald klass:");
            //        bool foundStudents = false;

            //        while (readerStudents.Read())
            //        {
            //            foundStudents = true;
            //            Console.WriteLine($"- {readerStudents.GetString(0)} {readerStudents.GetString(1)}");
            //        }

            //        if (!foundStudents)
            //        {
            //            Console.WriteLine("Inga elever hittades i denna klass.");
            //        }

            //        readerStudents.Close();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Ogiltigt klass-ID.");
            //    }

            //    connection.Close();
            //}


            // Add more employe

            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                string queryAdd = @"INSERT INTO EMPLOYE (EmployeName, RollID) 
                                    VALUES (@EmployeName, @RollID)";

                using (SqlCommand commandAdd = new SqlCommand(queryAdd, connection))
                {
                    commandAdd.Parameters.AddWithValue("@EmployeName", "Ström Boström");
                    commandAdd.Parameters.AddWithValue("@RollID", "4");

                    connection.Open();
                    var rowsAffected = commandAdd.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected);

                }
                
                string queryEmploye = "SELECT * FROM Employe";
            
                SqlCommand command2 = new SqlCommand(queryEmploye, connection);

                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    for (int i = 0; i < reader2.FieldCount; i++)
                    {
                        Console.Write(reader2.GetName(i) + "\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    while (reader2.Read())
                    {
                        for (int i = 0; i < reader2.FieldCount; i++)
                        {
                            Console.Write(reader2[i].ToString() + "\t\t");
                        }
                        Console.WriteLine();
                    }
                }
                //string queryEmploye = "SELECT EmployeName, RollID FROM Employe";

            }

            // Fix comand thats shows the new added employe
        }
    }
}
