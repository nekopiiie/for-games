using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth 
{
    [SerializeField] GameObject _floorPrefab;
    [SerializeField] GameObject _wallPrefab;
    [SerializeField] GameObject _ladderPrefab;

    [SerializeField] private int _x;
    [SerializeField] private int _y;
    [SerializeField] private int _floors;

    private LabyrinthFloor[] _labyrinthFloors;

    // Start is called before the first frame update
    void Start()
    {
        _labyrinthFloors = new LabyrinthFloor[_floors];
        for (int i = 0; 1 < _floors; i++)
        {
            var floor = new LabyrinthFloor(_x, _y, this);
            _labyrinthFloors[i] = floor;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GenerateFloorCell(int x, int y, int z)
    {
        var position = Geometry.PointFromGrid(new Vector3Int(x, y, z));
        return Instantiate(_floorPrefab, position, Quaternion.identity);
    }
}
