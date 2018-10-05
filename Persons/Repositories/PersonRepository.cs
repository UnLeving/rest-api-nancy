using Dapper;
using Persons.Interfaces;
using Persons.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Persons.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\GitHub\\task rest api\\Persons\\App_Data\\Database1.mdf\";Integrated Security=True";

        public Person Find(int id)
        {
            Person person = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                person = db.Query<Person>("SELECT * FROM Users WHERE Guid = @id", new { id }).FirstOrDefault();
            }
            return person;
        }

        public void Insert(Person item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, BirthDay, Age) VALUES(@Name, @BirthDay, @Age)";
                db.Query<int>(sqlQuery, item).FirstOrDefault();
            }
        }
    }
}
