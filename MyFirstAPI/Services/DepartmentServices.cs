using MyFirstAPI.Config;
using MyFirstAPI.Models;
using System.Data.SqlClient;

namespace MyFirstAPI.Services
{
    public class DepartmentService
    {
        private Response response;

        public Response getAllDepartment()
        {
            response = new Response();

            try
            {
                List<Department> departmentList = new List<Department>();

                using (SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string queryString = "SELECT * FROM Department";
                        command.CommandText = queryString;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Department department = new Department();
                                    department.DeptNo = reader["Dept_No"].ToString();
                                    department.DName = reader["DName"].ToString();
                                    departmentList.Add(department);
                                }
                                response.status = "Success";
                                response.content = departmentList;
                                response.message = "Sample Data";
                            }
                            else
                            { 
                                response.status = "Fail";
                                response.content = null;
                                response.message = "Departments not found";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = "Fail";
                response.content = null;
                response.message = ex.Message;
            }
            return response;
        }

        internal Response deleteDepartment(string departmentNo)
        {
            response = new Response();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string queryString = "DELETE FROM Department WHERE Dept_No = @No";
                        command.CommandText = queryString;

                        command.Parameters.AddWithValue("No", departmentNo);

                        int rows = command.ExecuteNonQuery();

                        if(rows > 0)
                        {
                            response.status = "Success";
                            response.content = departmentNo;
                            response.message = "Successfully Deleted";
                        }
                        else
                        {
                            response.status = "Failed";
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

        internal Response updateDepartment(Department department)
        {
            response = new Response();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string queryString = "UPDATE Department SET DName = @Name WHERE Dept_No = @No";
                        command.CommandText = queryString;

                        command.Parameters.AddWithValue("No", department.DeptNo);
                        command.Parameters.AddWithValue("Name", department.DName);

                        int rows = command.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            response.status = "Success";
                            response.content = department;
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

        public Response insertDepartment(Department department)
        {
            response = new Response();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectDB.getConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        string queryString = "INSERT INTO Department(Dept_No, DName) VALUES(@No, @Name)";
                        command.CommandText = queryString;

                        command.Parameters.AddWithValue("No", department.DeptNo);
                        command.Parameters.AddWithValue("Name", department.DName);

                        int rows = command.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            response.status = "Success";
                            response.content = department;
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
