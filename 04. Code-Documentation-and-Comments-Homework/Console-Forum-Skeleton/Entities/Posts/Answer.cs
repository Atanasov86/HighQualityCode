namespace ConsoleForum.Entities.Posts
{
    using System.Text;

    using ConsoleForum.Contracts;

    public class Answer : Post, IAnswer
    {
        private const int DefaultDelimeterLength = 20;

        public Answer(int id, string body, IUser author) 
            : base(id, body, author)
        {
        }
        
        public override string ToString()
        {
            var answer = new StringBuilder();

            answer.AppendFormat("[ Answer ID: {0} ]", this.Id).AppendLine();
            answer.AppendFormat("Posted by: {0}", this.Author.Username).AppendLine();
            answer.AppendFormat("Answer Body: {0}", this.Body).AppendLine();
            answer.Append(new string('-', DefaultDelimeterLength));

            return answer.ToString();
        }
    }
}