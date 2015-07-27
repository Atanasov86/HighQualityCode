namespace ConsoleForum.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface implement all mandatory fields for question 
    /// </summary>
    public interface IQuestion : IPost
    {
        /// <summary>
        /// This field saves the title of question.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// This field saves all answers of current question.
        /// </summary>
        IList<IAnswer> Answers { get; }
    }
}