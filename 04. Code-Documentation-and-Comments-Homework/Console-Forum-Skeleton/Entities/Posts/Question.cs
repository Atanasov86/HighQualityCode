namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Contracts;

    public class Question : Post, IQuestion
    {
        private const int DefaultDelimeterLength = 20;

        public Question(int id, string title, string body, IUser author)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            var question = new StringBuilder();

            question.AppendFormat("[ Question ID: {0} ]{1}", this.Id, Environment.NewLine);
            question.AppendFormat("Posted by: {0}{1}", this.Author.Username, Environment.NewLine);
            question.AppendFormat("Question Title: {0}{1}", this.Title, Environment.NewLine);
            question.AppendFormat("Question Body: {0}{1}", this.Body, Environment.NewLine);
            question.AppendFormat("{0}{1}", new string('=', DefaultDelimeterLength), Environment.NewLine);

            if (!this.Answers.Any())
            {
                question.Append("No answers");
            }
            else
            {
                string answersAsString;
                question.AppendLine("Answers:");
                var bestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer);
                if (bestAnswer != null)
                {
                    question.Append(bestAnswer);
                    var otherAnswers = this.Answers.Where(a => a.Id != bestAnswer.Id);
                    answersAsString = string.Join(Environment.NewLine, otherAnswers);
                    question.Append(answersAsString);
                }
                else
                {
                    answersAsString = string.Join(
                    Environment.NewLine,
                    this.Answers.Select(a => a.ToString()));
                    question.Append(answersAsString);
                }
            }

            return question.ToString();
        }
    }
}