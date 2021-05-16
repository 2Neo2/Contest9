using System;
using System.Collections.Generic;

public class TeamLead : Programmer
{
    private readonly List<Programmer> programmers;

    public TeamLead(int id, List<Programmer> programmers) : base(id)
    {
        this.programmers = programmers;
    }

    public List<Programmer> Programmers
    {
        get { return programmers; }
    }

    public void HuntProgrammers(List<TeamLead> teamLeads)
    {
        for (int i = 0; i < teamLeads.Count; i++)
        {
            if (teamLeads[i] != this)
            { 
                Programmer[] programmer = new Programmer[teamLeads[i].Programmers.Count];
                teamLeads[i].Programmers.CopyTo(programmer);

                for (int j = 0; j < programmer.Length; j++)
                {
                    if (programmer[j].LinesOfCode % (this.Id + 1) == 0)
                    {
                        this.Programmers.Add(programmer[j]);
                        for (int k = 0; k < teamLeads[i].Programmers.Count; k++)
                        {
                            if (teamLeads[i].Programmers[k] == programmer[j])
                            {
                                teamLeads[i].Programmers.RemoveAt(k);
                            }
                        }
                    }
                }
            }
        }
    }

    public int GetWrittenLinesOfCode()
    {
        int linesOfCode = 0;
        for (int i = 0; i < programmers.Count; i++)
        {
            linesOfCode += programmers[i].LinesOfCode;
        }

        linesOfCode += this.LinesOfCode;
        return linesOfCode;
    }

    public override string ToString()
    {
        return String.Format("Team lead #{0}\nAmount of programmers in team: {1}", Id, programmers.Count);
    }
}