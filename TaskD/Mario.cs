public class Mario : IHero, IPlumber
{
    public void FixPipe(ref int numberOfCrashes)
    {
        numberOfCrashes -= 1;
    }
    
    public void KillMonster(ref int numberOfMonsters)
    {
        numberOfMonsters -= 1;
    }
}