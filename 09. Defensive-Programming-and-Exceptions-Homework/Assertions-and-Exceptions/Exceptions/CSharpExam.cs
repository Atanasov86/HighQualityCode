using System;

public class CSharpExam : Exam
{
    private const int MinScoreValue = 0;

    private const int MaxScoreValue = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            string exeptionMessage = string.Format(
                "The score shuld be in range [{0}...{1}]",
                MinScoreValue,
                MaxScoreValue);
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Score", exeptionMessage);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScoreValue, MaxScoreValue, "Exam results calculated by score.");
    }
}