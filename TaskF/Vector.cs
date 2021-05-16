using System;

public class Vector : IComparable
{
    int x, y;

    public Vector(int x, int y)
    {
        this.x = Math.Abs(x);
        this.y = Math.Abs(y);
    }

    public double Length
    {
        get { return Math.Pow(x, 2) + Math.Pow(y, 2); }
    }

    internal static Vector Parse(string input)
    {
        int x, y;
        var parseString = input.Split(' ');
        if (parseString.Length == 2)
        {
            if (int.TryParse(parseString[0], out x) && int.TryParse(parseString[1], out y ))
                return new Vector(x,y);
            else
                throw new ArgumentException("Incorrect vector");
        }
        else 
            throw new ArgumentException("Incorrect vector");
    }

    public int CompareTo(object second)
    {
        var v2 = (Vector) second;
        if (Length > v2.Length)
            return 1;
        else if (Length < v2.Length)
            return -1;
        else
            return 0;
    }
}