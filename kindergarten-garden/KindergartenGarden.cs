using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden

{
    private List<(Plant plant, string childName)> _plantedPlants = new List<(Plant plant, string childName)>();
    private string[] _children = new string[] 
    { 
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred", 
        "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    };
    public KindergartenGarden(string diagram)
    {
        int childIndex;
        var rowDiagrams = diagram.Split("\n");
        for (int i = 0; i < rowDiagrams.Length; i++)
        {
            childIndex = 0;
            for (int y = 0; y < rowDiagrams[i].Length; y++)
            {
                switch (rowDiagrams[i][y])
                {
                    case 'V':
                        _plantedPlants.Add((Plant.Violets, _children[childIndex]));
                        break;
                    case 'R':
                        _plantedPlants.Add((Plant.Radishes, _children[childIndex]));
                        break;
                    case 'C':
                        _plantedPlants.Add((Plant.Clover, _children[childIndex]));
                        break;
                    case 'G':
                        _plantedPlants.Add((Plant.Grass, _children[childIndex]));
                        break;
                }
                if ((y % 2) != 0) 
                    childIndex++;
            }
        }
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return _plantedPlants
            .Where(_plantedPlants => (_plantedPlants.childName == student))
            .Select(_plantedPlants => _plantedPlants.plant)
            .ToArray();
    }
}