using System;
using System.Diagnostics;

public class Round 
{
    private int amountOfMonsters;
    private int amountOfCrashes;

    public Round(int amountOfMonsters, int amountOfCrashes)
    {
        this.amountOfCrashes = amountOfCrashes;
        this.amountOfMonsters = amountOfMonsters;
    }
    
    
    public void Play()
    {
        Game.numberOfPlayedRounds += 1;
        foreach (var helper in Game.helpers)
        {
            switch (helper)
            {
                case Hero hero:
                    ((IHero)helper).KillMonster(ref amountOfMonsters);
                    break;
                case Mario mario :
                    ((IHero)helper).KillMonster(ref amountOfMonsters);
                    ((IPlumber)helper).FixPipe(ref amountOfCrashes);
                    break;
                case Plumber plumber:
                    ((IPlumber)helper).FixPipe(ref amountOfCrashes);
                    break;
            }
        }
        
        if (amountOfCrashes <= 0 && amountOfMonsters <= 0 )
            Console.WriteLine("Helpers won this round!");
        else if (amountOfCrashes > 0 && amountOfMonsters > 0)
        {
            Console.WriteLine("Helpers lost this round!");
            Game.helpers.Add(new Mario());
        }
        else if (amountOfCrashes == 0 && amountOfMonsters > 0)
        {
            Console.WriteLine("Helpers lost this round!");
            Game.helpers.Add(new Hero());
        }
        else if (amountOfCrashes > 0 && amountOfMonsters == 0)
        {
            Console.WriteLine("Helpers lost this round!");
            Game.helpers.Add(new Plumber());
        }
        else if (amountOfCrashes < 0 && amountOfMonsters > 0)
        {
            Console.WriteLine("Helpers lost this round!");
            Game.helpers.Add(new Hero());
        }
        else if (amountOfCrashes > 0 && amountOfMonsters < 0)
        {
            Console.WriteLine("Helpers lost this round!");
            Game.helpers.Add(new Plumber());
        }
    }
}