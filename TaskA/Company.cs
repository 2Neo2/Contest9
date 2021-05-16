using System;
using System.Collections.Generic;

public class Company
{
    private readonly List<TeamLead> teamLeads;

    public Company(int teamLeadsAmount, int[] programmersAmount)
    {
        teamLeads = new List<TeamLead>();
        for (int i = 0; i < teamLeadsAmount; i++)
        {
            List<Programmer> programmers = new List<Programmer>();
            for (int j = 0; j < programmersAmount[i]; j++)
            {
                
                int id = int.Parse($"{i + 1}{j + 1}");
                programmers.Add(new Programmer(id));
            }
            TeamLead teamLead = new TeamLead(i+1, programmers);
            teamLeads.Add(teamLead);
        }
    }

    public List<TeamLead> TeamLeads
    {
        get =>teamLeads; 
    }

    public void PrintTeams()
    {
        foreach (var el in teamLeads)
        {
            Console.WriteLine(el);
            Console.WriteLine($"Written lines of code: {el.GetWrittenLinesOfCode()}");
        }

        Console.WriteLine();
    }
}