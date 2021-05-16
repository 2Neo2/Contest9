using System;

public class Plumber : IPlumber
{
    public void FixPipe(ref int numberOfCrashes)
    {
        numberOfCrashes -= 1;
    }
}