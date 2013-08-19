using System;

namespace DapperDemo.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Contact()
        {
            Id = Guid.NewGuid();
        }
    }
}
