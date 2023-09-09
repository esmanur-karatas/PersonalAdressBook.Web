using Microsoft.AspNetCore.Mvc;
using PersonalAdressBook.Web.Models;

namespace PersonalAdressBook.Web.Controllers
{
    public class PersonsController : Controller
    {
        private PersonDbContext _context;
        private readonly PersonRepository _personRepository;
        public PersonsController(PersonDbContext context)
        {
            _personRepository = new PersonRepository();
            _context = context;
        }
        public IActionResult Index(string Search)
        {
            var person = _context.Persons.ToList(); // veri tabanındaki tüm verileri aldık.
            if (!string.IsNullOrEmpty(Search))
            {
                Search = Search.ToLower();
                person = person.Where(x => x.Name.ToLower().Contains(Search) || x.Surname.ToLower().Contains(Search)).ToList();

            }
            return View(person);
        }
        public IActionResult Remove(int id)
        {
            var person = _context.Persons.Find(id);
            _context.Persons.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Person newPerson)
        {
            _context.Persons.Add(newPerson);
            _context.SaveChanges();
            TempData["status"] = "Ürün Bilgileri Başarıyla Eklendi.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var person = _context.Persons.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(Person UpdatePerson)
        {
            _context.Persons.Update(UpdatePerson);
            _context.SaveChanges();
            TempData["status"] = "Kişi Bilgileri Başarıyla Güncelleştirildi.";
            return RedirectToAction("Index");
        }

    }
}
