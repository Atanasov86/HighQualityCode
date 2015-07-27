using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentOutOfRangeException("Problem solved", "The number of problems should be in range [0...10]");
            }

            this.problemsSolved = value;
        }
    }


    public override ExamResult Check()
    {
        int countOfProblemSolved = this.ProblemsSolved;

        if (countOfProblemSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }

        if (countOfProblemSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        
        if (countOfProblemSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        throw new ArgumentOutOfRangeException("Number of problems", "Invalid number of problems solved!");
    }
}