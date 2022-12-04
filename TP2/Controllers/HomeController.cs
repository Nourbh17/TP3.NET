using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using TP2.Models;


namespace TP2.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SQLiteConnection dbCon=new SQLiteConnection (@"Data Source=C:\Users\nourb\OneDrive\Bureau\Tp2.Net\2022 GL3 .NET Framework TP3 - SQLite database.db");
           dbCon.Open();
            using(dbCon)
            {
                SQLiteCommand command = new SQLiteCommand(
                   " SELECT * FROM personal_info ", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string firstName = (string)reader["first_name"];
                        string lastName = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image =(string)reader["image"];
                        string country = (string)reader["country"];
                        Debug.WriteLine("id :" + id + " firstName:" + firstName + " lastName: " + lastName + " email: " + email + " image : " + image + " country: " + country);
                        
                    }
                }
                    }
               return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        
    }
}