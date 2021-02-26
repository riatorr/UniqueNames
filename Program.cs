using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] TeamNames = { "Herb", "Shane", "Brent", "Diego", "Nathan"};
            List<List<string>> Teams = new List<List<string>>();

            int listLength = TeamNames.Length;
            int combinationLength = 3;

            for (int i = 0; i < listLength; i++)
            {
                string start = TeamNames[i];
                List<string> NamesList = new List<string>();

                if (!NamesList.Contains(start))
                {
                    NamesList.Add(start);
                }

                for (int x = 0; x < listLength; x++)
                {
                    for (int y = 0; y < listLength; y++)
                    {
                        if (!NamesList.Contains(TeamNames[x]))
                        {
                            NamesList.Add(TeamNames[x]);
                        }

                        if (!NamesList.Contains(TeamNames[y]))
                        {
                            NamesList.Add(TeamNames[y]);
                        }

                        if (NamesList.Count == combinationLength)
                        {
                            List<string> Names = new List<string>();
                            NamesList.Sort();
                            foreach (var name in NamesList)
                            {
                                Names.Add(name);
                            }
                            Teams.Add(Names);
                            NamesList.Clear();

                            if (!NamesList.Contains(start))
                            {
                                NamesList.Add(start);
                            }
                        }
                    }
                }
            }

            List<string> UniqueTeams = new List<string>();

            foreach (var list in Teams)
            {
                string names = string.Join(", ", list);
                UniqueTeams.Add(names);
            }

            UniqueTeams.Sort();
            var sumNames = (from d in UniqueTeams select d).Distinct().Count();
            var distinctNames = (from d in UniqueTeams select d).Distinct();
            Console.WriteLine("Number of unique names: " + sumNames + "\n");

            foreach (var item in distinctNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}