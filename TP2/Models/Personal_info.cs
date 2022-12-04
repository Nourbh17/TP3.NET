using System.Data;
using System.Data.SQLite;
namespace TP2.Models
{
    public class Personal_info

    {
        public List<Person> GetAllPerson()
        {
            List<Person> List = new List<Person>();
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\nourb\\OneDrive\\Bureau\\Tp2.Net\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("Select * FROM personal_info", dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string firstName = (string)reader["first_name"];
                        string lastName = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        List.Add(new Person(id, firstName, lastName, email, image, country));
                    }
                }
            }
            return List;
        }


        public Person GetPerson (int id)
        {
            List<Person> list = GetAllPerson();
            for (int i=0; i< list.Count; i++)
            {
                if (list[i].id == id)
                {
                    return list[i];
                }
            }
            return null;
        }
        

    }
}
