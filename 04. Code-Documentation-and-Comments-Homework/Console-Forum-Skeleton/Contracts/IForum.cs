namespace ConsoleForum.Contracts
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This interface implement all mandatory fields for forum and method which runs forum. 
    /// </summary>
    public interface IForum
    {
        /// <summary>
        /// This field saves whether forum is started.
        /// </summary>
        bool HasStarted { get; set; }

        /// <summary>
        /// This field saves all registered users.
        /// </summary>
        IList<IUser> Users { get; }

        /// <summary>
        /// Saves all questions on the forum.
        /// </summary>
        IList<IQuestion> Questions { get; }

        /// <summary>
        /// Saves all answers on the forum.
        /// </summary>
        IList<IAnswer> Answers { get; }

        /// <summary>
        /// This field saves current open question.
        /// </summary>
        IQuestion CurrentQuestion { get; set; }

        /// <summary>
        /// This field saves whether user is logged.
        /// </summary>
        bool IsLogged { get; }

        /// <summary>
        /// Saves logged user.
        /// </summary>
        IUser CurrentUser { get; set; }

        StringBuilder Output { get; }

        /// <summary>
        /// This method runs forum.
        /// </summary>
        void Run();
    }
}