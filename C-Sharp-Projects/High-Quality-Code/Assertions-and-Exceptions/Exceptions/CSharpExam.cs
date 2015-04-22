using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("score", "The exam score can't be negative");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (this.Score < 0 || this.Score > 100)
        {
            throw new ArgumentOutOfRangeException("score", "The exam score must be betwee 0 and 100");
        }

        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
