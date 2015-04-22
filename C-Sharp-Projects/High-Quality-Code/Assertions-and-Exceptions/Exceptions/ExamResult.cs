using System;

public class ExamResult
{
    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "The grade cannot be negative");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "The min grade cannot be lower than 0");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The min grade myst be lower than the max grade");
        }

        if (string.IsNullOrWhiteSpace(comments))
        {
            throw new ArgumentException("The comments can't be empty");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
