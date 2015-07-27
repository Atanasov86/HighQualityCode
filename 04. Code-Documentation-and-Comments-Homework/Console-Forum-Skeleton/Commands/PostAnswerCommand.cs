namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string body = this.Data[1];
            var author = this.Forum.CurrentUser;
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var answer = new Answer(this.Forum.Answers.Count + 1, body, author);
            var question = this.Forum.CurrentQuestion;
            this.Forum.Answers.Add(answer);
            question.Answers.Add(answer);
            this.Forum.Output.AppendFormat(Messages.PostAnswerSuccess, answer.Id).AppendLine();
        }
    }
}
