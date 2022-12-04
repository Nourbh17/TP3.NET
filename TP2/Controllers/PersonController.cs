using Microsoft.AspNetCore.Mvc;
using TP2.Models;
namespace TP2.Controllers
{
    public class PersonController : Controller 
    {
        [Route("Person/{id:int}")]
        public IActionResult OnePerson(int id)
        {
            Personal_info personalInfo = new Personal_info();
            return View(personalInfo.GetPerson(id));
        }

        [Route("Person/all")]
        public IActionResult AllPersons()
        {
            Personal_info personalInfo = new Personal_info();
            return View(personalInfo.GetAllPerson());
        }

        [HttpGet]
        public IActionResult Search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult Search(String first_name, String country)
        {
            Personal_info Personal_info = new Personal_info();
            List<Person> Persons = Personal_info.GetAllPerson();
            foreach (Person person in Persons)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return Redirect(person.id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
    }
}

    
