using System;
using System.Collections.Generic;

public class Game
{
    public static IList<IHelper> helpers = new List<IHelper>();
    public static int numberOfPlayedRounds = 0;
    private readonly int numberOfRounds;
    

    public Game(int numberOfHeroes, int numberOfPlumbers, int numberOfMarios, int numberOfRounds)
    {
        this.numberOfRounds = numberOfRounds;
        
        for (int i = 0; i < numberOfHeroes; i++) 
        {
            helpers.Add(new Hero()); 
        }
        
        for (int i = 0; i < numberOfMarios; i++) 
        { 
            helpers.Add(new Mario());
        }

        for (int i = 0; i < numberOfPlumbers; i++)
        {
            helpers.Add(new Plumber()); 
        }
    }

    public void Play()
    {
        do
        {
            int[] quantityOfMonstersAndPipe = { };
            do
            {
                try
                {
                    quantityOfMonstersAndPipe = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    if (quantityOfMonstersAndPipe.Length !=2)
                        Console.WriteLine("Incorrect data!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect data!");
                }
            } while (quantityOfMonstersAndPipe.Length != 2 );

            var round = new Round(quantityOfMonstersAndPipe[0] ,quantityOfMonstersAndPipe[1]);
            round.Play();
        } while (numberOfPlayedRounds != numberOfRounds);
    }
}