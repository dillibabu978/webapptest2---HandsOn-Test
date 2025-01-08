using System.Collections.Generic;
using NUnit.Framework;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person FindPerson(string firstName, string lastName);
        void AddPerson(Person newPerson);
        void PrintPersonDetails(Person personObj);

        List<Person> GetAllPerson();
    }
}