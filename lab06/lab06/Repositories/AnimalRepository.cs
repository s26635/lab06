using System.Data.SqlClient;
using lab06.DTO;
using lab06.Models;

namespace lab06.Repositories;

public class AnimalRepository : IAnimalRepository
{
    

    public IList<Animal> GetAnimals()
    {
        string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True";
        List<Animal> _animals = new List<Animal>();
        string query = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryID", 1);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idAnimal = (int)reader["IdAnimal"];
                        string name = reader["Name"].ToString();
                        string description = reader["Description"].ToString();
                        string category = reader["Category"].ToString();
                        string area = reader["Area"].ToString();
                        _animals.Add(new Animal(idAnimal, name, description, category, area));
                    }
                    return _animals;
                }
            }
        }
    }

    public Animal GetAnimal(int id)
    {
        string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True";

        string query = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal=@IdAnimal";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdAnimal", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        string name = reader["Name"].ToString();
                        string description = reader["Description"].ToString();
                        string category = reader["Category"].ToString();
                        string area = reader["Area"].ToString();
                        return new Animal(id, name, description, category, area);
                        
                    }
                }
            }
        }

        return null;
    }

    public Animal AddAnimal(AnimalDTO animalDTO)
    {
        string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True";

        string query = "insert into Animal values (@name,@description,@category,@area)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@name", animalDTO.Name);
                command.Parameters.AddWithValue("@description", animalDTO.Description);
                command.Parameters.AddWithValue("@category", animalDTO.Category);
                command.Parameters.AddWithValue("@area", animalDTO.Area);
                command.ExecuteReader();
            }
        }

        return null;
    }

    public void UpdateAnimal(int idAnimal, AnimalDTO animalDTO)
    {
        string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True";

        string query = "UPDATE Animal SET Name=@name, Description=@description, Category=@category, Area=@area WHERE IdAnimal=@idAnimal";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idAnimal", idAnimal);
                command.Parameters.AddWithValue("@name", animalDTO.Name);
                command.Parameters.AddWithValue("@description", animalDTO.Description);
                command.Parameters.AddWithValue("@category", animalDTO.Category);
                command.Parameters.AddWithValue("@area", animalDTO.Area);
                command.ExecuteReader();
            }
        }

    }

    public void DeleteAnimal(int id)
    {
        string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True";

        string query = "DELETE FROM Animal WHERE IdAnimal=@IdAnimal";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdAnimal", id);
                command.ExecuteReader();
            }
        }

    }
}