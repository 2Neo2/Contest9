using System;

internal struct Student : IComparable<Student>
{
    private int id;
    private int height;
    private int math;
    private int english;
    private int PE;

    public Student(int id, int height, int math, int english, int PE)
    {
        this.id = id;
        this.height = height;
        this.math = math;
        this.english = english;
        this.PE = PE;
    }

    public int CompareTo(Student other)
    {
        if (math >other.math)
            return 1;
        else if ( math == other.math )
                if ( english > other.english )
                    return 1;
                else
                    return 0;
        else 
            return 0;
    }

    int IComparable<Student>.CompareTo(Student other)
    {
        if ( PE > other.PE)
            return 1;
        else if (PE == other.PE)
            if (height > other.height)
                return 1;
            else
                return 0;
        else
            return 0;
    }
    

    internal static Student Parse(string v)
    {
        var studentSettings = Array.ConvertAll(v.Split(' '), int.Parse);
        return new Student(studentSettings[0], studentSettings[1], studentSettings[2], studentSettings[3], studentSettings[4]);
    }

    public override string ToString()
    {
        return id.ToString();
    }
}