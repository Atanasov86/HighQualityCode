namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            var title = this.Data[1];
            var body = this.Data[2];
            var author = this.Forum.CurrentUser;
            var question = new Question(this.Forum.Questions.Count + 1, title, body, author);
            this.Forum.Questions.Add(question);
            this.Forum.Output.AppendFormat(Messages.PostQuestionSuccess, question.Id).AppendLine();
        }
    }
}
