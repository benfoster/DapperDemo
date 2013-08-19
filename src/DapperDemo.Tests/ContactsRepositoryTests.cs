using Dapper;
using DapperDemo.Data;
using DapperDemo.Domain;
using NUnit.Framework;
using System.Linq;

namespace DapperDemo.Tests
{
    public class ContactsRepositoryTests : DapperTest
    {
        private ContactsRepository repo;

        [SetUp]
        public void SetUp()
        {
            repo = new ContactsRepository(connection);
        }
        
        [Test]
        public void Can_add_contact()
        {
            var contact = GetTestContact();
            repo.Add(contact);
            
            var fromDb = repo.GetById(contact.Id);
            Assert.NotNull(fromDb);
            Assert.AreEqual(fromDb.FirstName, contact.FirstName);
            Assert.AreEqual(fromDb.LastName, contact.LastName);
        }

        [Test]
        public void Can_remove_contact_by_id()
        {
            var contact = GetTestContact();
            repo.Add(contact);

            repo.Delete(contact.Id);

            Assert.AreEqual(0, repo.List().Count());
        }

        [TearDown]
        public void CleanUpTestData()
        {
            connection.Execute("delete from contacts");
        }

        private Contact GetTestContact() 
        {
            return new Contact
            {
                FirstName = "John",
                LastName = "Doe"
            };
        }
    }
}
