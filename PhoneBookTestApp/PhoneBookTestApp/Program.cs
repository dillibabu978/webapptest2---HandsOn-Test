using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                PhoneBook phonebook = new PhoneBook();
                Person personObj1 = new Person()
                {
                    name = "John Smith",
                    phoneNumber = "(248) 123-4567",
                    address= "1234 Sand Hill Dr, Royal Oak, MI"
                };
                Person personObj2 = new Person()
                {
                    name = "Cynthia Smith",
                    phoneNumber = "(824) 128-8758",
                    address = "875 Main St, Ann Arbor, MI"
                };
                phonebook.AddPerson(personObj1);
                phonebook.AddPerson(personObj2);


                // TODO: print the phone book out to System.out
                List<Person> lst =  phonebook.GetAllPerson();
                foreach (var item in lst)
                {
                    phonebook.PrintPersonDetails(item);
                }
                // TODO: find Cynthia Smith and print out just her entry

                phonebook.PrintPersonDetails(phonebook.FindPerson("Cynthia", "Smith"));

                // TODO: insert the new person objects into the database

                Person personObj3 = new Person()
                {
                    name = "John Watson",
                    phoneNumber = "(824) 128-8758",
                    address = "875 Main St, Ann Arbor, MI"
                };
                phonebook.AddPerson(personObj3);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
