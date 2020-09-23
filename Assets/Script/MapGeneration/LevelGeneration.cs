using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelGeneration : MonoBehaviour
{
    public Transform startingPositions;
    public GameObject[] rooms;
    private int[,] map = new int[5, 5];
    void MapGen(int x, int y, int forceBit)
    {
        // if the index is out of range, exit prematurely
        if (x < 0 || x > 4) return;
        if (y < 0 || y > 4) return;
        
        // if the spot is already occupied, return
        if (map[x, y] != 0) return;

        int randRoom = Random.Range(1, 15) | forceBit;

        if (Random.Range(0, 1) > 0 && (randRoom & 1) == 1) randRoom &= 15;
        if (Random.Range(0, 1) > 0 && (randRoom & 2) == 2) randRoom &= 14;
        if (Random.Range(0, 1) > 0 && (randRoom & 4) == 4) randRoom &= 12;
        if (Random.Range(0, 1) > 0 && (randRoom & 8) == 8) randRoom &= 8;

        if (y > 0 && (map[x, y - 1] & 2) == 2) randRoom |= 1;
        if (y < 4 && (map[x, y + 1] & 1) == 1) randRoom |= 2;
        if (x > 0 && (map[x - 1, y] & 8) == 8) randRoom |= 4;
        if (x < 4 && (map[x + 1, y] & 4) == 4) randRoom |= 8;

        map[x, y] = randRoom;
        Vector3 mapPos = new Vector3((y - 2) * 5f, (2 - x) * 5f, 0);
        Instantiate(rooms[randRoom], mapPos, Quaternion.identity).transform.SetParent(startingPositions);
        
        Debug.Log($"{x},{y}: {map[x, y]}");
        
        if ((randRoom & 2) == 2) MapGen(x, y + 1, 1);
        if ((randRoom & 1) == 1) MapGen(x, y - 1, 2);
        if ((randRoom & 8) == 8) MapGen(x + 1, y, 4);
        if ((randRoom & 4) == 4) MapGen(x - 1, y, 8);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startingPositions == null)
        {
            startingPositions = Instantiate(new GameObject(),Vector3.zero, Quaternion.identity).transform;
        }
        
        MapGen((int) startingPositions.position.x, (int) startingPositions.position.y, 0);
    }
}
