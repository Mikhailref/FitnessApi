using Fitness_club_API.Interfaces;
using Fitness_club_API.Models;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Fitness_club_API.Utilities
{
    public class DataBase : IDataBase
    {

        
        private List<Employees> Employees=new List<Employees>();
        private readonly Employees? Employee;

        private List<Clients> ClientsList = new List<Clients>();
        private readonly Clients? Client;

        private readonly SqlConnection conn = new SqlConnection
        (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fitness Club Clients;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        public (Employees, List<Employees>) EmployeesReader([Optional] int Id)
        {

            if (Id > 0)
            {
                SqlCommand command = new SqlCommand
                ($"Select * from [Fitness Club Clients].[dbo].[Employees] where Id = '{Id}'", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employees employee = new Employees();
                    employee.Id = (int)reader.GetValue(0);
                    employee.FirstName = reader.GetValue(1).ToString();
                    employee.SecondName = reader.GetValue(2).ToString();
                    employee.Image = reader.GetValue(3).ToString();
                    employee.Department = reader.GetValue(4).ToString();
                    return (employee, Employees);
                }

                conn.Close();
            }

            else
            {
                SqlCommand command = new SqlCommand
                   ($"Select all * from [Fitness Club Clients].[dbo].[Employees] ", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employees employee = new Employees();
                    employee.Id = (int)reader.GetValue(0);
                    employee.FirstName = reader.GetValue(1).ToString();
                    employee.SecondName = reader.GetValue(2).ToString();
                    employee.Image = reader.GetValue(3).ToString();
                    employee.Department = reader.GetValue(4).ToString();

                    Employees.Add(employee);
                }

                return (Employee, Employees);

                conn.Close();

            }
            return (null, null);
        }

        public (Clients, List<Clients>) ClientsReader([Optional] int Id)
        {

            if (Id > 0)
            {
                SqlCommand command = new SqlCommand
                ($"Select * from [Fitness Club Clients].[dbo].[Clients] where Id = '{Id}'", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Clients client = new Clients();
                    client.Id = (int)reader.GetValue(0);
                    client.FirstName = reader.GetValue(1).ToString();
                    client.SecondName = reader.GetValue(2).ToString();
                    client.Image = reader.GetValue(3).ToString();
                    client.gender = (Clients.Gender)(int)reader.GetValue(4);

                    return (client, ClientsList);
                }

                conn.Close();
            }

            else
            {
                SqlCommand command = new SqlCommand
                   ($"Select all * from [Fitness Club Clients].[dbo].[Clients] ", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Clients client = new Clients();
                    client.Id = (int)reader.GetValue(0);
                    client.FirstName = reader.GetValue(1).ToString();
                    client.SecondName = reader.GetValue(2).ToString();
                    client.Image = reader.GetValue(3).ToString();
                    client.gender = (Clients.Gender)(int)reader.GetValue(4);

                    ClientsList.Add(client);
                }

                return (Client, ClientsList);

                conn.Close();

            }
            return (null, null);
        }



        public void Writer(Clients client, Employees employee)
        {
            if (client != null)
            {
                using (conn)
                {
                    conn.Open();
                    string sql = "INSERT into [Fitness Club Clients].[dbo].[Clients] (Id,FirstName,SecondName,Image,Gender)  VALUES (@Id,@FirstName,@SecondName,@Image,@Gender)";

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@Id", client.Id);
                        command.Parameters.AddWithValue("@FirstName", client.FirstName);
                        command.Parameters.AddWithValue("@SecondName", client.SecondName);
                        command.Parameters.AddWithValue("@Image", client.Image);
                        command.Parameters.AddWithValue("@Gender", client.gender);
                        command.ExecuteNonQuery();
                    }
                }

            }

            else if (employee != null)
            {
                using (conn)
                {
                    conn.Open();
                    string sql = "INSERT into [Fitness Club Clients].[dbo].[Employees] (Id,FirstName,SecondName,Image, Department)  VALUES (@Id,@FirstName,@SecondName,@Image,@Department)";

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@Id", employee.Id);
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@SecondName", employee.SecondName);
                        command.Parameters.AddWithValue("@Image", employee.Image);
                        command.Parameters.AddWithValue("@Department", employee.Department);
                        command.ExecuteNonQuery();
                    }
                }

            }

        }


        public void Eraser(int Id, string TypeOfPerson)
        {
            string sql;
            using (conn)
            {
                conn.Open();

                switch (TypeOfPerson)
                {
                    case "Clients":

                        sql = $"DELETE from [Fitness Club Clients].[dbo].[Clients] where Id = '{Id}'";

                        using (SqlCommand command = new SqlCommand(sql, conn))
                        {
                            command.ExecuteNonQuery();
                        }

                        break;

                    case "Employees":

                        sql = $"DELETE from [Fitness Club Clients].[dbo].[Employees] where Id = '{Id}'";

                        using (SqlCommand command = new SqlCommand(sql, conn))
                        {
                            command.ExecuteNonQuery();
                        }

                        break;
                }


            }
        }


    }
}
