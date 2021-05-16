using System;

public class Program
{
    public static void Main(string[] args)
    {
        var days = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        for (int i = 1; i <= days.Length; i++)
        {
            bool flag = false;
            for (int j = 1; j <= days.Length; j++)
            {
                if (days[i - 1] < days[j - 1] && i < j)
                {
                    flag = true;
                    Console.Write(j - i + " ");
                    break;
                }
            }
            if (!flag)
                Console.Write(0 + " ");
        }
    }
}