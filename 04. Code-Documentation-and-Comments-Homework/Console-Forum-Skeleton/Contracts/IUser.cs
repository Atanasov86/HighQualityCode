namespace ConsoleForum.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface implement all mandotory field for every user.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// This field saves unique number for current intance.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// This field saves username for current intance.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// This field save password for current intance.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// This field save email for current instance.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// This field save all questions, where current instance is ask.
        /// </summary>
        IList<IQuestion> Questions { get; }
    }
}