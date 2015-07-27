namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Text;

    using ConsoleForum.Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            var bestAnswer = new StringBuilder();
            bestAnswer.AppendLine(new string('*', 20));
            bestAnswer.Append(base.ToString()).AppendLine();
            bestAnswer.Append(new string('*', 20)).AppendLine();
            return bestAnswer.ToString();
        }
    }
}