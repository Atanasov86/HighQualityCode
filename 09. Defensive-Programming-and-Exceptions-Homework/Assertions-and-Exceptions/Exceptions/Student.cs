using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;

    private string lastName;

    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public Student(string firstName, string lastName)
        : this(firstName, lastName, new List<Exam>())
    {
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name", "First name cannot be null or empty");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Last name", "Last name cannot be null or empty");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentOutOfRangeException("Exams", "The Exams cannot be null");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The student has no exams!");
        }

        return this.Exams.Select(t => t.Check()).ToList();
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Cannot calculate result without exams");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = ((double)examResults[i].Grade - examResults[i].MinGrade)
                           / (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}