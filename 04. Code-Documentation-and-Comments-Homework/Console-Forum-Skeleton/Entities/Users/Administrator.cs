namespace ConsoleForum.Entities.Users
{
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public class Administrator : User, IAdministrator
    {
        public Administrator(int id, string username, string password, string email)
            : base(id, username, password, email)
        {
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IList<IQuestion> Questions { get; private set; }
    }
}