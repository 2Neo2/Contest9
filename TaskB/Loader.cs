using System;
using System.Collections.Generic;

public class Loader
{
    private static Dictionary<string, int> memory;

    public static void AddValueToStore(string key)
    {
        if (!memory.ContainsKey(key))
            memory.Add(key, 1);
        else 
            memory[key] += 1;
    }

    public static void Download(IList<IDownload> downloadsQueue)
    {
        memory = new Dictionary<string, int>();
        for (int i = 0; i < downloadsQueue.Count; i++)
        {
            if (!downloadsQueue[i].DownloadContent())
            {
                Console.WriteLine("Not enough free space!");
                Console.WriteLine();
                break;
            }
        }
        Console.WriteLine("Downloaded content:");

        foreach (var type in memory)
        {
            Console.WriteLine($"{type.Key}: {type.Value}");
        }
    }
}