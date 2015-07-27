namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int inputId = int.Parse(this.Data[1]);
            var question = this.Forum.CurrentQuestion;
            var answer = question.Answers.FirstOrDefault(a => a.Id == inputId);
            var user = this.Forum.CurrentUser;
            
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (!(user is IAdministrator || question.Author == user))
            {
                throw new CommandException(Messages.NoPermission);
            }

            var bestAnswer = new BestAnswer(
                inputId,
                answer.Body,
                answer.Author);
            this.Forum.Answers.Add(bestAnswer);
            this.Forum.Answers.Remove(answer);
            question.Answers.Remove(answer);
            question.Answers.Add(bestAnswer);
            this.Forum.Output.AppendFormat(Messages.BestAnswerSuccess, inputId).AppendLine();
        }
    }
}
