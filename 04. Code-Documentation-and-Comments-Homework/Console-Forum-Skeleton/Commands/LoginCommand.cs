namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            var existedUsers = users.FirstOrDefault(
                u => u.Username == username &&
                    u.Password == password);

            if (existedUsers == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            this.Forum.CurrentUser = existedUsers;
            this.Forum.Output.AppendFormat(Messages.LoginSuccess, existedUsers.Username);
            this.Forum.Output.Append(Environment.NewLine);
        }
    }
}
