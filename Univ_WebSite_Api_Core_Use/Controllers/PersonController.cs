using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Univ_WebSite_Api_Core_Use.Models;

namespace Univ_WebSite_Api_Core_Use.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            List<Person> personList = new List<Person>();



            string uri = "https://localhost:7283/api/";

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(uri);

            HttpResponseMessage r = httpClient.GetAsync("Person").Result;

            string x = r.Content.ReadAsStringAsync().Result;


            personList = JsonConvert.DeserializeObject<List<Person>>(x);


            return View(personList);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {

            Person person = GetByID(id);


            return View(person);
        }

        private Person GetByID(int id)
        {
            Person person = new Person();


            string uri = "https://localhost:7283/api/Person/" + id;

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(uri);


            HttpResponseMessage r = httpClient.GetAsync("").Result;

            string x = r.Content.ReadAsStringAsync().Result;

            person = JsonConvert.DeserializeObject<Person>(x);

            return person;
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {

                string uri = "https://localhost:7283/api/Person";

                HttpClient httpClient = new HttpClient();


                httpClient.BaseAddress = new Uri(uri);


                HttpResponseMessage r = httpClient.PostAsJsonAsync<Person>("", person).Result;

                string x = r.Content.ReadAsStringAsync().Result;


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = GetByID(id);


            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            try
            {
                string uri = "https://localhost:7283/api/Person/" + person.PersonID;


                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress=new Uri(uri);

               HttpResponseMessage r =  httpClient.PutAsJsonAsync<Person>("",person).Result;

                string x = r.Content.ReadAsStringAsync().Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            Person person = GetByID(id);


            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(Person person)
        {
            try
            {
                string uri = "https://localhost:7283/api/Person/" + person.PersonID;

                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(uri);

                httpClient.DeleteAsync("");



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
