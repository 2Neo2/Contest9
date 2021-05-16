using System;

public class Hero : IHero
{
    public void KillMonster(ref int numberOfMonsters)
    {
        numberOfMonsters -= 1;
    }
}