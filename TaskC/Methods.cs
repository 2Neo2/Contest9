using System;
using System.Collections.Generic;

public static class Methods
{
    private static int max;
    public static int FindBestBiathlonistValue(List<Sportsman> sportsmen)
    {
        max = 0;
        for (int i = 0; i < sportsmen.Count; i++)
        {
            if (sportsmen[i] is Biathlonist)
            {
                var value = (IShooter) sportsmen[i];
                var secondValue = (ISkiRunner) sportsmen[i];
                var result = 0.4 * Math.Max(value.Shoot(), secondValue.Run()) +
                             0.6 * Math.Min(value.Shoot(), secondValue.Run());
                if ((int) result > max)
                    max = (int) result;
            }
        }
        return max;
    }

    public static int FindBestShooterValue(List<Sportsman> sportsmen)
    {
        max = 0;
        for (int i = 0; i < sportsmen.Count; i++)
        {
            if (sportsmen[i] is Shooter || sportsmen[i] is Biathlonist)
            {
                var value = (IShooter)sportsmen[i];
                if (value.Shoot() > max)
                    max = value.Shoot();
            }
        }
        return max;
    }

    public static int FindBestRunnerValue(List<Sportsman> sportsmen)
    {
        max = 0;
        for (int i = 0; i < sportsmen.Count; i++)
        {
            if (sportsmen[i] is SkiRunner || sportsmen[i] is Biathlonist)
            {
                var value = (ISkiRunner) sportsmen[i];
                if (value.Run() > max)
                    max = value.Run();
            }
        }
        return max;
    }
}