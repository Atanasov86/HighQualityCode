namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;

    using ConsoleForum.Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int serchingQuestionId = int.Parse(this.Data[1]);
            var serchingQuestion = this.Forum.Questions.FirstOrDefault(q => q.Id == serchingQuestionId);
            if (serchingQuestion == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = serchingQuestion;
            this.Forum.Output.AppendLine(string.Join(Environment.NewLine, serchingQuestion));
        }
    }
}
