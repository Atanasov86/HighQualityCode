namespace ConsoleForum.Contracts
{
    /// <summary>
    /// This interface implement all mandatory fields for posts.
    /// </summary>
    public interface IPost
    {
        /// <summary>
        /// Saves unique user id for current post.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Saves content of current post
        /// </summary>
        string Body { get; set; }

        /// <summary>
        /// Saves name on current user.
        /// </summary>
        IUser Author { get; set; }
    }
}