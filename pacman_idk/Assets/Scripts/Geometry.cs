using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry
{
    static public Vector3 PointFromGrid(Vector3Int gridPoint)
    {
        float x = -0.5f + 1.0f * gridPoint.x;
        float y = -0.5f + 1.0f * gridPoint.y;
        float z = -0.5f + 1.0f * gridPoint.z;
        return new Vector3(x, y, z);
    }

    static public Vector3Int GridPoint(int col, int height, int row)
    {
        return new Vector3Int(col, height, row);
    }

    static public Vector3Int GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(1.0f + point.x);
        int row = Mathf.FloorToInt(1.0f + point.z);
        int height = Mathf.FloorToInt(1.0f + point.y);
        return new Vector3Int(col, height, row);
    }
}
