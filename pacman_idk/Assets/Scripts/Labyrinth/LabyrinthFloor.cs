using System.Collections;
using UnityEngine;

public class LabyrinthFloor
{
    private int _x;
    private int _z;
    private Labyrinth _parent;

    public LabyrinthFloor(int x, int z, Labyrinth parent)
    {
        _x = x;
        _z = z;
        _parent = parent;

        for (int i = 0; i < _x; i++)
        {
            for (int j = 0; j < _z; j++)
            {
                var obj = _parent.GenerateFloorCell(i, 0, j);
            }
        }
    }
}
