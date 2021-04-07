using NUnit.Framework;
using PeopleDatabase;
using System;

namespace Tests
{
    public class Tests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            this.database = new Database();
            database.Add(new Person("Ivan", 123456));
            database.Add(new Person("Pesho", 12345678));
            database.Add(new Person("Gosho", 1234567890));
        }

        [Test]
        public void PersonConstructorShouldThrowExceptionForInvalidId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Person("Mimi", -123445));
        }
        [Test]
        public void PersonConstructorShouldInitializeCorrectly()
        {
            Person person = new Person("Mimi", 0123);
            Assert.AreEqual("Mimi", person.Username);
            Assert.AreEqual(0123, person.Id);
        }
        [Test]
        public void AddMethodShouldAddCorrectly()
        {
            Assert.That(3, Is.EqualTo(this.database.People.Count));
        }
        [Test]
        [TestCase("Ivan", 1514)]
        [TestCase("Misho", 123456)]
        [TestCase("Pesho", 12345678)]
        public void AddMethodShouldThrowExceptionForInvalidPerson(string name, long id)
        {
            Person person = new Person(name, id);
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }
        [Test]
        public void RemoveMethodShouldRemoveExistingPerson()
        {
            Person existingPerson = new Person("Gosho", 1234567890);
            this.database.Remove(existingPerson);
            CollectionAssert.DoesNotContain(this.database.People, existingPerson);
        }
        [Test]
        public void RemoveMethodShouldNotRemovePerson()
        {
            Person person = new Person("Stamat", 1234567890);
            this.database.Remove(person);
            Assert.AreEqual(3, this.database.People.Count);
        }
        [Test]
        public void FindByIdMethodShouldReturnCorrectPerson()
        {
            long idOfExistingPerson = 12345678;

            var person = this.database.FindById(idOfExistingPerson);

            Assert.AreEqual(idOfExistingPerson, person.Id);
        }
        [Test]
        public void FindByIdMethodShouldThrowAnExceptionForNegativeId()
        {
            long id = -123456;
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }
        [Test]
        public void FindByIdMethodShouldThrowAnExceptionForNotExistingId()
        {
            long id = 7878;
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(id));
        }
        [Test]
        public void FindByUsernameMethodShouldReturnCorrectPerson()
        {
            string name = "Pesho";

            var person = this.database.FindByUsername(name);

            Assert.AreEqual(name, person.Username);
        }
        [Test]
        public void FindByUsernameMethodShouldThrowAnExceptionForEmptyString()
        {
            string name = "";

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(name));
        }
        [Test]
        public void FindByUsernameMethodShouldThrowAnExceptionForNotExistingUser()
        {
            string name = "Dancho";

            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(name));
        }
    }
}