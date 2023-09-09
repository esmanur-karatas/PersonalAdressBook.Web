namespace PersonalAdressBook.Web.Models
{
    public class PersonRepository
    {
        private static List<Person> _person = new List<Person>();
        public List<Person> GetAll() => _person;
        public void Add (Person newPerson) => _person.Add(newPerson);

        public void Remove (int id)
        {
            var hasPerson = _person.FirstOrDefault(x => x.Id == id);
            if (hasPerson != null)
            {
                throw new Exception("Bu Numaraya Sahip Kişi Bilgisi Bulunamamaktadır!");
            }
            _person.Remove(hasPerson);
        }

        public void Update (Person updatePerson)
        {
            var hasPerson = _person.FirstOrDefault(x =>x.Id == updatePerson.Id);
            if (hasPerson != null)
            {
                throw new Exception("Bu Numaraya Ait Kişi Bilgisi Bulunamamaktadır!");
            }
            hasPerson.Name= updatePerson.Name;
            hasPerson.Surname= updatePerson.Surname;
            hasPerson.Phone= updatePerson.Phone;
            hasPerson.Email= updatePerson.Email;

            var index = _person.FindIndex(x=>x.Id == updatePerson.Id);
            _person [index] = hasPerson;
        }
    }
}
