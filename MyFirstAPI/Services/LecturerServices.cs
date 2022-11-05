using MyFirstAPI.Config;
using MyFirstAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MyFirstAPI.Services
{
    public class LecturerServices
    {
        private Response response;
        public Response getAllLecturer()
        {
            response = new Response();

            try
            {
                List<Lecturer> lecturerList = new List<Lecturer>();

                using(SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();
                    using(SqlCommand command = connection.CreateCommand())
                    {
                        string queryString = "SELECT * FROM Lecturer";
                        command.CommandText = queryString;

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    Lecturer lecturer = new Lecturer();
                                    lecturer.Id = reader["Lec_Code"].ToString();
                                    lecturer.Name = reader["Lec_Name"].ToString();
                                    lecturer.Specs = reader["Specialization"].ToString();
                                    lecturer.DNo = reader["DNo"].ToString();
                                    lecturer.Sal = reader["Salary"].ToString();
                                    lecturer.Addr = reader["Address"].ToString();
                                    lecturerList.Add(lecturer);
                                }
                                response.status = "Success";
                                response.content = lecturerList;
                                response.message = "Sample Data";
                            }
                            else
                            {
                                response.status = "Success";
                                response.content = null;
                                response.message = "Lecturers not found";
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                response.status = "Failed";
                response.content = null;
                response.message = ex.Message;
            }
            return response;
        }

        public Response readByDepartment(string dept_Name)
        {
            response = new Response();

            try
            {
                List<Lecturer> lecturerList = new List<Lecturer>();
                Department department = new Department();

                using (SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                        command.CommandText = "SP_Lecturer_ReadByDName";

                        command.Parameters.AddWithValue("@dName", dept_Name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Lecturer lecturer = new Lecturer();
                                    lecturer.Id = reader["Lec_Code"].ToString();
                                    lecturer.Name = reader["Lec_Name"].ToString();
                                    lecturer.Specs = reader["Specialization"].ToString();
                                    lecturer.DNo = reader["DNo"].ToString();
                                    lecturer.Sal = reader["Salary"].ToString();
                                    lecturer.Addr = reader["Address"].ToString();
                                    lecturerList.Add(lecturer);
                                }
                                response.status = "Success";
                                response.content = lecturerList;
                                response.message = "Sample Data";
                            }
                            else
                            {
                                response.status = "Success";
                                response.content = null;
                                response.message = "Lecturers not found";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = "Failed";
                response.content = null;
                response.message = ex.Message;
            }
            return response;
        }

        public Response updateLecturer(Lecturer lecturer)
        {
            response = new Response();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    sqlConnection.Open();

                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        string queryString = "UPDATE Lecturer SET Lec_Name = @lName , Specialization = @specs , DNo = @dNo , Salary = @sal , Address = @add WHERE Lec_Code = @lNo";
                        command.CommandText = queryString;

                        command.Parameters.AddWithValue("lNo", lecturer.Id);
                        command.Parameters.AddWithValue("lName", lecturer.Name);
                        command.Parameters.AddWithValue("specs", lecturer.Specs);
                        command.Parameters.AddWithValue("dNo", lecturer.DNo);
                        command.Parameters.AddWithValue("sal", lecturer.Sal);
                        command.Parameters.AddWithValue("add", lecturer.Addr);

                        int rows = command.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            response.status = "Success";
                            response.content = lecturer;
                            response.message = "Successfully Updated";
                        }
                        else
                        {
                            response.status = "Failed";
                            response.content = null;
                            response.message = "Not Updated";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = "Failed";
                response.content = null;
                response.message = ex.Message;
            }
            return response;
        }

        public Response deleteLecturer(string lecturerNo)
        {
            response = new Response();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string queryString = "DELETE FROM Lecturer WHERE Lec_Code = @lNo";
                        command.CommandText = queryString;

                        command.Parameters.AddWithValue("lNo", lecturerNo);

                        int rows = command.ExecuteNonQuery();

                        if(rows > 0)
                        {
                            response.status = "Success";
                            response.content = null;
                            response.message = "Successfully Deleted";
                        }
                        else
                        {
                            response.status = "Success";
                            response.content = null;
                            response.message = "Not Deleted";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.status = "Failed";
                response.content = null;
                response.message = ex.Message;
            }
            return response;
        }

        public Response insertLecturer(Lecturer lecturer)
        {
            response = new Response();

            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    sqlConnection.Open();

                    using(SqlCommand command = sqlConnection.CreateCommand())
                    {
                        string queryString = "INSERT INTO Lecturer(Lec_Code, Lec_Name, Specialization, DNo, Salary, Address) VALUES(@lNo, @lName, @specs, @dNo, @sal, @add)";
                        command.CommandText = queryString;

                        command.Parameters.AddWithValue("lNo", lecturer.Id);
                        command.Parameters.AddWithValue("lName", lecturer.Name);
                        command.Parameters.AddWithValue("specs", lecturer.Specs);
                        command.Parameters.AddWithValue("dNo", lecturer.DNo);
                        command.Parameters.AddWithValue("sal", lecturer.Sal);
                        command.Parameters.AddWithValue("add", lecturer.Addr);

                        int rows = command.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            response.status = "Success";
                            response.content = lecturer;
                            response.message = "Successfully Inserted";
                        }
                        else
                        {
                            response.status = "Failed";
                            response.content = null;
                            response.message = "Not Inserted";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = "Failed";
                response.content = null;
                response.message = ex.Message;
            }
            return response;
        }
    }
}
