using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace konzolna
{
    class PersonService
    {
        private List<Person> _people = new List<Person>();

        public string Add(Person person)
        {
            string check = string.Empty;
            var checkCeo = _people.Any(x => x.Role == "ceo");

            if (ValidatePerson(person) && checkCeo == false)
            {
                _people.Add(person);
                check = "Person added";
            }
            else
            {
                check = "Validation error";
            }
            return check;
        }

        public bool Delete(Guid id)
        {
            var person = _people.Find(p => p.Id == id);
            bool check = false;
            if (person != null)
            {
                check = _people.Remove(person);
            }
            return check;
        }

        public List<Person> Display()
        {
            return _people;
        }

        public List<Person> ListAll()
        {
            return _people.Where(x => x.Role != "ceo").ToList();
        }

        public List<Person> ListRole(string role)
        {
            return _people.Where(x => x.Role == role).ToList();
        }

        private bool ValidatePerson(Person person)
        {
            bool check = false;

            if (
                !string.IsNullOrEmpty(person.Name)
                && !string.IsNullOrEmpty(person.LastName)
                && !string.IsNullOrEmpty(person.Role)
                && person.Name.Length > 2
                && person.LastName.Length > 2
                && person.Role.Length > 2
                )
            {
                check = true;
            }
            return check;
        }
    }
}
