using System.Collections.Generic;
using System.Linq;

namespace _03.OldestFamilyMember
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public List<Person> People
        {
            get
            {
                return this.people;
            }
            set
            {
                this.people = value;
            }
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }

}
