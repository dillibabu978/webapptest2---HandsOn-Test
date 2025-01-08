using System;
using System.Collections.Generic;
using System.Data.SQLite;
using NUnit.Framework;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {

        private SQLiteConnection _dbConnection;

        public void AddPerson(Person person)
        {
            _dbConnection = DatabaseUtil.GetConnection();
            string InsertData = "INSERT INTO PHONEBOOK (NAME,PHONENUMBER,ADDRESS) VALUES (@NameParam,@PhoneNoParam,@AddressParam)";
            try
            {

                using (SQLiteCommand InsertDataCommand = new SQLiteCommand(InsertData, _dbConnection))
                {
                    InsertDataCommand.Parameters.AddWithValue("@NameParam", person.name);
                    InsertDataCommand.Parameters.AddWithValue("@PhoneNoParam", person.phoneNumber);
                    InsertDataCommand.Parameters.AddWithValue("@AddressParam", person.address);
                    var rowsChanged = InsertDataCommand.ExecuteNonQuery();
                    if (rowsChanged == 1)
                    {
                        Console.WriteLine("Details added successfully");
                    }
                    else {
                        Console.WriteLine("Some error occurred");
                    }
                }
                
            }
            catch (Exception)
            {
                
            }

        }

        public Person FindPerson(string firstName, string lastName)
        {
            _dbConnection = DatabaseUtil.GetConnection();
            string selectPersonQuery = "SELECT Name,PhoneNumber,Address FROM PhoneBook WHERE Name = @nameParam";
            Person personObj = new Person();

            try
            {

                using (SQLiteCommand MyCommand = new SQLiteCommand(selectPersonQuery, _dbConnection))
                {
                    MyCommand.Parameters.AddWithValue("@NameParam", firstName+" "+lastName);
                    using (SQLiteDataReader MyDataReader = MyCommand.ExecuteReader())
                    {
                        while (MyDataReader.Read())
                        {
                            personObj.name = MyDataReader["Name"].ToString();
                            personObj.phoneNumber = MyDataReader["PhoneNumber"].ToString();
                            personObj.address = MyDataReader["address"].ToString();
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
            return personObj;
        }

        public void PrintPersonDetails(Person personObj) {
            Console.WriteLine("Name : " + personObj.name);
            Console.WriteLine("Phone Number : " + personObj.phoneNumber);
            Console.WriteLine("Address : "+personObj.address);
            Console.WriteLine("=============================================");
        }

        public List<Person> GetAllPerson() {

            _dbConnection = DatabaseUtil.GetConnection();
            string selectAllQuery = "SELECT Name,PhoneNumber,Address FROM PhoneBook";
            List<Person> lst = new List<Person>();

            try
            {

                using (SQLiteCommand MyCommand = new SQLiteCommand(selectAllQuery, _dbConnection))
                {
                    using (SQLiteDataReader MyDataReader = MyCommand.ExecuteReader())
                    {
                        while (MyDataReader.Read())
                        {
                            lst.Add(new Person()
                            {
                                name = MyDataReader["Name"].ToString(),
                                phoneNumber = MyDataReader["PhoneNumber"].ToString(),
                                address = MyDataReader["address"].ToString()
                            });
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
            return lst;

        }
    }
}