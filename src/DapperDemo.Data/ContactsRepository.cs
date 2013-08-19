using Dapper;
using DapperDemo.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DapperDemo.Data
{
    public class ContactsRepository
    {
        private IDbConnection cn;

        public ContactsRepository(IDbConnection cn)
        {
            this.cn = cn;
        }

        public Contact GetById(Guid id)
        {
            var query = @"
                SELECT TOP 1 * FROM Contacts
                WHERE Id = @Id
            ";

            return cn.Query<Contact>(query, new { id = id }).FirstOrDefault();
        }

        public IEnumerable<Contact> List()
        {
            var query = @"
                SELECT * FROM Contacts
            ";

            return cn.Query<Contact>(query);
        }
        
        public void Add(Contact contact)
        {
            var cmd = @"
                INSERT INTO Contacts (Id, FirstName, LastName)
                VALUES (@Id, @FirstName, @LastName)
            ";

            cn.Execute(cmd, contact);
        }

        public void Delete(Guid id)
        {
            var cmd = @"
                DELETE FROM Contacts WHERE Id = @Id
            ";

            cn.Execute(cmd, new { Id = id });
        }
    }
}
